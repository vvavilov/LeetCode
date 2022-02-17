class Solution {
    int oldColor;
    int newColor;
    int[][] image;

    int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        oldColor = image[sr][sc];
        this.newColor = newColor;
        this.image = image;
        
        Flood(sr, sc);
        
        return image;
    }

    void Flood(int sr, int sc) {
        if (image[sr][sc] == newColor || image[sr][sc] != oldColor) {
            return;
        }
        image[sr][sc] = newColor;
        
        var leftX = sc - 1;
        if(leftX >= 0) {
            Flood(sr, leftX);
        }
        
        
        var topY = sr - 1;
        if(topY >= 0) {
            Flood(topY, sc);
        }
        
        
        var rightX = sc + 1;
        if(rightX < image[sr].Length) {
            Flood(sr, rightX);
        }
        
        var bottomY = sr + 1;
        if(bottomY < image.Length) {
            Flood(bottomY, sc);
        }
    }
}