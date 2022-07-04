public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        MaxHeap queue = new();
        
        for(int i = 0; i < points.Length; i++) {
            var point = points[i];
            var distance = point[0] * point[0] + point[1] * point[1];
            
            queue.Enqueue(points[i], distance);
            
            if(queue.Count > k) {
                queue.Dequeue();
            }
        }
        
        var result = new int[k][];
        
        var pos = 0;
        while(queue.Count > 0) {
            result[pos++] = queue.Dequeue();
        }
        
        return result;
    }
}

public class MaxHeap {
    private PriorityQueue<int[], int> _impl = new(new MaxHeapComparator());
    
    public void Enqueue(int[] value, int priority) => _impl.Enqueue(value, priority);
    
    public int[] Dequeue() => _impl.Dequeue();
    
    public int Count => _impl.Count;
    
    class MaxHeapComparator : IComparer<int> {
        public int Compare(int child, int parent) {
            if(child == parent) {
                return 0;
            }
            
            if(child > parent) {
                return -1;
            }
            
            return 1;
        }
    }
}