namespace Payment.Subscription;

public class SubscriptionRepository : ISubscriptionRepository
{
    public double GetSubscriptionPrice(Guid userId)
    {
        // Здесь располагается обращение к Маркетинговой БД для получения цены подписки для конкретного пользователя.

        return 0d;
    }
}