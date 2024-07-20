using Microsoft.EntityFrameworkCore;

namespace TheUnlimited_Backend_.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Mandate> Mandates { get; set; }

        public ICollection<ContactPlan> ContactPlans { get; set; }
    }
}
