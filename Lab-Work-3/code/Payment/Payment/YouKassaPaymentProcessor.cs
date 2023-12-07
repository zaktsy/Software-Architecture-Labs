namespace Payment.Payment;

public class YouKassaPaymentProcessor : IYouKassaPaymentProcessor
{
    public YouKassaPaymentProcessor()
    {
        SubscribeForEvents();
    }

    public string SendRequestForPayment(double subscriptionPrice)
    {
        /* Опустим конструирование и отправку апросов на апи ЮКассы.
         * Для оплаты требуется сформировать за проведение платежа, указал при этом свой paymentId (он нам пригодится).
         * В качестве ответа от Апи получается строка для редиректа пользователя для оплаты.
         */

        return "redirect-string";
    }

    private void SubscribeForEvents()
    {
        /*Для отслеживания информации об оплате необходимо подписаться на уведомления с помощью веб хуков.
         * Подписываемся с использованием paymentId на получения уведомление об успешной оплате.
         * Для этого указываем URL запроса ChangeSubscriptionStatusToActive.
         * Именно на него придет запрос с информацией об оплате
         */
    }
}