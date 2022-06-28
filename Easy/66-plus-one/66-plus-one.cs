public class Solution {
    public int[] PlusOne(int[] digits) {
        int i = 0;
        for(i = digits.Length - 1; i >= 0; i--) {
            if(digits[i] != 9) {
                digits[i] += 1;
                break;
            }
            
            digits[i] = 0;
        }
        
        if(i >= 0) {
            return digits;
        }
        
        var result = new int[digits.Length + 1];
        result[0] = 1;
        
        for(i = 0; i < digits.Length; i++) {
            result[i+1] = digits[i];
        }
        
        return result;
    }
}