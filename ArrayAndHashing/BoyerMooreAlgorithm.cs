using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ArrayAndHashing
{
    public class BoyerMooreAlgorithm
    {
        public List<int> MajorityElementTwo(List<int> nums)
        {
            // We can have at most 2 elements appearing more than n/3 times
            int candidate1 = 0, count1 = 0;
            int candidate2 = 0, count2 = 0;

            // -------- First Pass: Find potential candidates --------
            for (int i = 0; i < nums.Count(); i++)
            {
                // If current number matches candidate1, increase its count
                if (candidate1 == nums[i])
                {
                    count1++;
                }
                // If current number matches candidate2, increase its count
                else if (candidate2 == nums[i])
                {
                    count2++;
                }
                // If count1 is 0, assign new candidate1
                else if (count1 == 0)
                {
                    candidate1 = nums[i];
                    count1 = 1;
                }
                // If count2 is 0, assign new candidate2
                else if (count2 == 0)
                {
                    candidate2 = nums[i];
                    count2 = 1;
                }
                // If current number is different from both candidates,
                // reduce both counts (cancel out 3 distinct elements)
                else
                {
                    count1--;
                    count2--;
                }
            }

            // -------- Second Pass: Verify actual counts --------
            count1 = 0;
            count2 = 0;

            foreach (var num in nums)
            {
                // Count occurrences of candidate1
                if (num == candidate1) count1++;

                // Count occurrences of candidate2
                if (num == candidate2) count2++;
            }

            // -------- Collect results --------
            var list = new List<int>();
            int target = nums.Count() / 3;

            // Only add if frequency is strictly greater than n/3
            if (count1 > target) list.Add(candidate1);
            if (candidate2 != candidate1 && count2 > target) list.Add(candidate2);

            return list;
        }
    }
}
