public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var pq = new PriorityQueue<int, int>(new MaxHeapComparer());
        foreach(var x in nums) {
            pq.Enqueue(x, x);
            
            if(pq.Count > k) {
                pq.Dequeue();
            }
        }
        
        return pq.Dequeue();
    }
}

public class MaxHeapComparer : IComparer<int> {
    public int Compare(int parent, int child) {
        if(parent == child) {
            return 0;
        }
        
        if(parent > child) {
            return 1;
        }
        
        return -1;
    }
}