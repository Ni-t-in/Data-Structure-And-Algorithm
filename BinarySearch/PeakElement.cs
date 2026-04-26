using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class PeakElement
    {
        public int FindPeakElement(List<int> arr)
        {
            int low = 0;
            int high = arr.Count - 1;

            // We use binary search based on "slope"
            // Instead of searching for a value, we decide direction using arr[mid] vs arr[mid+1]
            while (low < high)
            {

                // Prevent overflow (standard binary search practice)
                int mid = low + (high - low) / 2;

                // Compare mid with its right neighbor
                // This tells us whether we are on an increasing or decreasing slope

                if (arr[mid] < arr[mid + 1])
                {
                    // Increasing slope → peak must exist on the right side
                    // So we safely discard left half including mid
                    low = mid + 1;
                }
                else
                {
                    // Decreasing slope → peak is either at mid or on the left side
                    // So we keep mid and discard right half
                    high = mid;
                }
            }

            // At the end, low == high → pointing to a peak element
            return low;
        }
    }
}
