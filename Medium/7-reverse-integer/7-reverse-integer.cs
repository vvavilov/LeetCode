public class Solution {
    public int Reverse(int x) {
        var isNegative = x < 0;
        var reversed = isNegative ? -0 : 0;

        while(x != 0) {
            var oneMoreNumber = x % 10;
            x = x / 10;
            
            if(isNegative) {
                
                if((Int32.MinValue - oneMoreNumber) / 10 > reversed) {
                    return 0;
                }
                
                reversed = reversed * 10 + oneMoreNumber;
                continue;
            }
            
            if((Int32.MaxValue - oneMoreNumber) / 10 < reversed) {
                return 0;
            }
            
            reversed = reversed * 10 + oneMoreNumber;
        }
        
        return reversed;
        
    }
}