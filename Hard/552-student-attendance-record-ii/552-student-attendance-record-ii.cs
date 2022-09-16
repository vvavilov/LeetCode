public class Solution {
    private int mod = (int)Math.Pow(10, 9) + 7;
    
    public int CheckRecord(int n) {
        if(n == 1) {
            return 3;
        }
        
        if(n == 2) {
            return 8;
        }
        
        var p = new int[n];
        var a = new int[n];
        var l = new int[n];
        
        p[0] = 1;
        a[0] = 1;
        a[1] = 2;
        a[2] = 4;
        l[0] = 1;
        l[1] = 3;
        
        for(int i = 1; i < n; i++) {
            p[i] = ((p[i - 1] + a[i - 1]) % mod + l[i-1]) % mod;
            
            if(i > 1) {
                l[i] = (((p[i - 1] + a[i - 1]) % mod + p[i-2]) % mod + a[i-2]) % mod;
            }
            
            if(i > 2) {
                a[i] = ((a[i - 1] + a[i - 2]) % mod + a[i-3]) % mod;
            }
        }
        
        return ((p[n - 1] + a[n-1]) % mod + l[n-1]) % mod;
    }
    
    private int P(int n) {
        if(n == 1) {
            return 1;
        }
        
        return P(n - 1) + A(n - 1) + L(n - 1);
    }
    
    private int L(int n) {
        if(n == 2) {
            return 3;
        }
        
        if(n == 1) {
            return 1;
        }
        
        return P(n - 1) + A(n - 1) + P(n - 2) + A(n - 2);
    }
    
    private int A(int n) {
        if(n == 1) {
            return 1;
        }
        
        if(n == 2) {
            return 2;
        }
        
        if(n == 3) {
            return 4;
        }
        
        return A(n - 1) + A(n - 2) + A(n - 3);
    }
}