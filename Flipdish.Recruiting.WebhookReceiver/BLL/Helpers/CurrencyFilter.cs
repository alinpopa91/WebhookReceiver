
namespace Flipdish.Recruiting.WebhookReceiver.BLL.Helpers
{
    public static class CurrencyFilter
    {
        public static string currency(decimal input)
        {
            return input.ToString("N2");
        }
    }
}
