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
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        if(nums.Length == 0) {
            return null;
        }
        
        Stack<TreeNode> parents = new();
        parents.Push(new TreeNode(Int32.MaxValue));
        
        for(int i = 0; i < nums.Length; i++) {
            var newNode = new TreeNode(nums[i]);
            var prevNode = parents.Pop();
            
            while(parents.Count > 0 && prevNode.val < newNode.val) {
                prevNode = parents.Pop();
            }
            
            newNode.left = prevNode.right;
            prevNode.right = newNode;
            parents.Push(prevNode);
            parents.Push(newNode);
        }
        
        while(parents.Count > 1) {
            parents.Pop();
        }
        
        return parents.Pop().right;
    }
}