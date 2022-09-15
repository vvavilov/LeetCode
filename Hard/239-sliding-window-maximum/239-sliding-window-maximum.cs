public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var dictionary = new SortedDictionary<int, int>(new MaxHeapComparer());
        var result = new List<int>();

        for(int i = 0; i < k; i++) {
            dictionary.TryGetValue(nums[i], out var count);
            dictionary[nums[i]] = count + 1;
        }

        result.Add(dictionary.First().Key);

        var windowStart = 1;
        var windowEnd = windowStart + k - 1;

        while(windowEnd < nums.Length) {
            dictionary.TryGetValue(nums[windowStart - 1], out var countPrevWindowStart);

            if(countPrevWindowStart == 1) {
                dictionary.Remove(nums[windowStart - 1]);
            } else {
                dictionary[nums[windowStart - 1]] = countPrevWindowStart - 1;
            }

            dictionary.TryGetValue(nums[windowEnd], out var countNewWindowEnd);
            dictionary[nums[windowEnd]] = countNewWindowEnd + 1;

            result.Add(dictionary.First().Key);
            windowEnd++;
            windowStart++;
        }

        return result.ToArray();
    }
}

public class MaxHeapComparer : IComparer<int> {
    public int Compare(int left, int right) {
        if(left < right) {
            return 1;
        }

        if(left > right) {
            return -1;
        }

        return 0;
    }
}

