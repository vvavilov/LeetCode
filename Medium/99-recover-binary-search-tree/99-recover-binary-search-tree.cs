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

/*
            1
        2       6
      4   3   5    7    



*/
public class Solution {
    private bool leftFound = false;
    private TreeNode left;
    private TreeNode right;
    
    public void RecoverTree(TreeNode root) {
        InorderTraversal(root, null);
        Swap(left, right);
    }
   
    private TreeNode InorderTraversal(TreeNode node, TreeNode prev) {
        if(node == null) {
            return prev;
        }
        
        
        prev = InorderTraversal(node.left, prev);
        
        if(prev != null && prev.val > node.val) {
            if(!leftFound) {
                left = prev;
                right = node;
                leftFound = true;
            } else {
                right = node;
            }
        }

        
        prev = InorderTraversal(node.right, node);
        return prev;
        
    }
    
    private void Swap(TreeNode left, TreeNode right) {
        var temp = left.val;
        left.val = right.val;
        right.val = temp;
    }
}