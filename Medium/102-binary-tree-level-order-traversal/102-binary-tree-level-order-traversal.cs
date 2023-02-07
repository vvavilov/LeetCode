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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        List<IList<int>> result = new();
        
        if(root == null) {
            return result;
        }
        
        Queue<TreeNode> toProcess = new();
        toProcess.Enqueue(root);
        
        while(toProcess.Count > 0) {
            var levelCount = toProcess.Count;
            List<int> perLevel = new();
            
            while(levelCount-- > 0) {
                var node = toProcess.Dequeue();
                perLevel.Add(node.val);
                
                if(node.left != null) {
                    toProcess.Enqueue(node.left);
                }
                
                if(node.right != null) {
                    toProcess.Enqueue(node.right);
                }
            }
            
            
            result.Add(perLevel);
        }
        
        return result;
    }
}