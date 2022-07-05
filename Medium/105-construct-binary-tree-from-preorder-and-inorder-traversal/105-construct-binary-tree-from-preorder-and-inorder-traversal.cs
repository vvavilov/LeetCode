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
    private ParentSource parents;
    private NodePositionSource positionSource;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        parents = new ParentSource(preorder);
        positionSource = new NodePositionSource(inorder);
        return BuildSubtree(0, inorder.Length - 1);
    }
    
    private TreeNode BuildSubtree(int leftPos, int rightPos) {
        if(rightPos < leftPos) {
            return null;
        }
        
        var parent = parents.Next;
        var posOfParent = positionSource.GetPosition(parent);
        
        var parentNode = new TreeNode(parent);
        
        parentNode.left = BuildSubtree(leftPos, posOfParent - 1);
        parentNode.right = BuildSubtree(posOfParent + 1, rightPos);
        
        return parentNode;
    }
}

public class NodePositionSource {
    Dictionary<int, int> dict = new();
    
    public NodePositionSource(int[] nodes) {
        for(int i = 0; i < nodes.Length; i++) {
            dict.Add(nodes[i], i);
        }
    }
    
    public int GetPosition(int nodeValue) {
        return dict[nodeValue];
    }
}

public class ParentSource {
    private int pos;
    private int[] parents;
    
    public ParentSource(int[] parents) {
        this.parents = parents;
        pos = 0;
    }
    
    public int Next => parents[pos++];
}