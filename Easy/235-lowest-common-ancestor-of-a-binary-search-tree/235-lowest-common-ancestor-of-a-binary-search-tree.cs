/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q) {
        if(node.val == p.val || node.val == q.val) {
            return node;
        }
        
        if(q.val > node.val && p.val > node.val) {
            return LowestCommonAncestor(node.right, p, q);
        }
        
        if(q.val < node.val && p.val < node.val) {
            return LowestCommonAncestor(node.left, p, q);
        }
        
        return node;
    }
}