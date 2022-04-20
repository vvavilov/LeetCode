public class Solution {
//     0 1 2 3 4 5 6 7 8 9 10 11 12
    public int[] CountBits(int n) {
            if(n == 0) {
                return new [] { 0 };
            } 
           var result = new int[n+1];
           result[0] = 0;
           result[1] = 1;
           for(int i = 2; i <= n; i++) {
               result[i] = result[i / 2] + i % 2;
           }
           
           return result;
    }
}