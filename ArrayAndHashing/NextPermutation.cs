using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class NextPermutation
    {
        public List<int> NextPermutationProblem(List<int> nums)
        {
            int index = -1;
            int length = nums.Count;

            // Step 1: Find the "breakpoint"
            // Traverse from right and find first element where nums[i] > nums[i-1]
            // This indicates the place where we can make a bigger permutation
            for (int i = length - 1; i >= 1; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    index = i - 1;
                    break;
                }
            }

            // Step 2: If no breakpoint found, array is in descending order
            // This is the last permutation, so reverse to get the smallest permutation
            if (index == -1)
            {
                nums.Reverse();
                return nums;
            }

            // Step 3: Find the next greater element than nums[index] from the right
            // Swap it to make the number just slightly larger
            for (int j = length - 1; j > index; j--)
            {
                if (nums[j] > nums[index])
                {
                    (nums[index], nums[j]) = (nums[j], nums[index]);
                    break;
                }
            }

            // Step 4: Reverse the suffix (elements after index)
            // This ensures we get the smallest possible order after the swap
            int left = index + 1;
            int right = length - 1;

            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }

            return nums;
        }
    }
}
