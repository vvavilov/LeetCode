public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var queue = new PriorityQueue((parent, child) => parent <= child);
        var byFrequency = GroupByFrequency(nums);
        
        foreach(var pair in byFrequency) {
            queue.Add(pair);

            if(queue.Count > k) {
                queue.ExtractMax();
            }
            
        }
        
        List<int> result = new();
        
        while(queue.Count > 0) {
            result.Add(queue.ExtractMax().Key);
        }
        return result.ToArray();
    }
    
    private Dictionary<int, int> GroupByFrequency(int[] nums) {
        Dictionary<int, int> result = new();
        
        foreach(var x in nums) {
            result.TryGetValue(x, out var freq);
            result[x] = freq + 1;
        }
        
        return result;
    }
}

public class PriorityQueue {
    public PriorityQueue(Func<int,int,bool> comparator) {
        Comparator = comparator;
    }
    
    private List<KeyValuePair<int, int>> impl = new();
    
    public KeyValuePair<int, int> ExtractMax() {
        if(Count < 0) {
            throw new Exception();
        }
        
        var val = impl[0];
        Swap(0, Last);
        impl.RemoveAt(Last);
        Heapify(0);
        return val;
    }
    
    public void Add(KeyValuePair<int, int> pair) {
        impl.Add(pair);
        
        if(Count == 1) {
            return;
        }

        var cur = Last;
        var parent = Parent(Last);
        
        while(cur > 0 && !Comparator(Frequency(parent), Frequency(cur))) {
            Swap(cur, parent);
            cur = parent;
            parent = Parent(cur);
        }
    }
    
    private Func<int, int, bool> Comparator { get; }
    
    private void Heapify(int pos) {        
        var leftPos = Left(pos); 
        
        if(!HasNode(leftPos)) {
            return;
        }
        
        var parentCandidate = pos;
        
        if(!Comparator(Frequency(parentCandidate), Frequency(leftPos))) {
            parentCandidate = leftPos;
        }
        
        var rightPos = Right(pos);
        

        if(HasNode(rightPos) && !Comparator(Frequency(parentCandidate), Frequency(rightPos))) {
            parentCandidate = rightPos;
        }
        
        if(parentCandidate == pos) {
            return;
        }
        
        Swap(parentCandidate, pos);
        Heapify(parentCandidate);
    }
    
    private void Swap(int x, int y) {
        var temp = impl[x];
        impl[x] = impl[y];
        impl[y] = temp;
    }
    
    private bool HasNode(int pos) => pos < Count;
    
    private int Left(int pos) => pos * 2 + 1;
    
    private int Right(int pos) => pos * 2 + 2;
    
    private int Parent(int pos) => (pos - 1) / 2;
    
    private int Frequency(int pos) => impl[pos].Value;
    
    private int Last => Count - 1;    
    
    public int Count => impl.Count;
}