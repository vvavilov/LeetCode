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
    public bool IsSymmetric(TreeNode root) {
        if(root == null) {
            return true;
        }
        
        var leftStack = new Stack<TreeNode>();
        var rightStack = new Stack<TreeNode>();
        
        if(root.left != null) {
            leftStack.Push(root.left);
        }
        
        if(root.right != null) {
            rightStack.Push(root.right);
        }
        
        while(leftStack.Count > 0 && rightStack.Count > 0) {
            var leftNode = leftStack.Pop();
            var rightNode = rightStack.Pop();
            
            if(leftNode == null && rightNode == null) {
                continue;
            }
            
            if(leftNode?.val != rightNode?.val) {
                return false;
            }
            
            leftStack.Push(leftNode.left);
            leftStack.Push(leftNode.right);
            rightStack.Push(rightNode.right);
            rightStack.Push(rightNode.left);
        }
        
        
        return leftStack.Count == 0 && rightStack.Count == 0;
    }
    
    public bool IsSymmetricRecursive(TreeNode root) {
        if(root == null) {
            return true;
        }
        
        return Compare(root.left, root.right);
    }
    
    private bool Compare(TreeNode left, TreeNode right) {
        if(left == null && right == null) {
            return true;
        }
        
        if(left?.val != right?.val) {
            return false;
        }
        
        return Compare(left.left, right.right) && Compare(left.right, right.left);
    }
}

public class SolutionRecursive {
    public bool IsSymmetric(TreeNode root) {
        if(root == null) {
            return true;
        }
        
        return Compare(root.left, root.right);
    }
    
    private bool Compare(TreeNode left, TreeNode right) {
        if(left == null && right == null) {
            return true;
        }
        
        if(left?.val != right?.val) {
            return false;
        }
        
        return Compare(left.left, right.right) && Compare(left.right, right.left);
    }
}