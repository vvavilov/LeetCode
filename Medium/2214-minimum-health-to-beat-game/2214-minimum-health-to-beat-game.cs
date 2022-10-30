public class Solution {
    public long MinimumHealth(int[] damage, int armor) {
        var maxDamage = 0;
        var total = 0L;
        
        foreach(var x in damage) {
            total += x;
            maxDamage = Math.Max(maxDamage, x);
        }
        
        total -= Math.Min(maxDamage, armor);
        return total + 1;
        
    }
}