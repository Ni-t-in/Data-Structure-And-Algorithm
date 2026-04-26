using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class BookAllocation
    {
        public int findPages(List<int> nums, int m)
        {
            int n = nums.Count;

            // Edge case: more students than books → not possible
            if (m > n) return -1;

            // Minimum possible max pages = largest single book
            int start = nums.Max();

            // Maximum possible max pages = sum of all books (one student takes all)
            int end = nums.Sum();

            int answer = -1;

            // Binary search on answer (max pages per student)
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                // Count how many students are needed if each student
                // can take at most 'mid' pages
                int students = 1;
                int currentPages = 0;

                foreach (int pages in nums)
                {
                    // If adding this book exceeds allowed limit,
                    // assign it to a new student
                    if (currentPages + pages > mid)
                    {
                        students++;
                        currentPages = pages; // start new student's allocation
                    }
                    else
                    {
                        currentPages += pages; // continue with current student
                    }
                }

                // If we can allocate within m students → valid
                if (students <= m)
                {
                    answer = mid;        // store possible answer
                    end = mid - 1;       // try to minimize further
                }
                else
                {
                    // Too many students needed → increase allowed pages
                    start = mid + 1;
                }
            }

            // 'answer' holds the minimum possible maximum pages
            return answer;
        }
    }
}
