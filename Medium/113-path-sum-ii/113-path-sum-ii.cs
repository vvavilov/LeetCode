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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        LinkedList<IList<int>> result = new();
        BacktrackingDfs(root, targetSum, new LinkedList<int>(), result);
        return result.ToList();
    }
    
    private void BacktrackingDfs(TreeNode node, int targetSum, LinkedList<int> acc, LinkedList<IList<int>> result) {
        if(node == null) {
            return;
        }
        
        acc.AddLast(node.val);
        targetSum = targetSum - node.val;

        var isLeaf = node.left == null && node.right == null;

        if(isLeaf && targetSum == 0) {
            result.AddLast(new List<int>(acc));
        }
        
        BacktrackingDfs(node.left, targetSum, acc, result);
        BacktrackingDfs(node.right, targetSum, acc, result);
        acc.RemoveLast();
    }
}