public class Solution {
    public int MinDeletions(string s) {
        var sortedFrequencies = CalculateFrequency(s).OrderByDescending(x => x);
        var maxAllowed = sortedFrequencies.Max();
        var result = 0;

        foreach(var x in sortedFrequencies) {
            if(maxAllowed == 0) {
                result += x - maxAllowed;
                continue;
            }

            if(x == maxAllowed) {
                maxAllowed--;
                continue;
            }

            if(x < maxAllowed) {
                maxAllowed = x - 1;
                continue;
            }

            result += x - maxAllowed;
            maxAllowed--;
        }

        return result;
    }

    private IEnumerable<int> CalculateFrequency(string s) {
        var frequency = new Dictionary<char, int>();
        
        foreach(var x in s) {
            frequency.TryGetValue(x, out var count);
            frequency[x] = ++count;
        }

        return frequency.Values;
    }
}