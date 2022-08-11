public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        if(arr.Length == 0) {
            return 0;
        }
        
        var partitionMax = new Stack<int>();
        partitionMax.Push(arr[0]);

        for(int i = 1; i < arr.Length; i++) {
            var cur = arr[i];
            var max = Math.Max(partitionMax.Peek(), cur);
            
            while(partitionMax.Count > 0 && partitionMax.Peek() > cur) {
                partitionMax.Pop();
            }
            
            partitionMax.Push(max);
        }

        return partitionMax.Count;
    }
}
