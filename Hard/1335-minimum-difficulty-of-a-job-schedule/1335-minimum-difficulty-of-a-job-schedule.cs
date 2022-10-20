public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        if(jobDifficulty.Length < d) {
            return -1;
        }
        
        return DP(jobDifficulty, 0, d, new Dictionary<(int job, int rest), int>());
    }
    
    private int DP(int[] jobs, int job, int restDays, Dictionary<(int job, int rest), int> dp) {
        if(restDays == 0) {
            return 0;
        }
        
        if(dp.ContainsKey((job, restDays))) {
            return dp[(job, restDays)];
        }
        
        if(restDays == 1) {
            var max = Int32.MinValue;
            
            for(int i = job; i < jobs.Length; i++) {
                max = Math.Max(max, jobs[i]);
            }
            
            dp[(job, restDays)] = max;
            return max;
        }
        
        var totalDifficulty = Int32.MaxValue;
        var thisDayDifficulty = Int32.MinValue;
        
        for(int i = job; i < jobs.Length; i++) {
            if(jobs.Length - i < restDays) {
                break;
            }
            
            thisDayDifficulty = Math.Max(thisDayDifficulty, jobs[i]);
            totalDifficulty = Math.Min(totalDifficulty, thisDayDifficulty + DP(jobs, i + 1, restDays - 1, dp));
        }

        dp[(job, restDays)] = totalDifficulty;
        return totalDifficulty;
    }
}

/*
0 3

i=0
tDD = 1
(1, 2)
    tDD 3
    (2, 1)
        tDD 2
        



*/