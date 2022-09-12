public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var closingToRemove = new HashSet<int>();
        var openCount = 0;

        for(int i = 0; i < s.Length; i++) {
            var x = s[i];

            if(x == '(') {
                openCount++;
            } else if(x == ')') {
                openCount--;
            }

            if(openCount < 0) {
                closingToRemove.Add(i);
                openCount = 0;
            }
        }

        var stringBuilder = new StringBuilder();

        for(int i = s.Length - 1; i >= 0; i--) {
            var x = s[i];

            if(x == ')' && closingToRemove.Contains(i)) {
                continue;
            }

            if(x == '(' && openCount > 0) {
                openCount--;
                continue;
            }

            stringBuilder.Append(x);
        }

        return new String(stringBuilder.ToString().Reverse().ToArray());
    }
}