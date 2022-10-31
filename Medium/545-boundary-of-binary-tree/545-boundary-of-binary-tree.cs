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
 
 
                            1
            2                               3
    4               5               6           n
n       n       7         8      9     10
               
 
 */
public class Solution {
    public IList<int> BoundaryOfBinaryTree(TreeNode root) {
        List<int> boundaries = new();
        GetTopBoundaries(root, boundaries);
        GetLeftBoundaries(root, null, boundaries);
        GetBottomBoundaries(root, null, boundaries);
        GetRightBoundaries(root, null, boundaries);
        return boundaries;
    }
    
    
    private void GetTopBoundaries(TreeNode node, IList<int> boundaries) {
        boundaries.Add(node.val);
    }
    
    private void GetLeftBoundaries(TreeNode node, TreeNode parent, IList<int> boundaries) {
        if(parent == null && node.left == null) {
            return;
        }
        
        TreeNode boundary = null;
        
        if(node.left != null) {
            if(!IsLeaf(node.left)) {
                boundary = node.left;
            }
            
        } else if(node.right != null && !IsLeaf(node.right)) {
            boundary = node.right;
        }
        
        if(boundary != null) {
            boundaries.Add(boundary.val);
            GetLeftBoundaries(boundary, node, boundaries);
        }
    }
    
    
    private void GetBottomBoundaries(TreeNode node, TreeNode parent, IList<int> boundaries) {
        if(node == null) {
            return;
        }
        
        if(!IsLeaf(node)) {
            GetBottomBoundaries(node.left, node, boundaries);
            GetBottomBoundaries(node.right, node, boundaries);
        } else {
            if(parent != null) {
                boundaries.Add(node.val);
            }
        }
    }
    
    
    private void GetRightBoundaries(TreeNode node, TreeNode parent, IList<int> boundaries) {
        if(parent == null && node.right == null) {
            return;
        }
        
        TreeNode boundary = null;
        
        if(node.right != null) {
            if(!IsLeaf(node.right)) {
                boundary = node.right;
            }   
        } else if(node.left != null && !IsLeaf(node.left)) {
            boundary = node.left;
        }
        
        if(boundary != null) {
            GetRightBoundaries(boundary, node, boundaries);
            boundaries.Add(boundary.val);
        }
    }
    
    private bool IsLeaf(TreeNode node) {
        return node.left == null && node.right == null;
    }
}