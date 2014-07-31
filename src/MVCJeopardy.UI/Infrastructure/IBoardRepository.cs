using System;
using System.Collections.Generic;
using MVCJeopardy.Core.Domain;
using Raven.Client;
using System.Linq;
using Raven.Client.Linq;

namespace MVCJeopardy.UI.Infrastructure
{
    public interface IBoardRepository
    {
        IEnumerable<QuestionSet> GetAll();
        IRavenQueryable<QuestionSet> Query();
        QuestionSet Load(Guid id);
        QuestionSet FindByTitle(string title);
        void Insert(QuestionSet questionSet);
        void SaveChanges();
    }

    public class BoardRepository : IBoardRepository
    {
        private readonly IDocumentSession _documentSession;

        public BoardRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public QuestionSet Load(Guid id)
        {
            return _documentSession.Load<QuestionSet>(id);
        }

        public QuestionSet FindByTitle(string title)
        {
            return _documentSession.Query<QuestionSet>()
                .FirstOrDefault(c => c.Title == title);
        }

        public IRavenQueryable<QuestionSet> Query()
        {
            return _documentSession.Query<QuestionSet>();
        }

        public IEnumerable<QuestionSet> GetAll()
        {
            return _documentSession.Query<QuestionSet>().ToList();
        }

        public void Insert(QuestionSet questionSet)
        {
            _documentSession.Store(questionSet);
        }

        public void SaveChanges()
        {
            _documentSession.SaveChanges();
        }
    }
}