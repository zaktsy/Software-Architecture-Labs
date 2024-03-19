namespace Payment.Payment;

public interface IPaymentService
{
    string RequestSubscriptionPayment(double subscriptionPrice);

    Guid GetPaymentOwner(Guid paymentId);

    void AddPaymentOwner(Guid paymentId, Guid userId);
}