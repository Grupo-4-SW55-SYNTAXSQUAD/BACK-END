
namespace peru_ventura_center.Payments.Domain.Model.Aggregates
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate {  get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentState PaymentState { get; set; }
        public int PaymentStateId { get; set; }
        public int PaymentTypeId { get; set; }

        public Payment(float Amount, DateTime PaymentDate, int PaymentTypeId, int PaymentStateId)
        {
            this.Amount = Amount;
            this.PaymentDate = PaymentDate;
            this.PaymentTypeId = PaymentTypeId;
            this.PaymentStateId = PaymentStateId;
        }

    }
}
