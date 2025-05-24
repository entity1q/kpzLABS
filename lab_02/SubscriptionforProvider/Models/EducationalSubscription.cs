using System;
namespace SubscriptionforProvider.Models
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 5.99m;
            MinimumSubscriptionPeriod = 2;
            Channels = new List<string> { "Світ +", "Мега" };
            Features = new List<string> { "Access to Courses", "Ads Free" };
        }
    }

}

