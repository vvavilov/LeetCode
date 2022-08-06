public class Solution {
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
         int states = minutesToTest / minutesToDie + 1;
        return (int) Math.Ceiling(Math.Log(buckets) / Math.Log(states));
    }
}

