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
    private ParentSource parents;
    private int[] inorder;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        parents = new ParentSource(preorder);
        this.inorder = inorder;
        return BuildSubtree(0, inorder.Length - 1);
    }
    
    private TreeNode BuildSubtree(int leftPos, int rightPos) {
        Console.WriteLine("subtree: {0}, {1}", leftPos, rightPos);
        if(rightPos < leftPos) {
            return null;
        }
        
        var parent = parents.Next;
        var posOfParent = FindInorderPosition(leftPos, rightPos, parent);
        
        var parentNode = new TreeNode(parent);
        
        parentNode.left = BuildSubtree(leftPos, posOfParent - 1);
        parentNode.right = BuildSubtree(posOfParent + 1, rightPos);
        
        return parentNode;
    }
    
    private int FindInorderPosition(int left, int right, int value) {
        for(int i = left; i <= right; i++) {
            if(inorder[i] == value) {
                return i;
            }
        }
        
        throw new Exception("node is not found");
    }
}

public class ParentSource {
    private int pos;
    private int[] parents;
    
    public ParentSource(int[] parents) {
        this.parents = parents;
        pos = 0;
    }
    
    public int Next => parents[pos++];
}