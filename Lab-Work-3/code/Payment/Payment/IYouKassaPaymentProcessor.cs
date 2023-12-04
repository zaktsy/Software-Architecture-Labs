namespace Payment.Payment;

public interface IYouKassaPaymentProcessor
{
    public string SendRequestForPayment(double subscriptionPrice);
}