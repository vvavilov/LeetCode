public class Node {
    public int key;
    public int val;
    public Node next;
    public Node prev;
}

public class LRUCache {
    private Node first = new Node();
    private Node last = new Node();
    
    private int capacity;
    private int count = 0;
    private Dictionary<int, Node> cache = new();
        
    public LRUCache(int capacity) {
        this.capacity = capacity;
        first.next = last;
        last.prev = first;
    }
    
    public int Get(int key) {
        if(!cache.ContainsKey(key)) {
            return -1;
        }
        
        var node = cache[key];
        Remove(node);
        MoveForward(node);
        return cache[key].val;
    }
    
    private void MoveForward(Node node) {
        node.prev = last.prev;
        node.prev.next = node;
        last.prev = node;
        node.next = last;
    }
    
    private void Remove(Node node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
    
    public void Put(int key, int value) {
        if(cache.ContainsKey(key)) {
            var node = cache[key];
            node.val = value;
            Remove(node);
            MoveForward(node);
        } else {
            if(capacity == count) {
                var lruNode = first.next;
                Remove(lruNode);
                cache.Remove(lruNode.key);
                count--;
            }
            
            count++;
            var node = new Node { val = value, key = key };
            cache[key] = node;
            MoveForward(node);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */