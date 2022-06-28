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
    public bool HasPathSum(TreeNode root, int targetSum, int parentSum = 0) {


        if(root is null) {
            return false;
        }
        
        var currentSum = parentSum + root.val;
        
        if(root.left == null && root.right == null) {
            return currentSum == targetSum;
        }
        
        return HasPathSum(root.left, targetSum, currentSum)
            || HasPathSum(root.right, targetSum, currentSum);
        
    }
}