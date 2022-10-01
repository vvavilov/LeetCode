/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        var pPath = new List<Node>();
        var qPath = new List<Node>();

        
        while(p != null) {
            pPath.Add(p);
            p = p.parent;
        }
        
        
        while(q != null) {
            qPath.Add(q);
            q = q.parent;
        }
        
        var pPos = pPath.Count - 1;
        var qPos = qPath.Count - 1;
        
        while(pPos >= 0 && qPos >= 0 && qPath[qPos].val == pPath[pPos].val) {
            pPos--;
            qPos--;
        }
        
        return qPath[qPos + 1];
    }
}