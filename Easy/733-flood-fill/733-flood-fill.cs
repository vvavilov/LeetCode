/*
0 0 0
0 1 1


*/
public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        var initialColor = image[sr][sc];
        var queue = new Queue<(int y, int x)>();
        queue.Enqueue((sr, sc));
        
        while(queue.Count > 0) {
            (var y, var x) = queue.Dequeue();
            if(y < 0 || x < 0 || y >=image.Length || x >= image[0].Length) { continue; }
            if(image[y][x] == initialColor && image[y][x] != newColor) {
                image[y][x] = newColor;
                queue.Enqueue((y-1,x));
                queue.Enqueue((y+1,x));
                queue.Enqueue((y,x-1));
                queue.Enqueue((y,x+1));

            }
        }
        
        return image;
        
        
    }
}