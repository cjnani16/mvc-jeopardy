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
            Title = "NONE";
        }

        public QuestionSet(string title, string desc, Category[] gB)
        {
            Title = title;
            Description = desc;
            gameBoard = gB;
        }
    }
}