public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        return DP(s, s.Length - 1, new HashSet<string>(wordDict), new Dictionary<int, bool>());
    }
    
    private bool DP(string s, int pos, HashSet<string> dict, Dictionary<int, bool> dp) {
        if(pos == -1) {
            return true;
        }
        
        if(dp.ContainsKey(pos)) {
            return dp[pos];
        }
        
        for(int i = pos; i >= 0; i--) {
            var potentialWord = s.Substring(i, pos - i + 1);
            
            if(!dict.Contains(potentialWord)) {
                continue;
            }
            
            var restBreakable = DP(s, i - 1, dict, dp);
            
            if(restBreakable) {
                dp[pos] = true;
                return true;
            }
        }
        
        dp[pos] = false;
        return false;
    }
}

// public class Solution {
//     HashSet<string> hash;

//     public bool WordBreak(string s, IList<string> wordDict) {
//         hash = new HashSet<string>(wordDict);
        
// // doggy
//         var breakable = new bool[s.Length];
//         breakable[0] = hash.Contains(s[0].ToString());
        
//         for(int i = 1; i < s.Length; i++) {
//             breakable[i] = hash.Contains(s.Substring(0, i + 1));
//             if(breakable[i]) {
//                 continue;
//             }
                                
//             for(int j = 0; j < i; j++) {
//                 var leftBreakable = breakable[j];
//                 var rightKnown = hash.Contains(s.Substring(j + 1, i - j));
                
//                 if(leftBreakable && rightKnown) {
//                     breakable[i] = true;
//                     break;
//                 }
//             }
//         }
        
//         return breakable[s.Length - 1];
//     }
       
//     IDictionary<int, bool> mem = new Dictionary<int, bool>();
    
//     public bool WordBreakTopDown(string s, IList<string> wordDict) {
//         hash = new HashSet<string>(wordDict);
//         return Break(s, 0);
//     }
    
//     private bool Break(string s, int start) {
//         if(mem.ContainsKey(start)) {
//             return mem[start];
//         }

//         if(start == s.Length) {
//             return true;
//         }

//         mem[start] = false;
        
//         for(int i = start; i < s.Length; i++) {
//             var leftKnown = hash.Contains(s.Substring(start, i - start + 1));
            
//             if(leftKnown && Break(s, i + 1)) {
//                 mem[start] = true;
//                 return true;
//             }
//         }
                                      
//         mem[start] = hash.Contains(s.Substring(start));
//         return mem[start];
//     }
    
// }