using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearch
{
    public class MinimiseGasStation
    {
        public double MinimiseMaxDistance(List<int> arr, int k)
        {
            // start = minimum possible distance (can be 0)
            double start = 0;

            // end = maximum possible distance (largest gap between stations)
            double end = 0;

            // Find the maximum initial gap → this is the upper bound of answer
            for (int i = 1; i < arr.Count; i++)
            {
                end = Math.Max(end, arr[i] - arr[i - 1]);
            }

            // Binary search on distance (double)
            // Continue until precision is within 1e-6
            while (end - start > 1e-6)
            {

                // Candidate maximum distance
                double mid = start + (end - start) / 2;

                int required = 0;

                // Count how many new stations are needed
                // to ensure every gap ≤ mid
                for (int i = 1; i < arr.Count; i++)
                {
                    double gap = arr[i] - arr[i - 1];

                    // Number of stations needed to split this gap
                    // into segments of size ≤ mid
                    // ceil(gap / mid) gives number of segments
                    // so stations = segments - 1
                    required += (int)Math.Ceiling(gap / mid) - 1;
                }

                // If we can achieve this distance using ≤ k stations
                if (required <= k)
                {
                    // mid is valid → try smaller distance (minimize)
                    end = mid;
                }
                else
                {
                    // mid too small → need more stations than allowed
                    // increase distance
                    start = mid;
                }
            }

            // end will be the minimum possible maximum distance
            return end;
        }
    }
}
