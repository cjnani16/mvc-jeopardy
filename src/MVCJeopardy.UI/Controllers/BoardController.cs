﻿using MVCJeopardy.UI.Models;
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
        public ActionResult Index(string title, string desc, string[] qs, string[] ans, int[] vs, string[] cats, int nc, int nq)
        {
            List<QuestionAnswer> q = new List<QuestionAnswer>();
            List<Category> c = new List<Category>();

            for (int cC = 0; cC < cats.Length; cC++)
            {
                for (int cQ = 0; cQ < ans.Length; cQ++)
                {
                    QuestionAnswer qa = new QuestionAnswer(ans[cQ], qs[cQ], vs[cQ]);
                    q.Add(qa);
                }
                QuestionAnswer[] questionArray = q.ToArray();
                Category ca = new Category(cats[cC], questionArray);

                c.Add(ca);
            }
            Category[] categoryArray = c.ToArray();

            var model = new QuestionSet(title, desc, categoryArray);

            _repository.Insert(model);

            return View(model);
        }


        public ActionResult ShowAnswer(string sID, int cC, int cQ)
        {
            
            var loaded = _repository.FindByTitle("Demo");

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
                Guid id = new Guid(g);
                QuestionSet set = _repository.Load(id);
                set.gameBoard[cC].questions[cQ].visited = true;
                _repository.SaveChanges();

                return RedirectToAction("Index");
         
        }
    }
}