using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class RotatedSortedArray
    {
        public bool searchInARotatedSortedArrayII(List<int> nums, int k)
        {
            // Initialize pointers for the search space
            int low = 0;
            int high = nums.Count - 1;

            // Continue while the search space is valid
            while (low <= high)
            {
                // Compute mid safely to avoid overflow
                int mid = low + (high - low) / 2;

                // Case 1: Target found
                if (nums[mid] == k)
                    return true;

                // Case 2: Duplicate ambiguity
                // If low, mid, and high all have the same value,
                // we cannot determine which half is sorted.
                if (nums[low] == nums[mid] && nums[mid] == nums[high])
                {
                    // Shrink the search space from both ends
                    // because these values do not provide useful information
                    low++;
                    high--;
                    continue; // Skip further checks in this iteration
                }

                // Case 3: Left half is sorted
                // If nums[low] <= nums[mid], left portion is sorted
                if (nums[low] <= nums[mid])
                {
                    // Check if target lies within the sorted left half
                    if (k >= nums[low] && k < nums[mid])
                    {
                        // Target is in left half, eliminate right half
                        high = mid - 1;
                    }
                    else
                    {
                        // Target is not in left half, move to right half
                        low = mid + 1;
                    }
                }
                else
                {
                    // Case 4: Right half is sorted

                    // Check if target lies within the sorted right half
                    if (k > nums[mid] && k <= nums[high])
                    {
                        // Target is in right half, eliminate left half
                        low = mid + 1;
                    }
                    else
                    {
                        // Target is not in right half, move to left half
                        high = mid - 1;
                    }
                }
            }

            // Target not found
            return false;
        }
    }
}
