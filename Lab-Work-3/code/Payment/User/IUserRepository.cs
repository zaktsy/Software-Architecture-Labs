namespace Payment.User;

public interface IUserRepository
{
    bool TryChangeSubscriptionStatus(Guid userId, bool subscriptionStatus);
}