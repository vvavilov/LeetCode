public class SparseVector {
    public List<(int id, int value)> Items { get; set; } = new();
    
    public SparseVector(int[] nums) {
        for(var i = 0; i < nums.Length; i++) {
            if(nums[i] == 0) {
                continue;
            }
            
            Items.Add((i, nums[i]));
        }
        
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        var thisPos = 0;
        var otherPos = 0;
        var result = 0;

        while(thisPos < Items.Count && otherPos < vec.Items.Count) {
            (var thisId, var thisValue) = Items[thisPos];
            (var otherId, var otherValue) = vec.Items[otherPos];

            if(thisId == otherId) {
                result += thisValue * otherValue;
                thisPos++;
                otherPos++;
                continue;
            }

            if(thisId < otherId) {
                thisPos++;
                continue;
            }

            otherPos++;
        }
        
        return result;
        
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);