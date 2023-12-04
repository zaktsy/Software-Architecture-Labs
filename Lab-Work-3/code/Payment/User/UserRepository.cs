namespace Payment.User;

public class UserRepository : IUserRepository
{
    public bool TryChangeSubscriptionStatus(Guid userId, bool subscriptionStatus)
    {
        // Тут должен быть просто запрос к БД с изменением статуса подписки пользователя.

        return true;
    }
}