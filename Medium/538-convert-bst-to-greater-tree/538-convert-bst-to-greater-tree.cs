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
    public TreeNode ConvertBST(TreeNode root) {
        Dfs(root, 0);
        return root;
    }

    private int Dfs(TreeNode node, int baseSum) {
        if(node == null) {
            return baseSum;
        }

        int rightResult = Dfs(node.right, baseSum);
        node.val = rightResult + node.val;
        int leftResult = Dfs(node.left, node.val);
        return leftResult;
    }
}