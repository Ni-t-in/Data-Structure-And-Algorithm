using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class KokoEatingBananas
    {
        public int MinimumRateToEatBananas(List<int> nums, int h)
        {
            // Minimum possible eating speed (can't be less than 1)
            int min = 1;
            
            // Maximum possible eating speed (no need to go beyond largest pile)
            int max = nums.Max();

            // Binary search on answer (k)
            while (min < max)
            {
                // Standard mid calculation (avoids overflow)
                int mid = min + (max - min) / 2;

                int hours = 0;

                // Calculate total hours required at speed = mid
                foreach (int pile in nums)
                {
                    // Ceil division to compute hours for this pile
                    // Example: pile = 7, mid = 5 → needs 2 hours
                    hours += (pile + mid - 1) / mid;
                }

                if (hours <= h)
                {
                    // If we can finish within h hours,
                    // try to minimize speed further
                    max = mid;
                }
                else
                {
                    // Too slow → need to increase speed
                    min = mid + 1;
                }
            }

            // When loop ends, min == max → minimum valid speed
            return min;
        }
    }
}
