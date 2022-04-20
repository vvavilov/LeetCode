static int SearchInsert(int[] nums, int target) {
    var start = 0;
    var end = nums.Length - 1;
    
    while (start <= end) {
        var mid = (end - start) /2 + start;
        if(nums[mid] == target) {
            return mid;
        }
        if(nums[mid] > target) {
            end = mid - 1;
        } else {
            start = mid + 1;
        }
    }
    
    return start;
}