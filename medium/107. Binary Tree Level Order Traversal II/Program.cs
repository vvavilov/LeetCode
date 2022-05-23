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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        if(root == null) {
            return new List<IList<int>>();
        }
    
        List<IList<int>> result = new();
        RecursiveBfs(new List<TreeNode> { root }, result);
        
        return result;
        
    }
    
    private void RecursiveBfs(IList<TreeNode> nodesOfLevel, List<IList<int>> result) {
        if(nodesOfLevel.Count == 0) {
            return;
        }
        
        var items = new List<int>();

        List<TreeNode> nextLevelNodes = new();
        
        foreach(var x in nodesOfLevel) {
            items.Add(x.val);

            if(x.left != null) {
                nextLevelNodes.Add(x.left);
            }
            
            if(x.right != null) {
                nextLevelNodes.Add(x.right);
            }
        }
        
        RecursiveBfs(nextLevelNodes, result);
        result.Add(items);

    }
}