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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var result = new List<IList<int>>();
        var dict = new Dictionary<int, IList<int>>();
        var queue = new Queue<(TreeNode node, int order)>();
        var min = Int32.MaxValue;
        var max = Int32.MinValue;
        
        if(root == null) {
            return result;
        }
        
        queue.Enqueue((root, 0));
        
        while(queue.Count > 0) {
            (var node, var order) = queue.Dequeue();
            
            if(!dict.ContainsKey(order)) {
                dict[order] = new List<int>();
            }

            dict[order].Add(node.val);
            min = Math.Min(min, order);
            max = Math.Max(max, order);
            
            if(node.left != null) {
                queue.Enqueue((node.left, order - 1));
            }
            
            if(node.right != null) {
                queue.Enqueue((node.right, order + 1));
            }
        }
        
        for(int i = min; i <= max; i++) {
            if(!dict.ContainsKey(i)) {
                continue;
            }
            
            result.Add(dict[i]);
        }
        
        return result;
    }
    
}