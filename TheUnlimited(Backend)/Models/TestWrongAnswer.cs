namespace TheUnlimited_Backend_.Models
{
    public class TestWrongAnswer
    {
        public int TestWrongAnswerID { get; set; }
        public int TestQuestionID { get; set; }
        public string WrongAnswerText { get; set; }

        public TestQuestion TestQuestion { get; set; }
    }
}
