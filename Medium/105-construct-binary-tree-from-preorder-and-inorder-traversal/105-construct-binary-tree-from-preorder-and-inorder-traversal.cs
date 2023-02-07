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
    int[] preorder;
    int[] inorder;
    int preorderPos = 0;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        this.preorder = preorder;
        this.inorder = inorder;
        return RecursiveImpl(0, preorder.Length - 1);
    }
    
    private TreeNode RecursiveImpl(int leftInorder, int rightInorder) {
        if(rightInorder < leftInorder) {
            return null;
        }

        if(leftInorder == rightInorder) {
            preorderPos++;
            return new TreeNode(inorder[leftInorder]);
        }
        
        var parent = new TreeNode(preorder[preorderPos]);
        var inorderParentPos = Array.FindIndex(inorder, x => x == parent.val);
        preorderPos++;
        parent.left = RecursiveImpl(leftInorder, inorderParentPos - 1);
        parent.right = RecursiveImpl(inorderParentPos + 1, rightInorder);
        return parent;
    }
        
/*

                    1
            2               3
    4            5      6        7
 8     9    10     11  12      13


preorder 1 2 4 9 5 10 11 3 6 12 7 13
inorder  (4 9) 2 (10 5 11)) 1 (12 6 3 13 7)





*/
        // preorder: 3 9 20 15 7
        // inorder: 9 3 15 20 7
}