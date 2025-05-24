using System;
namespace SubscriptionforProvider.Models
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            MonthlyFee = 9.99m;
            MinimumSubscriptionPeriod = 1;
            Channels = new List<string> { "Новий канал", "Тет" };
            Features = new List<string> { "HD Streaming", "Ads" };
        }
    }

}

