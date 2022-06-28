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
 
                    1                              1
            2             3                 2 
      4                       5          3      4
 * }
 */
public class Solution {
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        if(root1 == null) {
            return root2;
        }
        
        if(root2 == null) {
            return root1;
        }
        
        var node = new TreeNode(root1.val + root2.val);
        node.left = MergeTrees(root1.left, root2.left);
        node.right = MergeTrees(root1.right, root2.right);
        
        return node;
    }
}