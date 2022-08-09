public class Solution {
    private int mod = (int)(Math.Pow(10, 9) + 7);
    
    public int NumFactoredBinaryTrees(int[] arr) {
        if(arr.Length == 0) {
            return 0;
        }
        
        Array.Sort(arr);
        
        var nodes =  ArrayToDict(arr);
        var dp = new double[arr.Length];
        var result = 0d;
        
        for(int i = arr.Length - 1; i >= 0; i--) {
            result += TopDown(arr, nodes, i, dp) % mod;
        }
        
        return (int)(result % mod);
    }
    
    private Dictionary<int, int> ArrayToDict(int[] array) {
        var result = new Dictionary<int, int>();
        
        for(int i = 0; i < array.Length; i++) {
            result[array[i]] = i;
        }
        
        return result;
    }
    
    
    private double TopDown(int[] arr, Dictionary<int, int> nodes, int rootCandidatePos, double[] dp) {
        if(dp[rootCandidatePos] != 0) {
            return dp[rootCandidatePos];
        }
        
        var rootCandidate = arr[rootCandidatePos];
        dp[rootCandidatePos] = 1;
        
        for(int i = 0; i < rootCandidatePos; i++) {
            var leftCandidate = arr[i];
                
            if (rootCandidate % leftCandidate != 0) {
                continue;
            }
            
            var rightCandidate = rootCandidate / leftCandidate;
            
            if(!nodes.ContainsKey(rightCandidate)) {
                continue;
            }
            
            dp[rootCandidatePos] += TopDown(arr, nodes, nodes[leftCandidate], dp) * TopDown(arr, nodes, nodes[rightCandidate], dp) % mod;
        }
        
        return dp[rootCandidatePos];
    }
}