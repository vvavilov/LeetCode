public class Solution {
    /*
        123 -> 1^2+2^2+3^2
        
    */
    public bool IsHappy(int n) {
        var visited = new HashSet<int>();

        while(true) {
            var transformed = Happify(n);
            if (transformed == 1) {
                return true;
            }
            
            if(visited.Contains(transformed)){
                return false;
            }

            n = transformed;
            visited.Add(n);
        }
        return false;
    }
    
    private int Happify(int n) {
        var result = 0;
        while(n > 0) {
            var digit = n % 10;
            n = n / 10;
            result += digit * digit;
        }
        
        return result;
    }
}