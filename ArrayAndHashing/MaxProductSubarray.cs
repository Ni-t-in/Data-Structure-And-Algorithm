using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ArrayAndHashing
{
    public class MaxProductSubarray
    {
        public int MaxProduct(List<int> nums)
        {
            // maxSoFar → maximum product ending at current index
            // minSoFar → minimum product ending at current index
            // (important because a negative * negative can become max)
            int maxSoFar = nums[0];
            int minSoFar = nums[0];

            // Stores the overall maximum product found so far
            int result = nums[0];

            // Start from second element
            for (int i = 1; i < nums.Count; i++)
            {
                int num = nums[i];

                // If current number is negative, it flips the sign:
                // max becomes min and min becomes max
                if (num < 0)
                {
                    (maxSoFar, minSoFar) = (minSoFar, maxSoFar);
                }

                // Either:
                // 1. Start a new subarray from current number
                // 2. Extend previous max product
                maxSoFar = Math.Max(num, num * maxSoFar);

                // Track minimum as well (can become max later due to negative)
                minSoFar = Math.Min(num, num * minSoFar);

                // Update global result
                result = Math.Max(result, maxSoFar);
            }

            return result;
        }
    }
}
