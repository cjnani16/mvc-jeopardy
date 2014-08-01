using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCJeopardy.Core.Domain
{
    public class Category
    {
        public string Name;
        public QuestionAnswer[] questions;
        public Category()
        {

        }

        public Category(string name, QuestionAnswer[] quests)
        {
            Name = name;
            questions = quests;
        }
    }
}