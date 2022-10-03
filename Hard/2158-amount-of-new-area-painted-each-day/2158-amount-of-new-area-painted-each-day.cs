public class Solution {
    public int[] AmountPainted(int[][] paint) {
        var days = new SortedSet<int>();
        var result = new int[paint.Length];
        
        var events = new List<(int pos, bool isStart, int index)>();

        var lastPos = 0;
        
        for(int i = 0; i < paint.Length; i++) {
            events.Add((paint[i][0], true, i));
            events.Add((paint[i][1], false, i));
            lastPos = Math.Max(lastPos, paint[i][1]);
        }
        
        events = events.OrderBy(x => x.pos).ToList();

        var eventPos = 0;
        
        for(int i = 0; i <= lastPos; i++) {
            Console.WriteLine("position " + i);
            // var hasEvent = eventsPos < events.Length && events[eventPos].pos == i;
            while(eventPos < events.Count && events[eventPos].pos == i) {
                var paintEvent = events[eventPos];

                if(paintEvent.isStart) {
                    days.Add(paintEvent.index);
                } else {
                    days.Remove(paintEvent.index);
                }

                eventPos++;
            }
            
            if(days.Count > 0) {
                result[days.First()]++;    
            }  
        }
        
        return result;
    }
}

public class SolutionQuadraticTime {
    public int[] AmountPainted(int[][] paint) {
        var result = new List<int>();
        var paintedIntervals = new List<(int start, int end)>();
        
        foreach(var x in paint) {
            var newPaintedIntervals = new List<(int start, int end)>();
            (int start, int end) toPaint = (x[0], x[1]);
            
            var curInterval = 0;
            
            while(curInterval < paintedIntervals.Count && toPaint.start > paintedIntervals[curInterval].end) {
                newPaintedIntervals.Add(paintedIntervals[curInterval]);
                curInterval++;
            }

            var toPaintCount = toPaint.end - toPaint.start;
            (int start, int end) mergedInterval = toPaint;
            
            while(curInterval < paintedIntervals.Count && mergedInterval.end >= paintedIntervals[curInterval].start) {
                var paintedInterval = paintedIntervals[curInterval];
                var alreadyPaintedCount = Math.Min(paintedInterval.end, toPaint.end) - Math.Max(paintedInterval.start, toPaint.start);
                toPaintCount -= alreadyPaintedCount;

                mergedInterval = (
                    Math.Min(mergedInterval.start, paintedInterval.start),
                    Math.Max(mergedInterval.end, paintedInterval.end)); 
                
                curInterval++;
            }
            
            newPaintedIntervals.Add(mergedInterval);
            result.Add(toPaintCount);
            
            while(curInterval < paintedIntervals.Count) {
                newPaintedIntervals.Add(paintedIntervals[curInterval]);
                curInterval++;
            }
            
            paintedIntervals = newPaintedIntervals;
        }
        
        return result.ToArray();
    }
}