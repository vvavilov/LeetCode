public class Solution {
    public int Tribonacci(int n) {
        if(n == 0) { return 0; }
        if(n == 1) { return 1; }
        
        var first = 0;
        var second = 1;
        var third = 1;
        
        
        
        for(int i = 3; i <= n; i++) {
            var current = first + second + third;
            first = second;
            second = third;
            third = current;
        }
        
        return third;
        
    }
}