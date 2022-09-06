/*
// Definition for an Interval.
public class Interval {
    public int start;
    public int end;

    public Interval(){}
    public Interval(int _start, int _end) {
        start = _start;
        end = _end;
    }
}
*/

public class Solution {
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule) {
        var unitedIntervals = new List<Interval>();
        List<Interval> result = new();
        
        foreach(var employee in schedule) {
            foreach(var x in employee) {
                unitedIntervals.Add(x);

            }
        }
        
        var orderedIntervals = unitedIntervals.OrderBy(x => x.start).ToList();
        
        var prevInterval = orderedIntervals[0];
        
       for(int i = 1; i < orderedIntervals.Count; i++) {
           var possibleFreeTime = TryGetFreeTime(prevInterval, orderedIntervals[i]);
           
           if(possibleFreeTime != null) {
               result.Add(possibleFreeTime);
               prevInterval = orderedIntervals[i];
           } else {
               prevInterval = MergeIntervals(prevInterval, orderedIntervals[i]);
           }
       }
        
        return result;
        
    }
    
    private Interval TryGetFreeTime(Interval left, Interval right) {
        if(right.start < left.end) {
            return null;
        }
        
        if(right.start == left.end) {
            return null;
        }
        
        return new Interval(left.end, right.start);
        
    }
    
    private Interval MergeIntervals(Interval left, Interval right) {
        return new Interval(left.start, Math.Max(left.end, right.end));
    }
                                           
}