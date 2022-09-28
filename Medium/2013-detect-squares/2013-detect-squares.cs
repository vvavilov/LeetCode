public class DetectSquares {
    private Dictionary<int, int> xCount = new();
    private Dictionary<int, int> yCount = new();
    private Dictionary<(int y, int x), int> points = new();

    public DetectSquares() {
        
    }
    
    public void Add(int[] point) {
        (int y, int x) pointTuple = (point[0], point[1]);
        points.TryGetValue(pointTuple, out var count);
        points[pointTuple] = count + 1;
        
        xCount.TryGetValue(pointTuple.x, out var x);
        xCount[pointTuple.x] = x + 1;
        
        yCount.TryGetValue(pointTuple.y, out var y);
        yCount[pointTuple.y] = y + 1;

    }
    
    public int Count(int[] point) {
        var total = 0;
        (int y, int x)  pointTuple = (point[0], point[1]);

        foreach(var diagonal in points.Keys) {
            if(pointTuple.x == diagonal.x && pointTuple.y == diagonal.y) {
                continue;
            }
            
            if(Math.Abs(pointTuple.y - diagonal.y) != Math.Abs(pointTuple.x - diagonal.x)) {
                continue;
            }
            
            points.TryGetValue((diagonal.y, pointTuple.x), out var count1);
            points.TryGetValue((pointTuple.y, diagonal.x), out var count2);

            
            xCount.TryGetValue(pointTuple.x, out var x);
            yCount.TryGetValue(pointTuple.y, out var y);

            total += points[diagonal] * count1 * count2;
        } 
        
        return total;
    }
}

/**
 * Your DetectSquares object will be instantiated and called as such:
 * DetectSquares obj = new DetectSquares();
 * obj.Add(point);
 * int param_2 = obj.Count(point);
 */