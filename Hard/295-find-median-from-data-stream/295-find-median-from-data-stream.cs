public class MedianFinder {
    PriorityQueue<int, int> biggest = new();
    PriorityQueue<int, int> smallest = new(Comparer<int>.Create((x,y) => y - x));

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        biggest.Enqueue(num,num);
        var min = biggest.Dequeue();
        smallest.Enqueue(min, min);
                
        if(smallest.Count > biggest.Count) {
            var max = smallest.Dequeue();
            biggest.Enqueue(max, max);
        }
    }
    
    public double FindMedian() {
        if(biggest.Count == smallest.Count) {
            return (biggest.Peek() + smallest.Peek()) / 2d;
        }
    
        return biggest.Peek();
    }
}


/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 
 
 biggest
 -1 -2 -3
 
 lower
 -4 -5
 
 */
   