using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ArrayAndHashing
{
    public class KadanesAlgorithm
    {
        public int MaxSubArraySum(List<int> nums)
        {
            // Initialize with first element
            int maxSoFar = nums[0];      // Final answer
            int currentSum = nums[0];    // Current subarray sum

            // Traverse from second element
            for (int i = 1; i < nums.Count; i++)
            {

                // Either:
                // 1. Start new subarray from current element
                // 2. Extend previous subarray
                currentSum = Math.Max(nums[i], currentSum + nums[i]);

                // Update global maximum
                maxSoFar = Math.Max(maxSoFar, currentSum);
            }
            return maxSoFar;
        }

        public List<int> MaxSubArrayWithElements(List<int> nums)
        {
            int maxSoFar = nums[0];
            int currentSum = nums[0];

            // To track indices
            int start = 0;        // final subarray start
            int end = 0;          // final subarray end
            int tempStart = 0;    // temporary start

            for (int i = 1; i < nums.Count; i++)
            {

                // Decide: start new OR continue
                if (nums[i] > currentSum + nums[i])
                {
                    currentSum = nums[i];
                    tempStart = i;   // new subarray starts here
                }
                else
                {
                    currentSum += nums[i];
                }

                // Update best result
                if (currentSum > maxSoFar)
                {
                    maxSoFar = currentSum;
                    start = tempStart;
                    end = i;
                }
            }

            // Build result subarray
            List<int> result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                result.Add(nums[i]);
            }

            return result;
        }
    }
}
