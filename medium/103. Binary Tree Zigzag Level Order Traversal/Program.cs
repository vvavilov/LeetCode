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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        if(root == null) {
            return new List<IList<int>>();
        }
        
        List<IList<int>> result = new();
        
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        var leftToRight = true;
        
        while(queue.Count > 0) {
            LinkedList<int> levelList = new();
            var levelCount = queue.Count;
            
            for(int i = 0; i < levelCount; i++) {
                var node = queue.Dequeue();
                if(leftToRight) {
                    levelList.AddLast(node.val);
                } else {
                    levelList.AddFirst(node.val);
                }
                
                if(node.left != null) {
                    queue.Enqueue(node.left);
                }
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            
            result.Add(levelList.ToList());
            leftToRight = !leftToRight;
        }
        
        return result;

    }
}