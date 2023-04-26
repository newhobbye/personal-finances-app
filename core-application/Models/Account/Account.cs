namespace core_application.Models.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<OldBalance> OldBalances { get; set; }

        public Account()
        {
            Id = new Guid();
            OldBalances = new List<OldBalance>();
        }
    }
}
