public class Solution {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        var queue = BuildInitialQueue(nums1, nums2, k);
        List<IList<int>> result = new();
        
        while(k-- > 0 && queue.Count > 0) {
            var pair = queue.Dequeue();
            result.Add(new List<int> { nums1[pair.FirstPos], nums2[pair.SecondPos] });
            
            if(pair.SecondPos + 1 == nums2.Length) {
                continue;
            }
            
            queue.Enqueue((pair.FirstPos, pair.SecondPos + 1), nums1[pair.FirstPos] + nums2[pair.SecondPos + 1]);
        }
    
        return result;
    }

    private PriorityQueue<(int FirstPos, int SecondPos), int> BuildInitialQueue(int[] nums1, int[] nums2, int k) {
        PriorityQueue<(int FirstPos, int SecondPos), int> queue = new();
        
        for(int i = 0; i < nums1.Length; i++) {
            if(queue.Count == k) {
                break;
            }

            queue.Enqueue((i, 0), nums1[i] + nums2[0]);
        }
        
        return queue;
    }
}