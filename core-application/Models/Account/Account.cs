namespace core_application.Models.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public double Balance { get; set; }
        public List<OldBalance> OldBalances { get; set; }

    }
}
