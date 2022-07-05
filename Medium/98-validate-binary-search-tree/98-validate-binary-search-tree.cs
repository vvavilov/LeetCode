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
    public bool IsValidBST(TreeNode node) {
        return IsValid(node);
    }
    
    private bool IsValid(TreeNode node, int? minValue = null, int? maxValue = null) {
        if(node == null) {
            return true;
        }
        
        if(minValue is int min && node.val <= min) {
            return false;
        }
        
        if(maxValue is int max && node.val >= max) {
            return false;
        }
        
        return IsValid(node.left, minValue, node.val) && IsValid(node.right, node.val, maxValue);
    }
}