using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCJeopardy.Core.Domain;

namespace MVCJeopardy.UI.Models
{
    public class BoardIndexModel
    {
        public QuestionSet questionSet;
    }
    public class ShowAnswerModel
    {
        public Category cCategory;
        public QuestionAnswer cQuestion;
        public Guid guid;
        public int curC, curQ;
    }
    public class CreateBoardModel
    {
        public QuestionSet questionSet;
    }
}