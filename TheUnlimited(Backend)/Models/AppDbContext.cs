using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//IdentityDbContext<User>
//IdentityDbContext<IdentityUser>
namespace TheUnlimited_Backend_.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentLevel> AgentLevels { get; set; }
        public DbSet<AgentStatus> AgentStatuses { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<CommissionRate> CommissionRates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPlan> ContactPlans { get; set; }
        public DbSet<EarnedType> EarnedTypes { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<HelpCategory> HelpCategories { get; set; }
        public DbSet<Hierarchy> Hierarchies { get; set; }
        public DbSet<Juice> Juices { get; set; }
        public DbSet<Mandate> Mandates { get; set; }
        public DbSet<MerchCode> MerchCodes { get; set; }
        public DbSet<MerchLevel> MerchLevels { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeProvince> OfficeProvinces { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerType> OwnerTypes { get; set; }
        public DbSet<ParentLevel> ParentLevels { get; set; }
        public DbSet<PayoutRule> PayoutRules { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<QueryStatus> QueryStatuses { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<RewardType> RewardTypes { get; set; }
        public DbSet<SalesChannel> SalesChannels { get; set; }
        public DbSet<SalesTarget> SalesTargets { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestAccess> TestAccesses { get; set; }
        public DbSet<TestAnswer> TestAnswers { get; set; }
        public DbSet<TestWrongAnswer> TestWrongAnswers { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<VAT> VATs { get; set; }
        public DbSet<YearWeek> YearWeeks { get; set; }
        public DbSet<CommissionStatus> CommissionStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Agent relationships
            modelBuilder.Entity<Agent>()
                .HasOne(a => a.AgentLevel)
                .WithMany(al => al.Agents)
                .HasForeignKey(a => a.AgentLevelID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Agent>()
                .HasOne(a => a.AgentStatus)
                .WithMany(ast => ast.Agents)
                .HasForeignKey(a => a.AgentStatusID);

            modelBuilder.Entity<Agent>()
                .HasOne(a => a.Office)
                .WithMany(o => o.Agents)
                .HasForeignKey(a => a.OfficeCode);

            modelBuilder.Entity<Agent>()
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Agents)
                .HasForeignKey(a => a.ScheduleID);

            modelBuilder.Entity<Agent>()
                .HasOne(a => a.SalesChannel)
                .WithMany(sc => sc.Agents)
                .HasForeignKey(a => a.SalesChannelID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Agent>()
                .HasMany(a => a.Users)
                .WithOne()
                .HasForeignKey(u => u.AgentID);

            modelBuilder.Entity<Agent>()
                .HasMany(a => a.Hierarchies)
                .WithOne(h => h.Agent)
                .HasForeignKey(h => h.AgentID);

            modelBuilder.Entity<Agent>()
                .HasMany(a => a.AuditTrails)
                .WithOne(at => at.Agent)
                .HasForeignKey(at => at.AgentID);

            // User-Agent one-to-many relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Agent)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AgentID);

            // Contact-Plan many-to-many relationship
            modelBuilder.Entity<ContactPlan>()
                .HasKey(cp => new { cp.ContactID, cp.PlanID });

            modelBuilder.Entity<ContactPlan>()
                .HasOne(cp => cp.Contact)
                .WithMany(c => c.ContactPlans)
                .HasForeignKey(cp => cp.ContactID);

            modelBuilder.Entity<ContactPlan>()
                .HasOne(cp => cp.Plan)
                .WithMany(p => p.ContactPlans)
                .HasForeignKey(cp => cp.PlanID);

            // Commission relationships
            modelBuilder.Entity<Commission>(entity =>
            {
                entity.Property(e => e.TotalEarnings).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Commissions).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Sales).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DebiCheckPercentage).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SR).HasColumnType("decimal(18, 2)");

                entity.HasOne(e => e.Agent)
                    .WithMany(a => a.Commissions)
                    .HasForeignKey(e => e.AgentID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Commissions)
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.ProductSales)
                    .WithMany(ps => ps.Commissions)
                    .HasForeignKey(e => e.ProductSalesID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.ProductSales)
                   .WithMany(ps => ps.Commissions)
                   .HasForeignKey(e => e.SalesChannelID)
                   .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.AgentStatus)
                    .WithMany(a => a.Commissions)
                    .HasForeignKey(e => e.AgentStatusID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.CommissionStatus)
                    .WithMany(c => c.Commissions)
                    .HasForeignKey(e => e.CommissionStatusID)
                    .OnDelete(DeleteBehavior.NoAction);


            });

            // ProductCategory relationships
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            // Product relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryID);
            // Mandate relationships
            modelBuilder.Entity<Mandate>()
                .HasOne(m => m.Contact)
                .WithMany(c => c.Mandates)
                .HasForeignKey(m => m.ContactID);

            modelBuilder.Entity<Mandate>()
                .HasOne(m => m.Product)
                .WithMany(p => p.Mandates)
                .HasForeignKey(m => m.ProductID);

            // Hierarchy relationships
            modelBuilder.Entity<Hierarchy>()
                .HasOne(h => h.ParentLevel)
                .WithMany(pl => pl.Hierarchies)
                .HasForeignKey(h => h.ParentLevelID);

            // Office relationships
            modelBuilder.Entity<Office>()
                .HasOne(o => o.Owner)
                .WithMany(ow => ow.Offices)
                .HasForeignKey(o => o.OwnerID);

            modelBuilder.Entity<OfficeProvince>()
                .HasKey(op => new { op.OfficeCode, op.ProvinceID });

            modelBuilder.Entity<OfficeProvince>()
                .HasOne(op => op.Office)
                .WithMany(o => o.OfficeProvinces)
                .HasForeignKey(op => op.OfficeCode);

            modelBuilder.Entity<OfficeProvince>()
                .HasOne(op => op.Province)
                .WithMany(p => p.OfficeProvinces)
                .HasForeignKey(op => op.ProvinceID);

            // Reward relationships
            modelBuilder.Entity<Reward>()
                .HasOne(r => r.Agent)
                .WithMany(a => a.Rewards)
                .HasForeignKey(r => r.AgentID);

            modelBuilder.Entity<Reward>()
                .HasOne(r => r.RewardType)
                .WithMany(rt => rt.Rewards)
                .HasForeignKey(r => r.RewardTypeID);

            // Test relationships
            modelBuilder.Entity<TestQuestion>()
                .HasOne(tq => tq.Test)
                .WithMany(t => t.TestQuestions)
                .HasForeignKey(tq => tq.TestID);

            modelBuilder.Entity<TestAnswer>()
                .HasOne(ta => ta.TestQuestion)
                .WithMany(tq => tq.TestAnswers)
                .HasForeignKey(ta => ta.TestQuestionID);

            modelBuilder.Entity<TestAccess>()
                .HasKey(ta => new { ta.TestID, ta.AgentLevelID });

            modelBuilder.Entity<TestAccess>()
                .HasOne(ta => ta.Test)
                .WithMany(t => t.TestAccesses)
                .HasForeignKey(ta => ta.TestID);

            modelBuilder.Entity<TestAccess>()
                .HasOne(ta => ta.AgentLevel)
                .WithMany(al => al.TestAccesses)
                .HasForeignKey(ta => ta.AgentLevelID);

            modelBuilder.Entity<TestWrongAnswer>()
                .HasOne(twa => twa.TestQuestion)
                .WithMany(tq => tq.TestWrongAnswers)
                .HasForeignKey(twa => twa.TestQuestionID);

            // User relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithMany(up => up.Users)
                .HasForeignKey(u => u.UserProfileID);

            // ProductSales relationships
            modelBuilder.Entity<ProductSales>()
                .HasOne(ps => ps.Agent)
                .WithMany(a => a.ProductSales)
                .HasForeignKey(ps => ps.AgentID);

            // CommissionStatus relationships
            modelBuilder.Entity<Commission>()
                .HasOne(c => c.CommissionStatus)
                .WithMany(cs => cs.Commissions)
                .HasForeignKey(c => c.CommissionStatusID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Commission>()
                .HasOne(al => al.AgentLevel)
                .WithMany(c => c.Commissions)
                .HasForeignKey(c => c.AgentLevelID)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure other entities with decimal properties
            modelBuilder.Entity<CommissionRate>().Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Juice>().Property(e => e.JuicePrice).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<PayoutRule>().Property(e => e.PayoutPercentage).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Policy>().Property(e => e.PolicyAmount).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<ProductSales>().Property(e => e.SalesAmount).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Reward>().Property(e => e.RewardAmount).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<SalesTarget>().Property(e => e.TargetAmount).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<VAT>().Property(e => e.Percentage).HasColumnType("decimal(18, 2)");



            // Seed data for RewardType
            modelBuilder.Entity<RewardType>().HasData(
                new RewardType { RewardTypeID = 1, TypeDescription = "Bonus" },
                new RewardType { RewardTypeID = 2, TypeDescription = "Promotion" }
            );

            // Seed data for AgentLevel
            modelBuilder.Entity<AgentLevel>().HasData(
                new AgentLevel { AgentLevelID = 1, LevelDescription = "Trainee" },
                new AgentLevel { AgentLevelID = 2, LevelDescription = "Trainer" },
                new AgentLevel { AgentLevelID = 3, LevelDescription = "Trainee Owner" },
                new AgentLevel { AgentLevelID = 4, LevelDescription = "Owner" },
                new AgentLevel { AgentLevelID = 5, LevelDescription = "Promoting Owner" },
                new AgentLevel { AgentLevelID = 6, LevelDescription = "Divisional Owner" },
                new AgentLevel { AgentLevelID = 7, LevelDescription = "Vice President" }
            );

            // Seed data for Tests
            modelBuilder.Entity<Test>().HasData(
                new Test { TestID = 1, TestName = "Sales Manual Test" },
                new Test { TestID = 2, TestName = "Trainer Manual Test" },
                new Test { TestID = 3, TestName = "Owner's Manual Test" }
            );

            // Seed data for TestQuestions
            modelBuilder.Entity<TestQuestion>().HasData(
                // Sales Manual Test Questions
                new TestQuestion { TestQuestionID = 1, TestID = 1, QuestionText = "What is the guaranteed commission for new agents per working day?" },
                new TestQuestion { TestQuestionID = 2, TestID = 1, QuestionText = "What is the minimum dial time required for a full day's commission?" },
                new TestQuestion { TestQuestionID = 3, TestID = 1, QuestionText = "How much is paid for dial time between 120 to 149 minutes?" },
                new TestQuestion { TestQuestionID = 4, TestID = 1, QuestionText = "What is the commission rate for 1-23 adjusted pieces below 40% Debi Check?" },
                new TestQuestion { TestQuestionID = 5, TestID = 1, QuestionText = "What is the default Success Rate (SR) for new agents in the Motor category?" },
                new TestQuestion { TestQuestionID = 6, TestID = 1, QuestionText = "What is the commission for 24+ adjusted pieces above 40% Debi Check?" },
                new TestQuestion { TestQuestionID = 7, TestID = 1, QuestionText = "How many days are included in the first pay cycle of 2023?" },
                new TestQuestion { TestQuestionID = 8, TestID = 1, QuestionText = "What is the commission rate for 24+ adjusted pieces below 40% Debi Check?" },
                new TestQuestion { TestQuestionID = 9, TestID = 1, QuestionText = "What is the qualifying criteria for a Trainer override?" },
                new TestQuestion { TestQuestionID = 10, TestID = 1, QuestionText = "How many personal adjusted pieces are required for a Trainee Owner override?" },

                // Trainer Manual Test Questions
                new TestQuestion { TestQuestionID = 11, TestID = 2, QuestionText = "What is the guaranteed commission for new agents per working day in the Persal category?" },
                new TestQuestion { TestQuestionID = 12, TestID = 2, QuestionText = "What is the commission rate for 1-16 adjusted pieces in Persal?" },
                new TestQuestion { TestQuestionID = 13, TestID = 2, QuestionText = "What is the default SR for new agents in Persal?" },
                new TestQuestion { TestQuestionID = 14, TestID = 2, QuestionText = "What is the qualifying criteria for a Trainer override in Persal?" },
                new TestQuestion { TestQuestionID = 15, TestID = 2, QuestionText = "What is the commission for 17+ adjusted pieces in the Persal Gap category?" },
                new TestQuestion { TestQuestionID = 16, TestID = 2, QuestionText = "How many days are included in the second pay cycle of 2023?" },
                new TestQuestion { TestQuestionID = 17, TestID = 2, QuestionText = "What is the commission rate for 1-16 adjusted pieces in Persal STD Upgrade?" },
                new TestQuestion { TestQuestionID = 18, TestID = 2, QuestionText = "How many personal adjusted pieces are required for a Trainee Owner override in Persal?" },
                new TestQuestion { TestQuestionID = 19, TestID = 2, QuestionText = "What is the commission rate for 17+ adjusted pieces in Persal Code GAP Upgrade?" },
                new TestQuestion { TestQuestionID = 20, TestID = 2, QuestionText = "What is the dial time required for a half day's commission?" },

                // Owner's Manual Test Questions
                new TestQuestion { TestQuestionID = 21, TestID = 3, QuestionText = "What is the guaranteed commission for new agents per working day in the Debit Order category?" },
                new TestQuestion { TestQuestionID = 22, TestID = 3, QuestionText = "What is the commission rate for 1-19 adjusted pieces below 40% Debi Check in Debit Order?" },
                new TestQuestion { TestQuestionID = 23, TestID = 3, QuestionText = "What is the default SR for new agents in Debit Order?" },
                new TestQuestion { TestQuestionID = 24, TestID = 3, QuestionText = "What is the qualifying criteria for a Trainer override in Debit Order?" },
                new TestQuestion { TestQuestionID = 25, TestID = 3, QuestionText = "What is the commission for 20+ adjusted pieces above 40% Debi Check in Debit Order?" },
                new TestQuestion { TestQuestionID = 26, TestID = 3, QuestionText = "How many days are included in the third pay cycle of 2023?" },
                new TestQuestion { TestQuestionID = 27, TestID = 3, QuestionText = "What is the commission rate for 1-19 adjusted pieces above 40% Debi Check in Debit Order?" },
                new TestQuestion { TestQuestionID = 28, TestID = 3, QuestionText = "How many personal adjusted pieces are required for a Trainee Owner override in Debit Order?" },
                new TestQuestion { TestQuestionID = 29, TestID = 3, QuestionText = "What is the commission rate for 20+ adjusted pieces below 40% Debi Check in Debit Order?" },
                new TestQuestion { TestQuestionID = 30, TestID = 3, QuestionText = "What is the dial time required for a full day's commission in Debit Order?" }
            );

            // Seed data for TestAnswers
            modelBuilder.Entity<TestAnswer>().HasData(
                // Sales Manual Test Answers
                new TestAnswer { TestAnswerID = 1, TestQuestionID = 1, AnswerText = "R200", IsCorrect = true },
                new TestAnswer { TestAnswerID = 2, TestQuestionID = 2, AnswerText = "150 minutes", IsCorrect = true },
                new TestAnswer
                {
                    TestAnswerID = 3,
                    TestQuestionID = 3,
                    AnswerText = "R100",
                    IsCorrect = true
                },
            new TestAnswer { TestAnswerID = 4, TestQuestionID = 4, AnswerText = "R300", IsCorrect = true },
    new TestAnswer { TestAnswerID = 5, TestQuestionID = 5, AnswerText = "60%", IsCorrect = true },
    new TestAnswer { TestAnswerID = 6, TestQuestionID = 6, AnswerText = "R450", IsCorrect = true },
    new TestAnswer { TestAnswerID = 7, TestQuestionID = 7, AnswerText = "13 days", IsCorrect = true },
    new TestAnswer { TestAnswerID = 8, TestQuestionID = 8, AnswerText = "R400", IsCorrect = true },
    new TestAnswer { TestAnswerID = 9, TestQuestionID = 9, AnswerText = "19 personal adjusted pieces and 50% SR", IsCorrect = true },
    new TestAnswer { TestAnswerID = 10, TestQuestionID = 10, AnswerText = "19", IsCorrect = true },

    // Trainer Manual Test Answers
    new TestAnswer { TestAnswerID = 11, TestQuestionID = 11, AnswerText = "R200", IsCorrect = true },
    new TestAnswer { TestAnswerID = 12, TestQuestionID = 12, AnswerText = "R350", IsCorrect = true },
    new TestAnswer { TestAnswerID = 13, TestQuestionID = 13, AnswerText = "85%", IsCorrect = true },
    new TestAnswer { TestAnswerID = 14, TestQuestionID = 14, AnswerText = "27 personal adjusted pieces and 50% SR", IsCorrect = true },
    new TestAnswer { TestAnswerID = 15, TestQuestionID = 15, AnswerText = "R575", IsCorrect = true },
    new TestAnswer { TestAnswerID = 16, TestQuestionID = 16, AnswerText = "20 days", IsCorrect = true },
    new TestAnswer { TestAnswerID = 17, TestQuestionID = 17, AnswerText = "R350", IsCorrect = true },
    new TestAnswer { TestAnswerID = 18, TestQuestionID = 18, AnswerText = "27", IsCorrect = true },
    new TestAnswer { TestAnswerID = 19, TestQuestionID = 19, AnswerText = "R550", IsCorrect = true },
    new TestAnswer { TestAnswerID = 20, TestQuestionID = 20, AnswerText = "120 to 149 minutes", IsCorrect = true },

    // Owner's Manual Test Answers
    new TestAnswer { TestAnswerID = 21, TestQuestionID = 21, AnswerText = "R200", IsCorrect = true },
    new TestAnswer { TestAnswerID = 22, TestQuestionID = 22, AnswerText = "R300", IsCorrect = true },
    new TestAnswer { TestAnswerID = 23, TestQuestionID = 23, AnswerText = "50%", IsCorrect = true },
    new TestAnswer { TestAnswerID = 24, TestQuestionID = 24, AnswerText = "16 personal adjusted pieces and 50% SR", IsCorrect = true },
    new TestAnswer { TestAnswerID = 25, TestQuestionID = 25, AnswerText = "R450", IsCorrect = true },
    new TestAnswer { TestAnswerID = 26, TestQuestionID = 26, AnswerText = "20 days", IsCorrect = true },
    new TestAnswer { TestAnswerID = 27, TestQuestionID = 27, AnswerText = "R350", IsCorrect = true },
    new TestAnswer { TestAnswerID = 28, TestQuestionID = 28, AnswerText = "16", IsCorrect = true },
    new TestAnswer { TestAnswerID = 29, TestQuestionID = 29, AnswerText = "R400", IsCorrect = true },
    new TestAnswer { TestAnswerID = 30, TestQuestionID = 30, AnswerText = "150 minutes", IsCorrect = true }
);

            // Seed data for TestWrongAnswers
            modelBuilder.Entity<TestWrongAnswer>().HasData(
                // Sales Manual Test Wrong Answers
                new TestWrongAnswer { TestWrongAnswerID = 1, TestQuestionID = 1, WrongAnswerText = "R150" },
                new TestWrongAnswer { TestWrongAnswerID = 2, TestQuestionID = 1, WrongAnswerText = "R250" },
                new TestWrongAnswer { TestWrongAnswerID = 3, TestQuestionID = 1, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 4, TestQuestionID = 2, WrongAnswerText = "120 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 5, TestQuestionID = 2, WrongAnswerText = "100 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 6, TestQuestionID = 2, WrongAnswerText = "200 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 7, TestQuestionID = 3, WrongAnswerText = "R150" },
                new TestWrongAnswer { TestWrongAnswerID = 8, TestQuestionID = 3, WrongAnswerText = "R50" },
                new TestWrongAnswer { TestWrongAnswerID = 9, TestQuestionID = 3, WrongAnswerText = "R200" },
                new TestWrongAnswer { TestWrongAnswerID = 10, TestQuestionID = 4, WrongAnswerText = "R350" },
                new TestWrongAnswer { TestWrongAnswerID = 11, TestQuestionID = 4, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 12, TestQuestionID = 4, WrongAnswerText = "R250" },
                new TestWrongAnswer { TestWrongAnswerID = 13, TestQuestionID = 5, WrongAnswerText = "50%" },
                new TestWrongAnswer { TestWrongAnswerID = 14, TestQuestionID = 5, WrongAnswerText = "70%" },
                new TestWrongAnswer { TestWrongAnswerID = 15, TestQuestionID = 5, WrongAnswerText = "80%" },
                new TestWrongAnswer { TestWrongAnswerID = 16, TestQuestionID = 6, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 17, TestQuestionID = 6, WrongAnswerText = "R500" },
                new TestWrongAnswer { TestWrongAnswerID = 18, TestQuestionID = 6, WrongAnswerText = "R350" },
                new TestWrongAnswer { TestWrongAnswerID = 19, TestQuestionID = 7, WrongAnswerText = "20 days" },
                new TestWrongAnswer { TestWrongAnswerID = 20, TestQuestionID = 7, WrongAnswerText = "15 days" },
                new TestWrongAnswer { TestWrongAnswerID = 21, TestQuestionID = 7, WrongAnswerText = "10 days" },
                new TestWrongAnswer { TestWrongAnswerID = 22, TestQuestionID = 8, WrongAnswerText = "R350" },
                new TestWrongAnswer { TestWrongAnswerID = 23, TestQuestionID = 8, WrongAnswerText = "R450" },
                new TestWrongAnswer { TestWrongAnswerID = 24, TestQuestionID = 8, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 25, TestQuestionID = 9, WrongAnswerText = "20 personal adjusted pieces and 60% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 26, TestQuestionID = 9, WrongAnswerText = "18 personal adjusted pieces and 55% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 27, TestQuestionID = 9, WrongAnswerText = "25 personal adjusted pieces and 70% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 28, TestQuestionID = 10, WrongAnswerText = "20" },
                new TestWrongAnswer { TestWrongAnswerID = 29, TestQuestionID = 10, WrongAnswerText = "25" },
                new TestWrongAnswer { TestWrongAnswerID = 30, TestQuestionID = 10, WrongAnswerText = "15" },

                // Trainer Manual Test Wrong Answers
                new TestWrongAnswer { TestWrongAnswerID = 31, TestQuestionID = 11, WrongAnswerText = "R250" },
                new TestWrongAnswer { TestWrongAnswerID = 32, TestQuestionID = 11, WrongAnswerText = "R150" },
                new TestWrongAnswer { TestWrongAnswerID = 33, TestQuestionID = 11, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 34, TestQuestionID = 12, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 35, TestQuestionID = 12, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 36, TestQuestionID = 12, WrongAnswerText = "R250" },
                new TestWrongAnswer { TestWrongAnswerID = 37, TestQuestionID = 13, WrongAnswerText = "75%" },
                new TestWrongAnswer { TestWrongAnswerID = 38, TestQuestionID = 13, WrongAnswerText = "95%" },
                new TestWrongAnswer { TestWrongAnswerID = 39, TestQuestionID = 13, WrongAnswerText = "90%" },
                new TestWrongAnswer { TestWrongAnswerID = 40, TestQuestionID = 14, WrongAnswerText = "25 personal adjusted pieces and 60% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 41, TestQuestionID = 14, WrongAnswerText = "20 personal adjusted pieces and 55% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 42, TestQuestionID = 14, WrongAnswerText = "30 personal adjusted pieces and 70% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 43, TestQuestionID = 15, WrongAnswerText = "R500" },
                new TestWrongAnswer { TestWrongAnswerID = 44, TestQuestionID = 15, WrongAnswerText = "R600" },
                new TestWrongAnswer { TestWrongAnswerID = 45, TestQuestionID = 15, WrongAnswerText = "R550" },
                new TestWrongAnswer { TestWrongAnswerID = 46, TestQuestionID = 16, WrongAnswerText = "15 days" },
                new TestWrongAnswer { TestWrongAnswerID = 47, TestQuestionID = 16, WrongAnswerText = "25 days" },
                new TestWrongAnswer { TestWrongAnswerID = 48, TestQuestionID = 16, WrongAnswerText = "10 days" },
                new TestWrongAnswer { TestWrongAnswerID = 49, TestQuestionID = 17, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 50, TestQuestionID = 17, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 51, TestQuestionID = 17, WrongAnswerText = "R200" },
                new TestWrongAnswer { TestWrongAnswerID = 52, TestQuestionID = 18, WrongAnswerText = "20" },
                new TestWrongAnswer { TestWrongAnswerID = 53, TestQuestionID = 18, WrongAnswerText = "25" },
                new TestWrongAnswer { TestWrongAnswerID = 54, TestQuestionID = 18, WrongAnswerText = "15" },
                new TestWrongAnswer { TestWrongAnswerID = 55, TestQuestionID = 19, WrongAnswerText = "R500" },
                new TestWrongAnswer { TestWrongAnswerID = 56, TestQuestionID = 19, WrongAnswerText = "R600" },
                new TestWrongAnswer { TestWrongAnswerID = 57, TestQuestionID = 19, WrongAnswerText = "R450" },
                new TestWrongAnswer { TestWrongAnswerID = 58, TestQuestionID = 20, WrongAnswerText = "100 to 119 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 59, TestQuestionID = 20, WrongAnswerText = "150 to 179 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 60, TestQuestionID = 20, WrongAnswerText = "90 to 119 minutes" },

                // Owner's Manual Test Wrong Answers
                new TestWrongAnswer { TestWrongAnswerID = 61, TestQuestionID = 21, WrongAnswerText = "R150" },
                new TestWrongAnswer { TestWrongAnswerID = 62, TestQuestionID = 21, WrongAnswerText = "R250" },
                new TestWrongAnswer { TestWrongAnswerID = 63, TestQuestionID = 21, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 64, TestQuestionID = 22, WrongAnswerText = "R350" },
                new TestWrongAnswer { TestWrongAnswerID = 65, TestQuestionID = 22, WrongAnswerText = "R250" },
                new TestWrongAnswer { TestWrongAnswerID = 66, TestQuestionID = 22, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 67, TestQuestionID = 23, WrongAnswerText = "60%" },
                new TestWrongAnswer { TestWrongAnswerID = 68, TestQuestionID = 23, WrongAnswerText = "40%" },
                new TestWrongAnswer { TestWrongAnswerID = 69, TestQuestionID = 23, WrongAnswerText = "70%" },
                new TestWrongAnswer { TestWrongAnswerID = 70, TestQuestionID = 24, WrongAnswerText = "15 personal adjusted pieces and 60% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 71, TestQuestionID = 24, WrongAnswerText = "17 personal adjusted pieces and 55% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 72, TestQuestionID = 24, WrongAnswerText = "18 personal adjusted pieces and 70% SR" },
                new TestWrongAnswer { TestWrongAnswerID = 73, TestQuestionID = 25, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 74, TestQuestionID = 25, WrongAnswerText = "R500" },
                new TestWrongAnswer { TestWrongAnswerID = 75, TestQuestionID = 25, WrongAnswerText = "R350" },
                new TestWrongAnswer { TestWrongAnswerID = 76, TestQuestionID = 26, WrongAnswerText = "15 days" },
                new TestWrongAnswer { TestWrongAnswerID = 77, TestQuestionID = 26, WrongAnswerText = "25 days" },
                new TestWrongAnswer { TestWrongAnswerID = 78, TestQuestionID = 26, WrongAnswerText = "10 days" },
                new TestWrongAnswer { TestWrongAnswerID = 79, TestQuestionID = 27, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 80, TestQuestionID = 27, WrongAnswerText = "R400" },
                new TestWrongAnswer { TestWrongAnswerID = 81, TestQuestionID = 27, WrongAnswerText = "R200" },
                new TestWrongAnswer { TestWrongAnswerID = 82, TestQuestionID = 28, WrongAnswerText = "15" },
                new TestWrongAnswer { TestWrongAnswerID = 83, TestQuestionID = 28, WrongAnswerText = "20" },
                new TestWrongAnswer { TestWrongAnswerID = 84, TestQuestionID = 28, WrongAnswerText = "25" },
                new TestWrongAnswer { TestWrongAnswerID = 85, TestQuestionID = 29, WrongAnswerText = "R350" },
                new TestWrongAnswer { TestWrongAnswerID = 86, TestQuestionID = 29, WrongAnswerText = "R450" },
                new TestWrongAnswer { TestWrongAnswerID = 87, TestQuestionID = 29, WrongAnswerText = "R300" },
                new TestWrongAnswer { TestWrongAnswerID = 88, TestQuestionID = 30, WrongAnswerText = "100 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 89, TestQuestionID = 30, WrongAnswerText = "200 minutes" },
                new TestWrongAnswer { TestWrongAnswerID = 90, TestQuestionID = 30, WrongAnswerText = "120 minutes" }
            );

            // Seed data for TestAccess
            modelBuilder.Entity<TestAccess>().HasData(
                new TestAccess { TestID = 1, AgentLevelID = 1 }, // Trainee -> Sales Manual Test
                new TestAccess { TestID = 2, AgentLevelID = 2 }, // Trainer -> Trainer Manual Test
                new TestAccess { TestID = 3, AgentLevelID = 3 }  // Trainee Owner -> Owner's Manual Test
            );

            // Seed data for QueryStatus
            modelBuilder.Entity<QueryStatus>().HasData(
                new QueryStatus { QueryStatusID = 1, StatusName = "Open" },
                new QueryStatus { QueryStatusID = 2, StatusName = "In Progress" },
                new QueryStatus { QueryStatusID = 3, StatusName = "Closed" }
            );

            // Seed data for AgentStatus
            modelBuilder.Entity<AgentStatus>().HasData(
                new AgentStatus { AgentStatusID = 1, StatusDescription = "Active" },
                new AgentStatus { AgentStatusID = 2, StatusDescription = "Inactive" }
            );

            // Seed data for SaleChannel
            modelBuilder.Entity<SalesChannel>().HasData(
                new SalesChannel { SalesChannelID = 1, ChannelDescription = "Telesale" },
                new SalesChannel { SalesChannelID = 2, ChannelDescription = "Face-to-Face" }
            );

            // Seed data for Schedule
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { ScheduleID = 1, Description = "Weekly" },
                new Schedule { ScheduleID = 2, Description = "Monthly" }
            );


            // Seed data for UserProfile
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile { UserProfileID = 1, ProfileDescription = "System Administrator" },
                new UserProfile { UserProfileID = 2, ProfileDescription = "Payroll Manager" },
                new UserProfile { UserProfileID = 3, ProfileDescription = "User" },
                new UserProfile { UserProfileID = 4, ProfileDescription = "Super User" },
                new UserProfile { UserProfileID = 5, ProfileDescription = "Owner" },
                new UserProfile { UserProfileID = 6, ProfileDescription = "Agent User" }
            );

            // Seed data for PROVINCE
            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceID = 1, ProvinceName = "NW" },
                new Province { ProvinceID = 2, ProvinceName = "NC" },
                new Province { ProvinceID = 3, ProvinceName = "FS" },
                new Province { ProvinceID = 4, ProvinceName = "WC" },
                new Province { ProvinceID = 5, ProvinceName = "EC" },
                new Province { ProvinceID = 6, ProvinceName = "KZN" },
                new Province { ProvinceID = 7, ProvinceName = "MP" },
                new Province { ProvinceID = 8, ProvinceName = "GP" },
                new Province { ProvinceID = 9, ProvinceName = "L" }
            );

            // Seed data for office
            modelBuilder.Entity<Office>().HasData(
                new Office { OfficeId = 1, OfficeCode = 1, OfficeLocation = "NW", OwnerID = 1 },
                new Office { OfficeId = 2, OfficeCode = 2, OfficeLocation = "L", OwnerID = 2 },
                new Office { OfficeId = 3, OfficeCode = 3, OfficeLocation = "GP", OwnerID = 3 }
            );

            // Seed data for OwnerType
            modelBuilder.Entity<OwnerType>().HasData(
                new OwnerType { OwnerTypeID = 1, TypeDescription = "Promotional owner" },
                new OwnerType { OwnerTypeID = 2, TypeDescription = "Trainer Owner" },
                new OwnerType { OwnerTypeID = 3, TypeDescription = "Divisional Owner" }
            );

            // Seed data for OwnerType
            modelBuilder.Entity<Owner>().HasData(
                new Owner { OwnerID = 1, OwnerName = "Promotional owner", OwnerTypeID = 1 },
                new Owner { OwnerID = 2, OwnerName = "Trainer Owner", OwnerTypeID = 2 },
                new Owner { OwnerID = 3, OwnerName = "Divisional Owner", OwnerTypeID = 3 }
            );

            // Seed data for ParentLevel
            modelBuilder.Entity<ParentLevel>().HasData(
                new ParentLevel { ParentLevelID = 1, Description = "Trainer" },
                new ParentLevel { ParentLevelID = 2, Description = "Trainer Owner" },
                new ParentLevel { ParentLevelID = 3, Description = "Promoting Owner" },
                new ParentLevel { ParentLevelID = 4, Description = "Divisional Owner" },
                new ParentLevel { ParentLevelID = 5, Description = "Vice President" }
            );

            // Seed data for EarnedType
            modelBuilder.Entity<EarnedType>().HasData(
                new EarnedType { EarnedTypeID = 1, Description = "Commissions" },
                new EarnedType { EarnedTypeID = 2, Description = "Overrides" },
                new EarnedType { EarnedTypeID = 3, Description = "Guaranteed Commission" },
                new EarnedType { EarnedTypeID = 4, Description = "Attendance Bonus" },
                new EarnedType { EarnedTypeID = 5, Description = "Performance Bonus" }
            );

            // Seed data for ProductCategory
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryID = 1, CategoryName = "Motor" },
                new ProductCategory { ProductCategoryID = 2, CategoryName = "Non-Motor" },
                new ProductCategory { ProductCategoryID = 3, CategoryName = "Persal" }
            );

            //Seed data for CommissionStatus
            modelBuilder.Entity<CommissionStatus>().HasData(
                 new CommissionStatus { CommissionStatusID = 1, Description = "Pending" },
                 new CommissionStatus { CommissionStatusID = 2, Description = "Approved" },
                 new CommissionStatus { CommissionStatusID = 3, Description = "Rejected" }

                                                         );

            base.OnModelCreating(modelBuilder);
        }
    }
}
