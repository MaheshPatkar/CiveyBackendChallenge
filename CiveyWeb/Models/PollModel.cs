using System.Collections.Generic;

namespace CiveyWeb.Models
{
    public class PollModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool MultiChoice { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}