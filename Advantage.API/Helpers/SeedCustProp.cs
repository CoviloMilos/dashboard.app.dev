using System;
using System.Collections.Generic;

namespace Advantage.API.Helpers
{
    public class SeedCustProp
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }
        internal static string MakeUniqueCustomerNameSeed(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSuffix.Count;

            if (names.Count >= maxNames) 
            {
                throw new System.InvalidOperationException("Maximum number of unique names exceeded");
            }

            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName = prefix + " " + suffix;

            if  (names.Contains(bizName)){
                // recursion :)
                MakeUniqueCustomerNameSeed(names);
            }
            return bizName;
        }

        internal static string MakeCustomerEmailSeed(string custname)
        {
            return $"contact@{custname.Replace(" ", "").ToLower()}.com";
        }

        internal static string GetRadnomStateSeed()
        {
            return GetRandom(usStates);
        }

        internal static string GetRandomRoleSeed()
        {
            return GetRandom(currentroles);
        }

        internal static int GetRandomOrderTotalSeed() 
        {
            return _rand.Next(100, 5000);
        }

        internal static DateTime GetRandomOrderPlacedSeed() 
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int) possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }
        internal static DateTime? GetRandomOrderCompletedSeed(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;

            if (timePassed < minLeadTime) 
            {
                return null;
            }

            return orderPlaced.AddDays(_rand.Next(7, 14));

        }
        private static readonly List<string> currentroles = new List<string>()
        {
            "Admin", "Customer", "Moderator", "Director"
        };
        private static readonly List<string> usStates = new List<string>() 
        {
            "AK", "AL","AZ",  "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
        };
        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "MainSt",
            "Sales",
            "Enterprise",
            "Ready",
            "Quick",
            "Peak",
            "Magic",
            "Family",
            "Comfor"
        };
        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Corporation",
            "Co",
            "Bakery",
            "Goods",
            "Hotels",
            "Foods",
            "Cleanrs",
            "Doo",
            "CTO",
            "Company",
            "Firm"
        };
    }
}