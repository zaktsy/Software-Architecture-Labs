using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Payment.Payment;
using Payment.Subscription;
using Payment.User;

namespace Payment.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentService _paymentService;

    public SubscriptionController(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository,
        IPaymentService paymentService)
    {
        _subscriptionRepository = subscriptionRepository;
        _userRepository = userRepository;
        _paymentService = paymentService;
    }

    [HttpPut(Name = "Subscription")]
    public IActionResult Subscribe(Guid userId)
    {
        string redirectUrl;
        try
        {
            var subscriptionPrice = _subscriptionRepository.GetSubscriptionPrice(userId);
            redirectUrl = _paymentService.RequestSubscriptionPayment(subscriptionPrice);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        return Redirect(redirectUrl);
    }

    [HttpPatch(Name = "ChangeSubscriptionStatusToActive")]
    public IActionResult ChangeSubscriptionStatusToActive([FromBody] JObject json)
    {
        try
        {
            var paymentId = (json["object"] ?? Guid.Empty).Select(token => token["id"].Value<Guid>()).First();

            var userId = _paymentService.GetPaymentOwner(paymentId);

            if (userId != Guid.Empty)
                _userRepository.TryChangeSubscriptionStatus(userId, true);
        }
        catch(Exception ex)
        {
            // можно было бы добавить логгирования, но мы не будем для упрощения.
        }

        return Ok();
    }
}