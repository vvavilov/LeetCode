public class Solution {
    public int LargestVariance(string s) {
        var lettersA = new HashSet<char>(s);
        var lettersB = new HashSet<char>(s);
        
        var max = 0;
        
        foreach(var x in lettersA) {            
            foreach(var y in lettersB) {
                if(x == y) {
                    continue;
                }
                
                var diff = 0; 
                var curMax = 0;
                var seenY = false;
                var startsWithY = false;
                
                // aaba
                
                foreach(var c in s) {
                    if(diff <= -1) {
                        diff = -1;
                        startsWithY = true;
                    }

                    if(c == x) {
                        diff++;
                    }
                    
                    if(c == y) {
                        if(startsWithY) {
                            startsWithY = false;
                            diff++;
                        }

                        seenY = true;
                        diff--;
                    }
                    
                    if(seenY) {
                        curMax = Math.Max(diff, curMax);
                    }
                }
                
                max = Math.Max(curMax, max);
            }
        }
        
        return max;
    }
}