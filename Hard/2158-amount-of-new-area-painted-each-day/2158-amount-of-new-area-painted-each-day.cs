public class Solution {
    public int[] AmountPainted(int[][] paint) {
        var result = new List<int>();
        var paintedIntervals = new List<(int start, int end)>();
        
        foreach(var x in paint) {
            var newPaintedIntervals = new List<(int start, int end)>();
            (int start, int end) toPaint = (x[0], x[1]);
            
            var curInterval = 0;
            
            // Console.WriteLine("interval " + toPaint.start + " " + toPaint.end);

            
            while(curInterval < paintedIntervals.Count && toPaint.start > paintedIntervals[curInterval].end) {
                Console.WriteLine("not overlaps " + paintedIntervals[curInterval].start + " " + paintedIntervals[curInterval].end);

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
                // 0 17,  18, 19 - 16 18
                
            }
            
            Console.WriteLine("merged " + mergedInterval.start + " " + mergedInterval.end);
            
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
    
    private bool IsOverlaps((int start, int end) newOne, (int start, int end) existingOne) {
        return newOne.start <= existingOne.end && newOne.end >= existingOne.start;
    }
}