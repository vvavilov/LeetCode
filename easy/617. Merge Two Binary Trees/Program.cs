public class Solution {
    public TreeNode MergeTrees(TreeNode node1, TreeNode node2) {
        if (node1 == null && node2 == null) {
            return null;
        }
        
        var node = new TreeNode();
        
        node.val = (node1?.val ?? 0) + (node2?.val ?? 0);
        node.left = MergeTrees(node1?.left, node2?.left);
        node.right = MergeTrees(node1?.right, node2?.right);
        
        return node;
    }
    
}