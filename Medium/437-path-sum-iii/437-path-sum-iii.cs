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
    private int count;

    public int PathSum(TreeNode root, int targetSum) {
        DfsPossibleSums(root, targetSum);
        
        return count;
    }
    
    public List<int> DfsPossibleSums(TreeNode node, int targetSum) {
        if(node == null) {
            return new List<int>();
        }
        
        if(node.val == targetSum) {
            count++;
        }
        
        var leftSums = DfsPossibleSums(node.left, targetSum);
        var rightSums = DfsPossibleSums(node.right, targetSum);
        List<int> sums = new();

        foreach(var x in leftSums) {
            var value = x + node.val;
            
            if(value == targetSum) {
                count++;
            }
            
            sums.Add(value);
        }
        
        foreach(var x in rightSums) {
            var value = x + node.val;
            
            if(value == targetSum) {
                count++;
            }
            
            sums.Add(value);
        }
        
        sums.Add(node.val);
        return sums;
    }
}