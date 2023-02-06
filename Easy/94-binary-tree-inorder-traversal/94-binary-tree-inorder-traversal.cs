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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new();
        Traverse(root, result);
        return result;
    }
    
    private void Traverse(TreeNode node, List<int> result) {
        if(node == null) {
            return;
        }
        
        Traverse(node.left, result);
        result.Add(node.val);
        Traverse(node.right, result);
    }
}