public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {            
        var digitPos = 0;
        var lessOrEqualCount = 0;

        while(n > 0) {
            var digit = n % 10;
            n = n / 10;
            
            if(HasDigit(digits, digit)) {
                lessOrEqualCount = digitPos == 0 ? 1 : lessOrEqualCount;
            } else {
                lessOrEqualCount = 0;
            }
            
            lessOrEqualCount += LessCount(digits, digit) * (int)Math.Pow(digits.Length, digitPos);
            digitPos++;
        }
        
        while(digitPos - 1 > 0) {
            lessOrEqualCount += (int)Math.Pow(digits.Length, digitPos - 1);
            digitPos--;
        }
        
        return lessOrEqualCount;
    }
    
    private bool HasDigit(string[] digits, int digit) {
        return digits.Any(x => x == digit.ToString());
    }
    
    private int LessCount(string[] digits, int digit) {
        return digits.Count(x => Int32.Parse(x) < digit);
    }
}