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
    public int KthSmallest(TreeNode root, int k) {
        return GetOrderOrReturnValue(root, k, 0).value;
    }
    
    private (int parentOrder, int value) GetOrderOrReturnValue(TreeNode node, int targetK, int smallerCount) {
        if(node == null) {
            return (0, -1);
        }
        
        (var leftCount, var leftValue) = GetOrderOrReturnValue(node.left, targetK, smallerCount);
        
        if(leftValue != -1) {
            return (-1, leftValue);
        }
        
        var selfOrder = smallerCount + leftCount + 1;
        
        if(selfOrder == targetK) {
            return (-1, node.val);
        }
        
        (var rightCount, var rightValue) = GetOrderOrReturnValue(node.right, targetK, selfOrder);
        
        if(rightValue != -1) {
            return (-1, rightValue);
        }
        
        return (leftCount + rightCount + 1, -1);
    }
}