static void MoveZeroes(int[] nums) {
    var nextNonZero = 0;
    for(int i = 0; i < nums.Length; i++) {
        if(nums[i] != 0) {
            nums[nextNonZero++] = nums[i];
        }
    }
    
    while(nextNonZero < nums.Length) {
        nums[nextNonZero++] = 0;
    }
    
    
}

static void MoveZeroesExtraMemory(int[] nums) {
    var zerosCount = nums.Count(x => x == 0);
    var result = nums.Where(x => x != 0).ToList();
    while(zerosCount > 0) {
        result.Add(0);
        zerosCount--;
    }
    
    for (int i = 0; i < nums.Length;i++) {
        nums[i] = result[i];
    }
}