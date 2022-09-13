public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        var byValue = boxTypes.OrderBy(x => x[1]).ToArray();
        var value = 0;

        for(int i = byValue.Length - 1; i >= 0; i--) {
            var boxesToTake = Math.Min(truckSize, byValue[i][0]);
            value += boxesToTake * byValue[i][1];
            truckSize -= boxesToTake;

            if(truckSize == 0) {
                return value;
            }
        }

        return value;
    }
}