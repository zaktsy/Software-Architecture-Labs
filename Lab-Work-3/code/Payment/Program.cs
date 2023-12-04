using Payment.Payment;
using Payment.Subscription;
using Payment.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddSingleton<IPaymentsRepository, InMemoryPaymentRepository>();
builder.Services.AddSingleton<IYouKassaPaymentProcessor, YouKassaPaymentProcessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();