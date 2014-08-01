using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCJeopardy.Core.Domain
{
    public class QuestionAnswer
    {
        public bool Visited;
        public string Question;
        public string Answer;
        public int PointValue;
        public Guid Id;
        public QuestionAnswer()
        {

        }

        public QuestionAnswer(string ans, string quest, int valu)
        {
            Visited = false;
            Question = quest;
            Answer = ans;
            PointValue = valu;
        }

        public void SetVisited(bool set) {
            Visited = set;
        }
    }
}