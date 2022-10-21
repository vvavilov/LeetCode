public class Solution {
    int postsCount;
    int paintsCount;
    
    public int NumWays(int n, int k) {
        postsCount = n;
        paintsCount = k;
        return paintsCount * DP(1, false, new Dictionary<(int pos, bool prevSame), int>());
    }
    
    private int DP(int pos, bool prevTwoSame, Dictionary<(int pos, bool prevSame), int> mem) {
        if(pos == postsCount) {
            return 1;
        }
        
        var state = (pos, prevTwoSame);
        
        if(mem.ContainsKey(state)) {
            return mem[state];
        }
        
        if(prevTwoSame) {
            mem[state] = (paintsCount - 1) * DP(pos + 1, false, mem);
        } else {
            mem[state] = (paintsCount - 1) * DP(pos + 1, false, mem) + DP(pos + 1, true, mem);
        }
        
        return mem[state];
    }
}
        