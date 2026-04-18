using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ArrayAndHashing
{
    public class KXor
    {
        public int SubarraysWithXorK(int[] nums, int k)
        {
            // Dictionary to store:
            // key   -> prefix XOR value
            // value -> how many times this prefix XOR has appeared so far
            Dictionary<int, int> dict = new Dictionary<int, int>();

            // Important base case:
            // prefix XOR = 0 has occurred once (before starting)
            // This helps count subarrays that start from index 0
            dict[0] = 1;

            int count = 0;   // Stores total number of valid subarrays
            int prefix = 0;  // Running XOR from start to current index

            foreach (var num in nums)
            {
                // Step 1: Update running prefix XOR
                // This represents XOR of elements from index 0 to current index
                prefix ^= num;

                // Step 2: Compute the required prefix XOR
                // We want: previousPrefix ^ currentPrefix = k
                // Rearranged: previousPrefix = currentPrefix ^ k
                int needed = prefix ^ k;

                // Step 3: Check if this required prefix was seen before
                // If yes, it means there exists a subarray ending here with XOR = k
                if (dict.ContainsKey(needed))
                {
                    // Add the number of times this prefix appeared
                    // (each occurrence represents a valid starting point)
                    count += dict[needed];
                }

                // Step 4: Store/update current prefix XOR in dictionary
                // This will be used for future elements
                if (dict.ContainsKey(prefix))
                {
                    dict[prefix]++;
                }
                else
                {
                    dict[prefix] = 1;
                }
            }

            // Final answer: total number of subarrays with XOR = k
            return count;
        }
    }
}
