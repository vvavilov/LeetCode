public class Solution {

    
    public string IntToRoman(int num) {
        var result = new StringBuilder();
        var integers = new[] {1000,900,500,400,100,90,50,40,10,9,5,4,1};
        var romans = new[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        
        for(int i = 0; i < integers.Length; i++) {
            var integer = integers[i];
            var roman = romans[i];
            
            var count = num / integer;
            num -= count * integer;
            
            while(count-- > 0) {
                result.Append(roman);
            }
        }

        return result.ToString();
    }
}