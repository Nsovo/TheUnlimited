using Microsoft.EntityFrameworkCore;

namespace TheUnlimited_Backend_.Models
{
    public class ContactPlan
    {
        public int ContactID { get; set; }
        public Contact? Contact { get; set; }

        public int? PlanID { get; set; }
        public Plan? Plan { get; set; }
    }
}
