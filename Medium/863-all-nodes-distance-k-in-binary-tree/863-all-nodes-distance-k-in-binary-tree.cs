/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        Dictionary<int, TreeNode> parents = new();
        FillParents(root, parents);
        
        var distance = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(target);
        
        List<int> result = new();
        HashSet<int> visited = new();
        
        while(queue.Count > 0) {
            var count = queue.Count;
            
            for(int i = 0; i < count; i++) {
                var node = queue.Dequeue();
                
                if(visited.Contains(node.val)) {
                    continue;
                }
                
                if(k == distance) {
                    result.Add(node.val);
                    continue;
                }
                
                visited.Add(node.val);
                parents.TryGetValue(node.val, out var parent);
                
                if(parent != null) {
                    queue.Enqueue(parent);
                }
                
                if(node.left != null) {
                    queue.Enqueue(node.left);
                }
                
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            
            distance++;
        }
        
        return result;
        
    }
    
    private void FillParents(TreeNode node, Dictionary<int, TreeNode> parents) {
        if(node.left != null) {
            parents[node.left.val] = node;
            FillParents(node.left, parents);
        }
        
        if(node.right != null) {
            parents[node.right.val] = node;
            FillParents(node.right, parents);
        }
    } 
}