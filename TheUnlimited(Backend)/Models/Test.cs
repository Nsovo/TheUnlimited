namespace TheUnlimited_Backend_.Models
{
    public class Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
        public ICollection<TestAccess> TestAccesses { get; set; }
    }
}
