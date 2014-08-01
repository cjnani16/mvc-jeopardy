using System;
using System.Collections.Generic;
using MVCJeopardy.Core.Domain;
using Raven.Client;
using System.Linq;
using Raven.Client.Linq;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

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
        void Delete(QuestionSet questionSet);
        void InsertFromXml(string filePath);
    }

    public class BoardRepository : IBoardRepository
    {
        private readonly IDocumentSession _documentSession;

        public BoardRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Delete(QuestionSet questionSet)
        {
            _documentSession.Delete<QuestionSet>(questionSet);
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

        public void InsertFromXml(string xmlFilePath)
        {
            //var store = DependencyResolver.Current.GetService<IDocumentStore>();
            //var xmlFilePath = ConfigurationManager.AppSettings["QuestionSetXmlFile"];
            //string xmlFilePath = HttpContext.Server.MapPath("~/App_Data/QuestionSet.xml");
            //using (var session = store.OpenSession())
            //{
                QuestionSet myObject;
                // Construct an instance of the XmlSerializer with the type
                // of object that is being deserialized.
                XmlSerializer mySerializer =
                    new XmlSerializer(typeof(QuestionSet));
                // To read the file, create a FileStream.
                FileStream myFileStream = new FileStream(xmlFilePath, FileMode.Open);
                // Call the Deserialize method and cast to the object type.
                myObject = (QuestionSet)mySerializer.Deserialize(myFileStream);
                _documentSession.Store(myObject);
                _documentSession.SaveChanges();
                myFileStream.Close();
            //}
        }
        public void SaveChanges()
        {
            _documentSession.SaveChanges();
        }
    }
}