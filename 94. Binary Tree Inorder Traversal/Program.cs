public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        var list = new List<int>();
        if(root == null) {
            return list;
        }
        var stack = new Stack<TreeNode>();
        
        var current = root;
        
        while(stack.Count > 0 || current != null) {
            while(current != null) {
                stack.Push(current);
                current = current.left;
            }
            
            var node = stack.Pop();
            list.Add(node.val);
            current = node.right;
        }
        
        
        return list;
    }
}