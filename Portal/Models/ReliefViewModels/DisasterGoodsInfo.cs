using Portal.Models.Donation;

namespace Portal.Models.ReliefViewModels
{
    public class DisasterGoodsInfo
    {
        public Disaster DisasterVM { get; set; }
        public Good GoodVM { get; set; }
        public Category CategoryVM { get; set; }
        public GoodsPurchase GoodsPurchaseVM { get; set; }
    }
}
