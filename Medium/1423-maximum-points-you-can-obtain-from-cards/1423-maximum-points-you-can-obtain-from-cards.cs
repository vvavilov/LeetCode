
public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        var prefixFromLeft = new int[cardPoints.Length];
        var prefixFromRight = new int[cardPoints.Length];
        
        prefixFromLeft[0] = cardPoints[0];
        
        for(int i = 1; i < cardPoints.Length; i++) {
            prefixFromLeft[i] = prefixFromLeft[i-1] + cardPoints[i];
        }
        
        
        prefixFromRight[0] = cardPoints[cardPoints.Length - 1];
        
        for(int i = 1; i < cardPoints.Length; i++) {
            prefixFromRight[i] = prefixFromRight[i-1] + cardPoints[cardPoints.Length - 1 - i];
        }
        
        var leftTaken = k;
        var max = 0;
        
        while(leftTaken >= 0) {
            var rightTaken = k - leftTaken;
            var curMax = 0;
            
            if(leftTaken != 0) 
            {
                curMax += prefixFromLeft[leftTaken - 1];
            }

            if(rightTaken != 0) {
                curMax += prefixFromRight[rightTaken - 1];
            }
            
            max = Math.Max(curMax, max);
            leftTaken--;
        }
        
        return max;
    }

}