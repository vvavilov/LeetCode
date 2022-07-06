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
    public int WidthOfBinaryTree(TreeNode root) {
        if(root == null) {
            return 0;
        }
        
        var width = 0;
        Queue<(TreeNode node, int pos)> queue = new();
        queue.Enqueue((root, 0));
        
        while(queue.Count > 0) {
            var count = queue.Count;
            var startPosition = -1;
            var currentPosition = -1;
            
            for(int i = 0; i < count; i++) {
                (var node, var pos) = queue.Dequeue();
                
                if(startPosition == -1) {
                    startPosition = pos;
                }
                
                currentPosition = pos;
                
                if(node.left != null) {
                    queue.Enqueue((node.left, LeftPos(pos)));
                }
                
                if(node.right != null) {
                    queue.Enqueue((node.right, RightPos(pos)));
                }                
            }
            
            width = Math.Max(width, currentPosition - startPosition + 1);
        }
        
        return width;
    }
    
    private int LeftPos(int pos) => pos * 2 + 1;
    private int RightPos(int pos) => pos * 2 + 2;
}