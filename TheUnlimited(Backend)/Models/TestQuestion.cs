using TheUnlimited_Backend_.Models;

public class TestQuestion
{
    public int TestQuestionID { get; set; }
    public int TestID { get; set; }
    public string QuestionText { get; set; }

    public Test Test { get; set; }
    public ICollection<TestAnswer> TestAnswers { get; set; }
    public ICollection<TestWrongAnswer> TestWrongAnswers { get; set; }
}
