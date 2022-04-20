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
/*
 1. dfs
 2. on every level calculate current sum and go deeper until node is leaf
 3. if node is leaf calculate total sum and return if it's rqual to target.
               1
               
     2                   3
     
4          5                  6
*/
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