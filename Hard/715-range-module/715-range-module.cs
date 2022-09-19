public class RangeModule {
    List<(int left, int right)> ranges = new();

    public RangeModule() {
        
    }
    
    public void AddRange(int left, int right) {
        var newList = new List<(int left, int right)>();
        
        if(ranges.Count == 0) {
            ranges.Add((left, right));
            return;
        }
        
        var pos = 0;
        
        while(pos < ranges.Count && ranges[pos].right < left) {
            newList.Add(ranges[pos]);
            pos++;
        }
        
        (int left, int right) toAdd = (left, right);
        
        while(pos < ranges.Count && ranges[pos].left <= right) {
            toAdd = Merge(toAdd, ranges[pos]);
            pos++;
        }
        
        newList.Add(toAdd);
        
        for(int i = pos; i < ranges.Count; i++) {
            newList.Add(ranges[i]);
        }
        
        ranges = newList;
    }
    
    private (int left, int right) Merge((int left, int right) left, (int left, int right) right) {
        return (Math.Min(left.left, right.left), Math.Max(right.right, left.right));
    }
    
    
    public bool QueryRange(int left, int right) {
        var leftPos = 0;
        var rightPos = ranges.Count - 1;
        
        while(leftPos <= rightPos) {
            var midPos = (rightPos - leftPos) / 2 + leftPos;
            
            var range = ranges[midPos];
            
            if(range.left > right) {

                rightPos = midPos - 1;
                continue;
            }
            
            if(range.right < left) {
                leftPos = midPos + 1;
                continue;
            }
            
            return range.left <= left && range.right >= right;
        }
        
        return false;
    }
    
    public void RemoveRange(int left, int right) {
        var newList = new List<(int left, int right)>();
        
        if(ranges.Count == 0) {
            return;
        }
        
        
        for(int i = 0; i < ranges.Count; i++) {
            var range = ranges[i];
            
            if(range.left >= right || range.right <= left) {
                newList.Add(range);
                continue;
            }
            
            if(left > range.left) {
                newList.Add((range.left, left));
            }
            
            if(right < range.right) {
                newList.Add((right, range.right));
            }
        }

        ranges = newList;
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);
 */