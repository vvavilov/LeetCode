public class Solution {
    public bool Search(int[] nums, int target) {
        if(nums.Length == 0) {
            return false;
        }
        
        if(nums.Length == 1) {
            return target == nums[0];
        }
        
        var start = 0;
        var end = nums.Length - 1;
        
        
        bool IsMidInHead(int mid) {
            var first = nums[start];
            var midVal = nums[mid];
            
            if(midVal > first) {
                return true;
            }
            
            if(midVal < first) {
                return false;
            }
            
            return false;
        }
        
        
        while(start <= end) {
            Console.WriteLine("{0}, {1}", start, end);
            
            var mid = (end - start) / 2 + start;
            var midVal = nums[mid];
            
            if(midVal == target) {
                return true;
            }
            
                    
            var targetInHead = target >= nums[start];

            if(midVal == nums[start]) {
                start++;
                continue;
            }
            
            var midInHead = IsMidInHead(mid);
            
            if(midInHead && !targetInHead) {
                start = mid + 1;
                continue;
            }
            
            if(!midInHead && targetInHead) {
                end = mid - 1;
                continue;
            }

            if(target > midVal) {
                start = mid + 1;
            } else {
                end = mid - 1;
            }
            
            
        }
        
        return false;
    }
    
    
}