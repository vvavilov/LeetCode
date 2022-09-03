
public class MovingAverage {
    private LinkedList<int> items = new();
    private int maxSize = 0;
    private int currentSize = 0;
    private double sum = 0;
    
    public MovingAverage(int size) {
        maxSize = size;
    }
    
    public double Next(int val) {
        if(currentSize == maxSize) {
            sum -= items.First.Value;
            items.RemoveFirst();
        }

        items.AddLast(val);
        sum += val;
        currentSize = Math.Min(currentSize + 1, maxSize);

        return sum / currentSize;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */