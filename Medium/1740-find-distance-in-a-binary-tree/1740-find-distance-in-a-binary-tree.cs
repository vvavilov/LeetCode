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
    private int result = -1;

    public int FindDistance(TreeNode root, int p, int q) {
        Dfs(root, p, q);
        return result;
    }
    
    private int Dfs(TreeNode node, int p,  int q) {
        if(node == null) {
            return -1;
        }
        
        var left = Dfs(node.left, p, q);
        var right = Dfs(node.right, p, q);
        
        if(left >= 0 && right >= 0) {
            result = left + right;
            return -1;
        }
        
        var childDistance = left >= 0 ? left : right;
        
        if(node.val == p && node.val == q) {
            result = 0;
            return -1;
        }
        
        if(node.val == q || node.val == p) {
            if(childDistance >= 0) {
                result = childDistance;
                return -1;
            }
            
            return 1;
        }
        
        return childDistance >= 0 ? childDistance + 1 : -1;
        
    }
}