public class Solution {
    public int LongestStrChain(string[] words) {
        var groupedByLength = new Dictionary<int, IList<string>>();
        var minLength = Int32.MaxValue;
        var maxLength = 0;

        foreach(var x in words) {
            groupedByLength.TryGetValue(x.Length, out var existing);
            groupedByLength[x.Length] = existing ?? new List<string>();
            groupedByLength[x.Length].Add(x);
            minLength = Math.Min(minLength, x.Length);
            maxLength = Math.Max(maxLength, x.Length);
        }

        var dp = new Dictionary<string, int>();

        foreach(var x in groupedByLength[maxLength]) {
            if(dp.ContainsKey(x)) {
                continue;
            }

            dp[x] = 1;
        }

        for(int i = maxLength - 1; i >= minLength; i--) {
            if(!groupedByLength.ContainsKey(i)) {
                continue;
            }

            var wordsOfLength = groupedByLength[i];
            var canHaveAccessors = groupedByLength.TryGetValue(i + 1, out var potentialAccessors);

            foreach(var x in wordsOfLength) {
                dp[x] = 1;

                if(!canHaveAccessors) {
                    continue;
                }

                foreach(var y in potentialAccessors) {
                    if(IsSuccessor(x, y)) {
                        dp[x] = Math.Max(dp[x], dp[y] + 1);
                    }
                }
            }
        }

        return dp.Values.Max();
    }

    private bool IsSuccessor(string prev, string current) {
        var hasMismatch = false;
        var prevPos = 0;
        var curPos = 0;

        while(prevPos < prev.Length && curPos < current.Length) {
            if(current[curPos] != prev[prevPos]) {
                if(hasMismatch) {
                    return false;
                }

                hasMismatch = true;
                curPos++;
                continue;
            }

            prevPos++;
            curPos++;
        }

        return true;
    }
}