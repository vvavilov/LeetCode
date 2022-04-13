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
 
 starting with root, dfs. 
 check if equal to subtree recursievely
  if not -> go next;
 
            3
            
    4                5                                 4
                                                     1   2
    
1         2                                      
 
        0
 * }
 */
public class Solution {
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot == null) {
            return true;
        }
        
        if(root == null) {
            return false;
        }
    
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        
        while(stack.Count > 0) {
            var node = stack.Pop();
            
            if(IsSubtreeImpl(node, subRoot)) {
                return true;
            }
            
            if(node.left != null) {
                stack.Push(node.left);
            }
            
            if(node.right != null) {
                stack.Push(node.right);
            }
        }
        
        return false;
        
    }
    
    private bool IsSubtreeImpl(TreeNode node, TreeNode subNode) {
        if(subNode == null && node == null) {
            return true;
        }
        
        if(node?.val != subNode?.val) {
            return false;
        }
        
        return IsSubtreeImpl(node?.left, subNode.left) && IsSubtreeImpl(node?.right, subNode.right);
    }
}