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
        var list = new List<int>();
        if(root == null) {
            return list;
        }
        var stack = new Stack<TreeNode>();
        
        
        // stack.Push(root);
        var current = root;
        
        while(stack.Count > 0 || current != null) {
            while(current != null) {
                stack.Push(current);
                current = current.left;
            }
            
            var node = stack.Pop();
            list.Add(node.val);
            current = node.right;
        }
        
        
        return list;
    }
}