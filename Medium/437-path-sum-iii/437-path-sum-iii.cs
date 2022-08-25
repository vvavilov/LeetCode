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
    int callsCount = 0;
    
    public int PathSum(TreeNode root, int targetSum) {
        var r =  Recursive(root, new List<int> {targetSum}, targetSum);
        return r;

    }
    
    private int Recursive(TreeNode node, List<int> targets, int target) {
        if(node == null) {
            return 0;
        }
        
        var count = 0;
        
        var childTargets = new List<int>();

        foreach(var x in targets) {

            if(x == node.val) {
                count++;
            }
            
            if(node.val > 0 && Int32.MinValue + node.val > x) {
                continue;
            }
            
            childTargets.Add(x - node.val);
        }
        
        childTargets.Add(target);
        
        count += Recursive(node.left, childTargets, target);
        count += Recursive(node.right, childTargets, target);
        
        return count;
    }
}