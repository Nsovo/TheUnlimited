using TheUnlimited_Backend_.Models;

namespace TheUnlimited_Backend_.ViewModels
{
    public class CommissionService
    {
        private readonly List<Commission> _commissions;


        public CommissionService()
        {
            _commissions = new List<Commission>
        {

        };
        }
        //public Commission CalculateCommission(Agent agent, ProductCategory productCategory, ProductSales productSales, Product product)
        //{
        //    // Example commission calculation logic
        //    decimal commission = 0;
        //    int debiCheck = 0;
        //    int debiCheckPercentage = 0;
        //    decimal totalCommission = 0;
        //    int numberOfTradingDays = 0;
        //    int GuaranteedCommission = 0;
        //    int motorSR = 60;
        //    int persalSR = 85;
        //    int nonMotor = 50;


        //    if (productCategory.CategoryName == "Motor")
        //    {
        //        if (debiCheckPercentage > 40)
        //        {
        //            debiCheck = 450;
        //            commission = productSales.SalesAmount * debiCheck;

        //        }
        //        else
        //        {
        //            debiCheck = 350;
        //            commission = productSales.SalesAmount * debiCheck;

        //        }
        //    }
        //    if (productCategory.CategoryName == "Persal")
        //    {
        //        if (debiCheckPercentage > 40)
        //        {
        //            debiCheck = 475;
        //            commission = productSales.SalesAmount * debiCheck;
        //        }
        //        else
        //        {
        //            debiCheck = 350;
        //            commission = productSales.SalesAmount * debiCheck;
        //        }
        //    }

        //    if (productCategory.CategoryName == "Non-Motor")
        //    {
        //        if (debiCheckPercentage > 40)
        //        {
        //            debiCheck = 450;
        //            commission = productSales.SalesAmount * debiCheck;
        //        }
        //        else
        //        {
        //            debiCheck = 350;
        //            commission = productSales.SalesAmount * debiCheck;
        //        }
        //    }

        //    GuaranteedCommission = 200 * numberOfTradingDays;
        //    totalCommission = GuaranteedCommission + commission;

        //    var commissionResult = new Commission
        //    {
        //        AgentID = agent.AgentID,
        //        ProductID = product.ProductID,
        //        EarnedAmount = totalCommission
        //    };

        //    _commissions.Add(commissionResult);

        //    return commissionResult;

        //}

        public Commission CalculateCommission(Agent agent, ProductCategory productCategory, ProductSales productSales, Product product, int debiCheckPercentage, int numberOfTradingDays)
        {
            decimal commission = 0;
            int debiCheck = 0;
            decimal totalCommission = 0;
            int motorSR = 60;
            int persalSR = 85;
            int nonMotor = 50;

            if (productCategory.CategoryName == "Motor")
            {
                debiCheck = debiCheckPercentage > 40 ? 450 : 350;
                commission = productSales.SalesAmount * debiCheck;
            }
            else if (productCategory.CategoryName == "Persal")
            {
                debiCheck = debiCheckPercentage > 40 ? 475 : 350;
                commission = productSales.SalesAmount * debiCheck;
            }
            else if (productCategory.CategoryName == "Non-Motor")
            {
                debiCheck = debiCheckPercentage > 40 ? 450 : 350;
                commission = productSales.SalesAmount * debiCheck;
            }

            int guaranteedCommission = 200 * numberOfTradingDays;
            totalCommission = guaranteedCommission + commission;

            var commissionResult = new Commission
            {
                AgentID = agent.AgentID,
                //ProductID = product.ProductID,
                //EarnedAmount = totalCommission
            };

            _commissions.Add(commissionResult);

            return commissionResult;
        }

        public IEnumerable<Commission> GetAllCommissions()
        {
            return _commissions;
        }
    }
}
