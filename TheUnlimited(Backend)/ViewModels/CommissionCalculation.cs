using TheUnlimited_Backend_.Models;

namespace TheUnlimited_Backend_.ViewModels
{
    public class CommissionCalculation
    {

        public class Agent
        {
            public int AgentID { get; set; }
            public string AgentName { get; set; }
            public ICollection<ProductSales> ProductSales { get; set; }
            public ICollection<Commission> Commissions { get; set; }
        }

        public class AgentStatus
        {
            public int AgentStatusID { get; set; }
            public string AgentStatusName { get; set; }
        }

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
        }

        public class SalesChannel
        {
            public int SalesChannelID { get; set; }
            public string ChannelDescription { get; set; }
            public ICollection<ProductSales> ProductSales { get; set; }
            public ICollection<Agent> Agents { get; set; }
        }

        public class ProductSales
        {
            public int ProductSalesID { get; set; }
            public int AgentID { get; set; }
            public int ProductID { get; set; }
            public decimal SalesAmount { get; set; }
            public DateTime SalesDate { get; set; }
            public int SalesChannelID { get; set; }
            public Agent Agent { get; set; }
            public Product Product { get; set; }
            public SalesChannel SalesChannel { get; set; }
            public ICollection<Commission> Commissions { get; set; }
        }

        public class ProductCategory
        {
            public int ProductCategoryID { get; set; }
            public string CategoryName { get; set; }
            public int RateMoreThan40 { get; set; }
            public int RateLessThan40 { get; set; }
            public ICollection<Product> Products { get; set; }
            public ICollection<Commission> Commissions { get; set; }
        }

        public class Commission
        {
            public int CommissionID { get; set; }
            public int MerchCode { get; set; }
            public int AgentID { get; set; }
            public int AgentStatusID { get; set; }
            public int ProductSalesID { get; set; }
            public int ProductID { get; set; }
           public int AgentLevelID { get; set; }

            public decimal Sales { get; set; }
            public int GuaranteedCommission { get; set; }
            public int Override { get; set; }
            public decimal Commissions { get; set; }
            public decimal TotalEarnings { get; set; }

            public string AgentType { get; set; }
            public decimal DebiCheckPercentage { get; set; }
            public decimal SR { get; set; }
            public bool IsTrainer { get; set; }
            public bool IsTrainerOwner { get; set; }
            public int SalesCount { get; set; }

            public Agent Agent { get; set; }
            public AgentStatus AgentStatus { get; set; }
            public ProductSales ProductSales { get; set; }
            public Product Product { get; set; }
            public ProductCategory ProductCategory { get; set; }
            public AgentLevel AgentLevel { get; set; }

            public void CalculateCommission()
            {
                // Check agent type
                if (AgentType == "Telesale" || AgentType == "Face-to-Face")
                {
                    switch (ProductCategory.CategoryName)
                    {
                        case "Motor":
                            CalculateMotorCommission();
                            break;
                        case "Persal":
                            CalculatePersalCommission();
                            break;
                        case "Persal Code Upgrade":
                            CalculatePersalCodeUpgradeCommission();
                            break;
                        case "Persal STD Upgrade":
                            CalculatePersalSTDUpgradeCommission();
                            break;
                        case "Persal Gap":
                            CalculatePersalGapCommission();
                            break;
                        case "Persal STD Gap Upgrade":
                            CalculatePersalSTDGapUpgradeCommission();
                            break;
                        case "Persal Code Gap Upgrade":
                            CalculatePersalCodeGapUpgradeCommission();
                            break;
                        case "Debit Order Insurance":
                            CalculateDebitOrderInsuranceCommission();
                            break;
                    }
                }
            }

            private void CalculateMotorCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 2000;
                }
                else
                {
                    if (SalesCount < 20)
                    {
                        GuaranteedCommission = SalesCount * 200;
                    }
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 24 ? SalesCount * 250 : SalesCount * 350;
                }
                else
                {
                    Commissions = SalesCount < 24 ? SalesCount * 350 : SalesCount * 450;
                }

                if (IsTrainer && SalesCount >= 19 && SR >= 50)
                {
                    Override = SalesCount * 40;
                }
                if (IsTrainerOwner && SalesCount >= 19 && SR >= 50)
                {
                    Override = SalesCount * 60;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculatePersalCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    if (Agent.AgentName == "Christy")
                    {
                        GuaranteedCommission = 20 * 200;
                    }
                    else if (Agent.AgentName == "Leo")
                    {
                        GuaranteedCommission = 16 * 200;
                    }
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 17 ? SalesCount * 350 : SalesCount * 475;
                }
                else
                {
                    Commissions = SalesCount < 17 ? SalesCount * 350 : SalesCount * 475;
                }

                if (IsTrainer && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 45;
                }
                if (IsTrainerOwner && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 65;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculatePersalCodeUpgradeCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 20 * 200;
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 17 ? SalesCount * 350 : SalesCount * 450;
                }
                else
                {
                    Commissions = SalesCount < 17 ? SalesCount * 350 : SalesCount * 450;
                }

                if (IsTrainer && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 45;
                }
                if (IsTrainerOwner && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 65;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculatePersalSTDUpgradeCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 20 * 200;
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 17 ? SalesCount * 350 : SalesCount * 450;
                }
                else
                {
                    Commissions = SalesCount < 17 ? SalesCount * 350 : SalesCount * 450;
                }

                if (IsTrainer && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 45;
                }
                if (IsTrainerOwner && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 65;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculatePersalGapCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 20 * 200;
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 17 ? SalesCount * 400 : SalesCount * 575;
                }
                else
                {
                    Commissions = SalesCount < 17 ? SalesCount * 400 : SalesCount * 575;
                }

                if (IsTrainer && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 45;
                }
                if (IsTrainerOwner && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 65;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculatePersalSTDGapUpgradeCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 20 * 200;
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 17 ? SalesCount * 400 : SalesCount * 550;
                }
                else
                {
                    Commissions = SalesCount < 17 ? SalesCount * 400 : SalesCount * 550;
                }

                if (IsTrainer && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 45;
                }
                if (IsTrainerOwner && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 65;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculatePersalCodeGapUpgradeCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 20 * 200;
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 17 ? SalesCount * 400 : SalesCount * 550;
                }
                else
                {
                    Commissions = SalesCount < 17 ? SalesCount * 400 : SalesCount * 550;
                }

                if (IsTrainer && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 45;
                }
                if (IsTrainerOwner && SalesCount >= 27 && SR >= 50)
                {
                    Override = SalesCount * 65;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }

            private void CalculateDebitOrderInsuranceCommission()
            {
                if (AgentStatusID == 1) // Assuming 1 means new
                {
                    GuaranteedCommission = 20 * 200;
                }

                if (DebiCheckPercentage < 40)
                {
                    Commissions = SalesCount < 20 ? SalesCount * 250 : SalesCount * 350;
                }
                else
                {
                    Commissions = SalesCount < 20 ? SalesCount * 350 : SalesCount * 450;
                }

                if (IsTrainer && SalesCount >= 16 && SR >= 50)
                {
                    Override = SalesCount * 40;
                }
                if (IsTrainerOwner && SalesCount >= 16 && SR >= 50)
                {
                    Override = SalesCount * 60;
                }

                TotalEarnings = GuaranteedCommission + Commissions + Override;
            }
        }
    }
}
