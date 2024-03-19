namespace Payment.Subscription;

public interface ISubscriptionRepository
{
    double GetSubscriptionPrice(Guid userId);
}