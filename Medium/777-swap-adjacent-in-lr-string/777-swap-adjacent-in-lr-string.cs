public class Solution {
    public bool CanTransform(string start, string end) {
        var startArray = start.ToCharArray();
        var endArray = end.ToCharArray();
        
        if (start.Length != end.Length) {
            return false;
        }
        
        for(int i = 0; i < start.Length; i++) {
            var curStart = startArray[i];
            var curEnd = endArray[i];
            
            if(curEnd == 'R') {
                if(curStart == 'R') {
                    continue;
                }
                
                return false;
            }
            
            if(curEnd == 'X') {
                var curPos = i;

                while(curPos < startArray.Length && startArray[curPos] == 'R') {
                    curPos++;
                }
                
                if(curPos < startArray.Length && startArray[curPos] == 'X') {
                    Swap(startArray, i, curPos);
                    continue;
                }
                
                return false;
            }
            
            if(curEnd == 'L') {
                var curPos = i;

                while(curPos < startArray.Length && startArray[curPos] == 'X') {
                    curPos++;
                }
                
                if(curPos < startArray.Length && startArray[curPos] == 'L') {
                    Swap(startArray, i, curPos);
                    continue;
                }
                
                return false;
            }
        }
        
        return true;
    }
    
    private void Swap(char[] arr, int left, int right) {
        var temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
    }
}