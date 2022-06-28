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
    private int diameter = 0;
    
    public int DiameterOfBinaryTree(TreeNode root) {
        DiameterDfs(root);
        return diameter;
    }
    
    private int DiameterDfs(TreeNode node) {
        if(node == null) {
            return 0;
        }
        
        var leftPathSize = DiameterDfs(node.left);
        var rightPathSize = DiameterDfs(node.right);
        
        diameter = Math.Max(diameter, leftPathSize + rightPathSize);
        
        return Math.Max(leftPathSize, rightPathSize) + 1;
        
        
    }
}