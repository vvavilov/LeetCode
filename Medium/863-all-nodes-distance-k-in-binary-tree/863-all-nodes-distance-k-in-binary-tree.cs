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
        Dictionary<TreeNode, TreeNode> parents = new();
        parents[root] = null;
        BuildParents(root, parents);
        List<int> result = new();
        FindAt(target, k, result, new HashSet<int>(), parents);
        return result;
    }
    
    private void FindAt(TreeNode node, int k, List<int> result, HashSet<int> visited, Dictionary<TreeNode, TreeNode> parents) {
        if(node == null) {
            return;
        }
        
        if(visited.Contains(node.val)) {
            return;
        }
        
        visited.Add(node.val);
        
        if(k == 0) {
            result.Add(node.val);
        }
        
        FindAt(node.left, k - 1, result, visited, parents);
        FindAt(node.right, k - 1, result, visited, parents);
        FindAt(parents[node], k - 1, result, visited, parents);


    }   

    private void BuildParents(TreeNode node, Dictionary<TreeNode, TreeNode> parents) {
        if(node.left != null) {
            parents[node.left] = node;
            BuildParents(node.left, parents);
        }
        
        if(node.right != null) {
            parents[node.right] = node;
            BuildParents(node.right, parents);

        }
    }
    
}