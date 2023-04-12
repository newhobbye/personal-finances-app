namespace core_application.Models
{
    public class OldBalance
    {
        public Guid Id { get; set; }
        public int CodeAccount { get; set; }
        public double OldBalanceValue { get; set; }
        public DateTime BalanceDate { get; set; }
        public List<double> OldBalances { get; set; }
    }
}
