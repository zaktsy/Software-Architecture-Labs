using System.Collections.Concurrent;

namespace Payment.Payment;

public class InMemoryPaymentRepository : IPaymentsRepository
{
    private readonly ConcurrentDictionary<Guid, Guid> _userIdsByPaymentIds = new();

    public Guid GetPaymentOwner(Guid paymentId)
    {
        var isUserFound = _userIdsByPaymentIds.TryGetValue(paymentId, out var userId);
        return isUserFound ? userId : Guid.Empty;
    }

    public void AddPaymentOwner(Guid paymentId, Guid userId)
    {
        _userIdsByPaymentIds.TryAdd(paymentId, userId);
    }
}