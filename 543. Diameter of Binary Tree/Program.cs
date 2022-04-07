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
 
        1
    
    2        3

  4    5
 */
public class Solution {
    int maxDiameter = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        Diameter(root);
        
        return maxDiameter;
    }
    
    private int Diameter(TreeNode root) {
        if(root is null) {
            return 0;
        }
        
        var leftLength = Diameter(root.left);
        var rightLength = Diameter(root.right);
        
        
        maxDiameter = Math.Max(maxDiameter, leftLength + rightLength);
        return Math.Max(leftLength, rightLength) + 1;
    }
}