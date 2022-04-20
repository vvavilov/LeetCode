static int[] TwoSumWithDictionary(int[] numbers, int target) {
    var hash = new Dictionary<int, int>();
    for(int i = 0; i < numbers.Length; i++) {
        var second = target - numbers[i];
        if(hash.ContainsKey(second)) {
            return new int[] { hash[second] + 1, i + 1 };
        }
        hash[numbers[i]] = i; 
    }
    return null;
}

static int[] TwoSum2Pointers(int[] numbers, int target) {
    var left = 0;
    var right = numbers.Length - 1;
    
    while (left < right) {
        var sum = numbers[left] + numbers[right];
        if(sum == target) return new int[] { left + 1, right + 1 };
        if(sum < target) { left++; continue; }
        right--;
    }
    
    return null;
}