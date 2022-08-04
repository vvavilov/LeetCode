public class Solution {
    public int MirrorReflection(int p, int q) {
        double roomsVerticalCount = 0;
        double roomsHorizontalCount = 1;

        while(roomsVerticalCount * p / ( roomsHorizontalCount  * q) != 1) {
            roomsVerticalCount++;
            
            while(roomsVerticalCount * p > roomsHorizontalCount * q) {
                roomsHorizontalCount++;
            }
            
        }
        
        var verticalFlipsCount = roomsVerticalCount - 1;
        var horizontalFlipsCount = roomsHorizontalCount - 1;
        var verticalFlipped = verticalFlipsCount % 2 != 0;
        var horizontalFlipped = horizontalFlipsCount % 2 != 0;
        
        if(!verticalFlipped && !horizontalFlipped) {
            return 1;
        }
        
        if(verticalFlipped && !horizontalFlipped) {
            return 0;
        }
        
         if(!verticalFlipped && horizontalFlipped) {
            return 2;
        }
        
        return -1;
    }
}