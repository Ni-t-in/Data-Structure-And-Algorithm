using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class MergeSort
    {
        public int[] MergeSortProblem(int[] nums, int left, int right)
        {
            // Base case: if the array has 1 or 0 elements, it's already sorted
            if (left >= right) return nums;

            // Find the middle index to divide the array into two halves
            int mid = (left + right) / 2;

            // Recursively sort the left half
            MergeSortProblem(nums, left, mid);

            // Recursively sort the right half
            MergeSortProblem(nums, mid + 1, right);

            // Merge the two sorted halves
            Merge(nums, left, mid, right);

            return nums;
        }

        public static void Merge(int[] nums, int left, int mid, int right)
        {
            // Temporary array to store merged result
            int[] temp = new int[right - left + 1];

            // Pointers for left half, right half, and temp array
            int i = left;       // Start of left subarray
            int j = mid + 1;   // Start of right subarray
            int k = 0;         // Index for temp array

            // Compare elements from both halves and store smaller one in temp
            while (i <= mid && j <= right)
            {
                if (nums[i] < nums[j])
                {
                    temp[k++] = nums[i++];
                }
                else
                {
                    temp[k++] = nums[j++];
                }
            }

            // Copy remaining elements from left half (if any)
            while (i <= mid)
            {
                temp[k++] = nums[i++];
            }

            // Copy remaining elements from right half (if any)
            while (j <= right)
            {
                temp[k++] = nums[j++];
            }

            // Copy merged elements back to original array
            for (int l = 0; l < temp.Length; l++)
            {
                nums[left + l] = temp[l];
            }
        }
    }
}
