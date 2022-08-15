public class Solution {
    public IList<long> MaximumEvenSplit(long finalSum) {
        if(finalSum == 0 || finalSum % 2 != 0) {
            return new List<long>();
        }
        
        var list = new List<long>();
        Solve(finalSum, 0, list);
        return list;
    }

    public void Solve(long rest, long prev, IList<long> acc) {
        if(rest == 0) {
            return;
        }
        
        var next = prev + 2;
        var remaining = rest - next;

        if(remaining <= next) {
            acc.Add(rest);
            return;
        }

        acc.Add(next);
        Solve(remaining, next, acc);
    }
}