namespace TheUnlimited_Backend_.Models
{
    public class TestAnswer
    {
        public int TestAnswerID { get; set; }
        public int TestQuestionID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public TestQuestion TestQuestion { get; set; }
    }
}
