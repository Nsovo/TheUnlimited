namespace TheUnlimited_Backend_.Models
{
    public class Mandate
    {
        public int MandateID { get; set; }
        public int ContactID { get; set; }
        public int ProductID { get; set; }
        public Contact Contact { get; set; }
        public Product Product { get; set; }
    }
}
