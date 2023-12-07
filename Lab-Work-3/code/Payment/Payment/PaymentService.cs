namespace Payment.Payment;

internal class PaymentService : IPaymentService
{
    private readonly IPaymentsRepository _paymentsRepository;
    private readonly IYouKassaPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentsRepository paymentsRepository, IYouKassaPaymentProcessor paymentProcessor)
    {
        _paymentsRepository = paymentsRepository;
        _paymentProcessor = paymentProcessor;
    }

    public string RequestSubscriptionPayment(double subscriptionPrice)
    {
        var redirectUrl = _paymentProcessor.SendRequestForPayment(subscriptionPrice);

        return redirectUrl;
    }

    public Guid GetPaymentOwner(Guid paymentId)
    {
        var ownerId = _paymentsRepository.GetPaymentOwner(paymentId);

        return ownerId;
    }

    public void AddPaymentOwner(Guid paymentId, Guid ownerId)
    {
        _paymentsRepository.AddPaymentOwner(paymentId, ownerId);
    }
}