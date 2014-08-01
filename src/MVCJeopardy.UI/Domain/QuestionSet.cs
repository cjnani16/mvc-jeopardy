using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCJeopardy.Core.Domain
{
    public class QuestionSet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category[] gameBoard;
        public Guid Id { get; set; }
        public QuestionSet()
        {

        }

        public QuestionSet(string title, string desc, Category[] gB)
        {
            Title = title;
            Description = desc;
            gameBoard = gB;
        }

        public void sortCategories() {
            foreach (Category ccat in gameBoard)
            {
                Array.Sort(ccat.questions, delegate(QuestionAnswer q1, QuestionAnswer q2)
                {
                    return q1.PointValue.CompareTo(q2.PointValue); // (q1.PV - q2.PV)
                });
            }
        }
    }
}