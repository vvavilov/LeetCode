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
        if(root == null) {
            return new List<IList<int>>();
        }

        List<IList<int>> result = new();
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        
        while(queue.Count > 0) {
            var levelSize = queue.Count;
            List<int> levelItems = new();

            for(int i = 0; i < levelSize; i++) {
                var node = queue.Dequeue();
                levelItems.Add(node.val);
                
                if(node.left != null) {
                    queue.Enqueue(node.left);
                }
                
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            
            result.Add(levelItems);
        }
        
        return result;
        
    }
}