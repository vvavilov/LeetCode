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
    public bool IsValidBST(TreeNode node, int? min = null, int? max = null) {
        if(node == null) {
            return true;
        }
        
        var validSelf = true;
        
        if(min != null && node.val <= min) {
            validSelf = false;
        }
        
        if(max != null && node.val >= max) {
            validSelf = false;
        }
        
        return validSelf
            && IsValidBST(node.left, min, node.val)
            && IsValidBST(node.right, node.val, max);
    }
}