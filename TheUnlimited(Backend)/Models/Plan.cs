namespace TheUnlimited_Backend_.Models
{
    public class Plan
    {
        public int? PlanID { get; set; }
        public string? PlanName { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }

        public ICollection<ContactPlan>? ContactPlans { get; set; }
    }
}
