using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class MedianTwoSortedArrays
    {
        public double Median(List<int> arr1, List<int> arr2)
        {
            int m = arr1.Count;
            int n = arr2.Count;

            // Always binary search on the smaller array
            // to keep complexity O(log(min(m,n)))
            if (m > n) return Median(arr2, arr1);

            int start = 0;
            int end = m;

            // Binary search on partition index of arr1
            while (start <= end)
            {
                // cut1 = number of elements taken from arr1 into LEFT partition
                int cut1 = start + (end - start) / 2;

                // cut2 = remaining elements needed from arr2
                // so that LEFT partition has (m+n+1)/2 elements
                int cut2 = (m + n + 1) / 2 - cut1;

                // l1, r1 → boundary elements around cut1 in arr1
                // If nothing on left → use -∞ (int.MinValue)
                // If nothing on right → use +∞ (int.MaxValue)
                int l1 = (cut1 == 0) ? int.MinValue : arr1[cut1 - 1];
                int r1 = (cut1 == m) ? int.MaxValue : arr1[cut1];

                // l2, r2 → boundary elements around cut2 in arr2
                int l2 = (cut2 == 0) ? int.MinValue : arr2[cut2 - 1];
                int r2 = (cut2 == n) ? int.MaxValue : arr2[cut2];

                // Check if partition is valid:
                // All elements in LEFT ≤ all elements in RIGHT
                if (l1 <= r2 && l2 <= r1)
                {
                    // If total elements are even
                    if ((m + n) % 2 == 0)
                    {
                        // Median = average of max(left) and min(right)
                        return (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0;
                    }
                    else
                    {
                        // If odd → LEFT has one extra element
                        // Median = max(left)
                        return Math.Max(l1, l2);
                    }
                }

                // If left side of arr1 is too big → move left
                else if (l1 > r2)
                {
                    end = cut1 - 1;
                }
                else
                {
                    // Otherwise move right
                    start = cut1 + 1;
                }
            }

            // Should never reach here for valid input
            return 0;
        }
    }
