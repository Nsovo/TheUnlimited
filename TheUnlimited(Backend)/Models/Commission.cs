using System.ComponentModel.DataAnnotations.Schema;

namespace TheUnlimited_Backend_.Models
{
    public class Commission
    {
        public int CommissionID { get; set; }
        public int MerchCode { get; set; }
        public int AgentID { get; set; }
        public int AgentStatusID { get; set; }
        public int? ProductSalesID { get; set; }
        public int ProductID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sales { get; set; }
        public int GuaranteedCommission { get; set; }
        public int Override { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Commissions { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalEarnings { get; set; }
        public int? CommissionStatusID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DebiCheckPercentage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SR { get; set; }
        public bool IsTrainer { get; set; }
        public bool IsTrainerOwner { get; set; }
        public int SalesCount { get; set; }

        public Agent Agent { get; set; }
        public AgentStatus AgentStatus { get; set; }
        [ForeignKey("ProductSalesID")]
        public virtual ProductSales ProductSales { get; set; }
        public Product Product { get; set; }

        public int? SalesChannelID { get; set; }

        [ForeignKey("SalesChannelID")]
        public virtual SalesChannel SalesChannel { get; set; }

        [ForeignKey("CommissionStatusID")]
        public virtual CommissionStatus CommissionStatus { get; set; }
        //public AgentLevel AgentLevel { get; set; }
        public int? AgentLevelID { get; set; }

        [ForeignKey("AgentLevelID")]
        public virtual AgentLevel AgentLevel { get; set; }

        public int? ProductCategoryID { get; set; }
        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }



        public void CalculateCommission()
        {
            if (SalesChannel.ChannelDescription == "Telesale" || SalesChannel.ChannelDescription == "Face-to-Face")
            {
                switch (Product.ProductCategory.CategoryName)
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
            if (AgentID == 1)
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
            if (AgentID == 1)
            {
                if (Agent.Name == "Christy")
                {
                    GuaranteedCommission = 20 * 200;
                }
                else if (Agent.Name == "Leo")
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
            if (AgentID == 1)
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
            if (AgentID == 1)
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
            if (AgentID == 1)
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
            if (AgentID == 1)
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
            if (AgentID == 1)
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
            if (AgentID == 1)
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
//public int ProductCategoryID { get; set; }
//public AgentStatus AgentStatus { get; set; }
