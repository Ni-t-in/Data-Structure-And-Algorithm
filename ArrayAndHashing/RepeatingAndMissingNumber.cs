using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ArrayAndHashing
{
    public class RepeatingAndMissingNumber
    {
        public List<int> FindMissingRepeatingNumbers(List<int> nums)
        {
            int n = nums.Count;

            // Expected sum of numbers from 1 to n
            long expectedSum = (long)n * (n + 1) / 2;

            // Expected sum of squares from 1^2 to n^2
            long expectedSquareSum = (long)n * (n + 1) * (2 * n + 1) / 6;

            // Actual sum and square sum from the array
            long actualSum = 0;
            long actualSquareSum = 0;

            foreach (var num in nums)
            {
                actualSum += num;
                actualSquareSum += (long)num * num;
            }

            // Let:
            // missing = x
            // repeating = y

            // Step 1: Difference of sums
            // x - y = expectedSum - actualSum
            long diff = expectedSum - actualSum;

            // Step 2: Difference of square sums
            // x^2 - y^2 = expectedSquareSum - actualSquareSum
            long squareDiff = expectedSquareSum - actualSquareSum;

            // Step 3: Use identity:
            // x^2 - y^2 = (x - y)(x + y)
            // So: x + y = squareDiff / diff
            long sumXY = squareDiff / diff;

            // Step 4: Solve the two equations:
            // x - y = diff
            // x + y = sumXY

            long missing = (diff + sumXY) / 2;
            long repeating = missing - diff;

            // Return format: [repeating, missing]
            return new List<int> { (int)repeating, (int)missing };
        }
    }
}
