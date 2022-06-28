public class Solution {
    /*
        A > 1 x Symb
        AA -> Symb X 26 + Symb
        AAA -> 26 * 26 x symb + 26 x symb + x
    */
    public int TitleToNumber(string columnTitle) {
        var result = 0;
        
        var multiplier = 1;
        for(int i = columnTitle.Length - 1; i>= 0; i--) {
            result += multiplier * (columnTitle[i] - 'A' + 1);
            multiplier *= 26;
        }
        
        return result;
        
    }
}