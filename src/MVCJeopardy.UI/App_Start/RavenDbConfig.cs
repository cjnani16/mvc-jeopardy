using System;
using System.Web.Mvc;
using MVCJeopardy.Core.Domain;
using Raven.Client;

namespace MVCJeopardy.UI
{
    public static class RavenDbConfig
    {
        public static void FillData()
        {
            var store = DependencyResolver.Current.GetService<IDocumentStore>();

            using (var session = store.OpenSession())
            {

                var c1q1 = new QuestionAnswer("A view created with a model class", "What is a strongly typed view?", 300);
                var c1q2 = new QuestionAnswer("A reusable view", "What is a partial view?", 200);
                var c1q3 = new QuestionAnswer("The three segments of the default route.", "What are controller, action, and parameters?", 400);
                var c1q4 = new QuestionAnswer("Information from this is presented in the View", "What is the Model?", 100);
                var c2q1 = new QuestionAnswer("This man introduced MVC into Smalltalk-76 while visiting Xerox Parc in the 1970s.", "Who is Trygve Reenskaug?", 400);
                var c2q2 = new QuestionAnswer("MVC was introduced in this decade, alongside e-mail, fiber optics, and Star Wars.", "What is the 70s?", 100);
                var c2q3 = new QuestionAnswer("mr. crawford", "who's da illest?", 100);
                var c3q1 = new QuestionAnswer("j-bo", "who's wildin' out?", 100);
                var c3q2 = new QuestionAnswer("dj jnani craw", "who's 106 and parkin' it?", 100);
                var c3q3 = new QuestionAnswer("j-j-j-j-j-jaaaaaayyy maaaaaan", "who's on a new level?", 100);

                QuestionAnswer[] c1 = { c1q1, c1q2, c1q3 };
                QuestionAnswer[] c2 = { c2q1, c2q2, c2q3 };
                QuestionAnswer[] c3 = { c3q1, c3q2, c3q3 };

                var C1 = new Category("Badness 1", c1);
                var C2 = new Category("Badness 2", c2);
                var C3 = new Category("Badness 3", c2);

                Category[] demo = { C1, C2, C3 };

                var demoSet = new QuestionSet("Demo","we pretty much da illest ones out here.", demo);

                demoSet.Id = Guid.Parse("38BBD34B-23F2-43CD-8BBE-37D27C7550DE");


                session.Store(demoSet);

                session.SaveChanges();
            }
        }


    }
}