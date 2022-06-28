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
        return BuildTree(nums, 0, nums.Length - 1);
    }

    private TreeNode BuildTree(int[] nums, int start, int end) {
        if(end < start) {
            return null;
        }
        
        var mid = (end - start) / 2 + start;
        
        var node = new TreeNode(nums[mid]);
        node.left = BuildTree(nums, start, mid -1);
        node.right = BuildTree(nums, mid+1, end);
        
        return node;
        
    }
}