namespace Payment.Payment;

internal interface IPaymentsRepository
{
    Guid GetPaymentOwner(Guid paymentId);

    void AddPaymentOwner(Guid paymentId, Guid userId);
}