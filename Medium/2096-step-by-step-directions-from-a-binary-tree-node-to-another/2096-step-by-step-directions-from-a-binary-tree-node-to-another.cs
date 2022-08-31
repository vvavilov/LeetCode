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

public enum VisitedFrom {
    Up,
    Left,
    Right,
    Start,
}

public class Solution {
    private Dictionary<int, TreeNode> parents = new();
    
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        PopulateParents(root, null);
        var source = FindSource(root, startValue);
        var acc = new StringBuilder();
        GeneratePath(source, destValue, acc, VisitedFrom.Start);
        return acc.ToString();
    }

    private bool GeneratePath(TreeNode source, int destination, StringBuilder acc, VisitedFrom visitedFrom) {
        if(source == null) {
            return false;
        }

        if(source.val == destination) {
            return true;
        }

        var found = false;

        acc.Append("L");

        if(visitedFrom != VisitedFrom.Left) {
            acc[acc.Length - 1] = 'L';
            found = GeneratePath(source.left, destination, acc, VisitedFrom.Up);

            if(found) {
                return true;
            }
        }

        if(visitedFrom != VisitedFrom.Right) {
            acc[acc.Length - 1] = 'R';
            found = GeneratePath(source.right, destination, acc, VisitedFrom.Up);

            if(found) {
                return true;
            }
        }

        if(visitedFrom != VisitedFrom.Up) {
            acc[acc.Length - 1] = 'U';
            var parent = parents[source.val];
            var isLeftChild = parent.left == source;
            
            GeneratePath(
                parents[source.val],
                destination,
                acc,
                isLeftChild ? VisitedFrom.Left : VisitedFrom.Right);

            return true;
        }

        acc.Remove(acc.Length - 1, 1);

        return false;
    }

    private TreeNode FindSource(TreeNode node, int sourceValue) {
        if(node == null) {
            return null;
        }
        
        if(node.val == sourceValue) {
            return node;
        }

        var leftSource = FindSource(node.left, sourceValue);

        if(leftSource != null) {
            return leftSource;
        }

        return FindSource(node.right, sourceValue);
    }

    private void PopulateParents(TreeNode node, TreeNode parent) {
        if(node == null) {
            return;
        }

        parents[node.val] = parent;
        PopulateParents(node.left, node);
        PopulateParents(node.right, node);
    }
}