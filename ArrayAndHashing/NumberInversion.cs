using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ArrayAndHashing
{
    public class NumberInversion
    {
        public long NumberOfInversions(List<int> nums)
        {
            // Start merge sort on full array
            return MergeSort(nums, 0, nums.Count - 1);
        }

        public long MergeSort(List<int> nums, int left, int right)
        {
            long count = 0;

            // Base case: single element → no inversions
            if (left >= right)
            {
                return count;
            }

            // Divide the array into two halves
            int mid = (left + right) / 2;

            // Count inversions in left half
            count += MergeSort(nums, left, mid);

            // Count inversions in right half
            count += MergeSort(nums, mid + 1, right);

            // Count cross inversions while merging
            count += Merge(nums, left, mid, right);

            return count;
        }

        public long Merge(List<int> nums, int left, int mid, int right)
        {
            // Temporary list to store sorted elements
            var temp = new List<int>();

            int i = left;       // pointer for left half
            int j = mid + 1;    // pointer for right half
            long count = 0;

            // Merge both halves while counting inversions
            while (i <= mid && j <= right)
            {
                // If left element is smaller or equal → no inversion
                if (nums[i] <= nums[j])
                {
                    temp.Add(nums[i++]);
                }
                else
                {
                    // nums[i] > nums[j] → inversion found

                    // Since left half is sorted,
                    // ALL elements from i to mid will be greater than nums[j]
                    count += (mid - i + 1);

                    temp.Add(nums[j++]);
                }
            }

            // Add remaining elements from left half
            while (i <= mid)
            {
                temp.Add(nums[i++]);
            }

            // Add remaining elements from right half
            while (j <= right)
            {
                temp.Add(nums[j++]);
            }

            // Copy sorted elements back to original array
            for (int k = 0; k < temp.Count; k++)
            {
                nums[left + k] = temp[k];
            }

            return count;
        }
    }
}
