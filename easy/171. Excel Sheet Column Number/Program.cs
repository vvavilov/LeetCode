public class Solution {
    /*
        A > 1 x Symb
        AA -> Symb X 26 + Symb
        AAA -> 26 * 26 x symb + 26 x symb + x

    */
    public int TitleToNumber(string columnTitle) {
        var result = 0;
        var multiplier = 1;

        foreach(char c in columnTitle) {
            var numeric = c - 'A' + 1;
            result += numeric * multiplier;
            multiplier *= 26;
        }

        return result
        
    }
}