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
    private int? result;
    
    public int KthSmallest(TreeNode root, int k) {
        Dfs(root, k);
        return result.Value;
    }
    
    // return (found, number of items)
    private int Dfs(TreeNode node, int k) {
        if(node == null) {
            return 0;
        }
        
        var leftCount = Dfs(node.left, k);
        
        if(ResultIsReady()) {
            return Dummy();
        }
        
        if(leftCount + 1 == k) {
            result = node.val;
            return Dummy();
        }
        
        var rightCount = Dfs(node.right, k - leftCount - 1);
        
        if(ResultIsReady()) {
            return Dummy();
        }
        
        return leftCount + rightCount + 1;
    }
    
    private bool ResultIsReady() => result != null;
    private int Dummy() => -1;

}