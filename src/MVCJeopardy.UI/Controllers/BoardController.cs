using MVCJeopardy.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MVCJeopardy.Core.Domain;
using MVCJeopardy.UI.Infrastructure;

namespace MVCJeopardy.UI.Controllers
{
    public class BoardController : Controller
    {
        public readonly IBoardRepository _repository;

        public BoardController(IBoardRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var qSet = _repository
                .Load(Guid.Parse("38BBD34B-23F2-43CD-8BBE-37D27C7550DE"))
                ;

            var model = new BoardIndexModel
                {
                    questionSet = qSet
                };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string title, string desc, ICollection<string> qs, ICollection<string> ans, ICollection<int> vs, ICollection<string> cats, int nc, int nq)
        {
            List<QuestionAnswer> q = new List<QuestionAnswer>();
            List<Category> c = new List<Category>();

            string[] qsarray = new string[qs.Count];
            qs.CopyTo(qsarray, 0);
            string[] ansarray = new string[ans.Count];
            ans.CopyTo(ansarray, 0);
            int[] vsarray = new int[vs.Count];
            vs.CopyTo(vsarray, 0);
            string[] catsarray = new string[cats.Count];
            cats.CopyTo(catsarray, 0);

            for (int cC = 0; cC < catsarray.Length; cC++)
            {
                for (int cQ = 0; cQ < ansarray.Length; cQ++)
                {
                    QuestionAnswer qa = new QuestionAnswer(ansarray[cQ], qsarray[cQ], vsarray[cQ]);
                    q.Add(qa);
                }
                QuestionAnswer[] questionArray = q.ToArray();
                Category ca = new Category(catsarray[cC], questionArray);

                c.Add(ca);
            }
            Category[] categoryArray = c.ToArray();

            var model = new QuestionSet(title, desc, categoryArray);

            _repository.Insert(model);
            _repository.SaveChanges();

            BoardIndexModel bmodel = new BoardIndexModel();
            bmodel.questionSet = model;

            return View(bmodel);
        }


        public ActionResult ShowAnswer(string sID, int cC, int cQ)
        {
            
            var loaded = _repository.Load(Guid.Parse(sID));

            var cQuest = loaded.gameBoard[cC].questions[cQ];
            var cCat = loaded.gameBoard[cC];

            var model = new ShowAnswerModel
                {
                    cQuestion = cQuest,
                    cCategory = cCat,
                    guid = Guid.Parse(sID),
                    curC = cC,
                    curQ = cQ
                };

            return View(model);
        }

        public ActionResult MarkVisited(string g, int cC, int cQ)
        {
                QuestionSet set = _repository.Load(Guid.Parse(g));
                set.gameBoard[cC].questions[cQ].Visited = true;
                _repository.SaveChanges();

                return RedirectToAction("Index");
         
        }
    }
}
