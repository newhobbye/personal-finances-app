using core_application.Models.Enums;

namespace core_application.Models.Deposits
{
    public class Deposit<GenericCategory>
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        GenericCategory Category { get; set; }
        public StatusPayment Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string Note { get; set; }
    }
}
