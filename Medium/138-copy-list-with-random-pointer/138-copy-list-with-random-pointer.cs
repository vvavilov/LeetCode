/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if(head == null) {
            return null;
        }
        
        Dictionary<Node, Node> visited = new();
        Queue<(Node node, Node parent, bool isRandom)> toVisit = new();
        var headCopy = new Node(head.val);
        visited.Add(head, headCopy);

        if(head.random != null) {
            toVisit.Enqueue((head.random, headCopy, true));
        }

        if(head.next != null) {
            toVisit.Enqueue((head.next, headCopy, false));
        }

        while(toVisit.Count > 0) {
            var toProcessItems = toVisit.Dequeue();
            
            var copy = visited.ContainsKey(toProcessItems.node)
                ? visited[toProcessItems.node]
                : new Node(toProcessItems.node.val);

            if(toProcessItems.isRandom) {
                toProcessItems.parent.random = copy;
            } else {
                toProcessItems.parent.next = copy;
            }

            if(visited.ContainsKey(toProcessItems.node)) {
                continue;
            }

            visited.Add(toProcessItems.node, copy);

            if(toProcessItems.node.random != null) {
                toVisit.Enqueue((toProcessItems.node.random, copy, true));
            }

            if(toProcessItems.node.next != null) {
                toVisit.Enqueue((toProcessItems.node.next, copy, false));
            }
        }

        return headCopy;
    }
}