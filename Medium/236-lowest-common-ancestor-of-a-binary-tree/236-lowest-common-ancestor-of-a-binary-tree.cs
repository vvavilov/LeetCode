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
        if(node == p || node == q) {
            return node;
        }

        if(node == null) {
            return null;
        }

        var left = LowestCommonAncestor(node.left, p, q);
        var right = LowestCommonAncestor(node.right, p, q);

        if(left != null && right != null) {
            return node;
        }

        return left ?? right;
    }
}