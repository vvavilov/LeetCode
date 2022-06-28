public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var i = m - 1;
        var j = nums2.Length - 1;
        var current = nums1.Length - 1;
        
        while(i >= 0 && j >=0) {
            if(nums1[i] > nums2[j]) {
                nums1[current] = nums1[i];
                i--;
            } else {
                nums1[current] = nums2[j];
                j--;
            }
            current--;
        }
        
        while(j >= 0) {
            nums1[current] = nums2[j];
            current--;
            j--;
        }
    }
}