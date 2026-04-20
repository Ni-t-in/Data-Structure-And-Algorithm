using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class MinimumInRotatedSortedArray
    {
        public int findMin(int[] arr)
        {
            // Initialize search boundaries
            int low = 0;
            int high = arr.Length - 1;

            // Loop until the search space reduces to one element
            while (low < high)
            {
                // Compute mid safely to avoid overflow
                int mid = low + (high - low) / 2;

                // Case 1: Duplicate ambiguity
                // If mid and high are equal, we cannot decide which side is sorted
                if (arr[mid] == arr[high])
                {
                    // Reduce search space from the right
                    // This does not lose the minimum because mid == high
                    high--;
                    continue;
                }

                // Case 2: Right half is unsorted (pivot lies here)
                // If mid > high, minimum must be in the right half
                if (arr[mid] > arr[high])
                {
                    // Eliminate left half including mid
                    low = mid + 1;
                }
                else
                {
                    // Case 3: Right half is sorted
                    // Minimum lies in left half including mid
                    // We keep mid because it could be the minimum
                    high = mid;
                }
            }

            // At the end, low == high, pointing to the minimum element
            return arr[low];
        }
    }
}
