/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums.Length == 0) {
            return null;
        }
        
        return Recursive(nums, 0, nums.Length - 1);
    }
    
    private TreeNode Recursive(int[] nums, int start, int end) {
        if(start > end) {
            return null;
        }
        
        var mid = ( end - start ) / 2 + start;
        
        var root = new TreeNode(nums[mid]);
        root.left = Recursive(nums, start, mid - 1);
        root.right = Recursive(nums, mid + 1, end);
        
        return root;
    }
}