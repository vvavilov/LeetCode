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
    public IList<IList<int>> FindLeaves(TreeNode root) {
        List<IList<int>> byOrder = new();
        Traverse(root, byOrder);
        
        return byOrder;
    }
    
    // returns maxOrder
    private int Traverse(TreeNode node, List<IList<int>> byOrder) {
        if(node == null) {
            return -1;
        }
        
        var leftOrder = Traverse(node.left, byOrder);
        var rightOrder = Traverse(node.right, byOrder);
        var selfOrder = Math.Max(leftOrder, rightOrder) + 1;
        
        if(byOrder.Count == selfOrder) {
            byOrder.Add(new List<int>());
        }
        
        byOrder[selfOrder].Add(node.val);
        return selfOrder;
    }
}