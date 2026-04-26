using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class AggressiveCowsProblem
    {
        public int AggressiveCows(int[] nums, int k)
        {
            // Sort stall positions so we can place cows linearly (greedy)
            Array.Sort(nums);

            int length = nums.Length;

            // Minimum possible distance between cows
            int start = 1;

            // Maximum possible distance (first to last stall)
            int end = nums[length - 1] - nums[0];

            // Binary search on answer (distance)
            while (start <= end)
            {
                // Mid represents the candidate minimum distance
                int mid = start + (end - start) / 2;

                // Place first cow at first stall
                int count = 1;
                int lastPlacedCow = nums[0];

                // Try placing remaining cows greedily
                for (int i = 1; i < length; i++)
                {
                    // If current stall is at least 'mid' distance away,
                    // place another cow here
                    if ((nums[i] - lastPlacedCow) >= mid)
                    {
                        lastPlacedCow = nums[i];
                        count++;
                    }
                }

                // If we can place at least k cows with this distance
                if (count >= k)
                {
                    // This distance is valid → try to maximize it
                    start = mid + 1;
                }
                else
                {
                    // Too large distance → reduce it
                    end = mid - 1;
                }
            }

            // 'end' will be the largest valid minimum distance
            return end;
        }
    }
}
