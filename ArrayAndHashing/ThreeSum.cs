using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class ThreeSum
    {
        public IList<IList<int>> ThreeSumProblem(int[] nums)
        {
            // This will store all unique triplets
            List<IList<int>> list = new List<IList<int>>();

            // Step 1: Sort the array (important for two-pointer + duplicate handling)
            Array.Sort(nums);

            // Step 2: Fix one element and find remaining two using two pointers
            for (int i = 0; i < nums.Length; i++)
            {

                // Skip duplicate elements for 'i' to avoid duplicate triplets
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                // Initialize two pointers
                int left = i + 1;
                int right = nums.Length - 1;

                // Step 3: Two pointer approach
                while (left < right)
                {

                    int sum = nums[i] + nums[left] + nums[right];

                    // Case 1: Found a triplet
                    if (sum == 0)
                    {
                        list.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Skip duplicates for 'left'
                        while (left < right && nums[left] == nums[left + 1]) left++;

                        // Skip duplicates for 'right'
                        while (right > left && nums[right] == nums[right - 1]) right--;

                        // Move both pointers inward
                        left++;
                        right--;
                    }
                    // Case 2: Sum is too small → increase it
                    else if (sum < 0)
                    {
                        left++;
                    }
                    // Case 3: Sum is too large → decrease it
                    else
                    {
                        right--;
                    }
                }
            }

            // Return all unique triplets
            return list;
        }
    }
}
