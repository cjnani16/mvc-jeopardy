using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCJeopardy.Core.Domain
{
    public class QuestionAnswer
    {
        public bool visited;
        public string question;
        public string answer;
        public int pointValue;
        public Guid qId;

        public QuestionAnswer(string ans, string quest, int valu)
        {
            visited = false;
            question = quest;
            answer = ans;
            pointValue = valu;
        }

        public QuestionAnswer()
        {
            visited = false;
            question = "Why did the Chicken cross the road?";
            answer = "To get to the other side.";
            pointValue = 100;
        }

        public void setVisited(bool set) {
            visited = set;
        }
    }
}