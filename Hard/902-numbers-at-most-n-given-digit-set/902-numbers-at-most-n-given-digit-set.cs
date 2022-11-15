public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        // 5876
        // n for 1d
        // n * n for 2d
        // n * n * n for 3d
        // 3d * by less equal than 5 for 4d
        
        // 81
        // 348
        
        // 7 - 3
        // 8 - 3+(n less than 8 * n)
        
        // 100
        // 1 3 5 7
            
        var digitNumber = 0;
        var digitsCount = digits.Length;
        var total = 0;
        var previousLessOrEqualCount = 0;
        
        while(n > 0) {
            var digit = n % 10;
            n = n / 10;
            
            var currentLessOrEqualCount = LessCount(digits, digit) * (int)Math.Pow(digits.Length, digitNumber);
            
            if(HasDigit(digits, digit)) {
                currentLessOrEqualCount += digitNumber == 0 ? 1 : previousLessOrEqualCount;
            }
            
            
            previousLessOrEqualCount = currentLessOrEqualCount;
            digitNumber++;
        }
        
        while(digitNumber - 1 > 0) {
            previousLessOrEqualCount += (int)Math.Pow(digits.Length, digitNumber - 1);
            digitNumber--;
        }
        
        return previousLessOrEqualCount;
    }
    
    private bool HasDigit(string[] digits, int digit) {
        return digits.Any(x => x == digit.ToString());
    }
    
    private int LessCount(string[] digits, int digit) {
        return digits.Count(x => Int32.Parse(x) < digit);
    }
}