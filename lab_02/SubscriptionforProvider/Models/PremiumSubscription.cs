using System;
namespace SubscriptionforProvider.Models
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            MonthlyFee = 10.99m;
            MinimumSubscriptionPeriod = 1;
            Channels = new List<string> { "КС ТБ", "Cine +" };
            Features = new List<string> { "4K Streaming", "No Ads", "Exclusive Content" };
        }
    }

}

