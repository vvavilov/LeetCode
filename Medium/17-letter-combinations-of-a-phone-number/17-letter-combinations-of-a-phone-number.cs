public class Solution {
    Dictionary<char, string> encoding = new Dictionary<char, string> {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "xwyz"}
    };

    public IList<string> LetterCombinations(string digits) {
        List<string> result = new();

        if(digits == "") {
            return result; 
        }

        Backtrack(digits, 0, new StringBuilder(), result);
        return result;
    }
    
    private void Backtrack(string digits, int n, StringBuilder acc, List<string> result) {
        if(n == digits.Length) {
            result.Add(acc.ToString());
            return;
        }
        
        foreach(var x in encoding[digits[n]]) {
            acc.Append(x);
            Backtrack(digits, n + 1, acc, result);
            acc.Remove(acc.Length - 1, 1);
        }
    }
}