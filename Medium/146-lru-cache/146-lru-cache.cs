public class Node {
    public int Value { get; set;}
    public int Key { get;set; }
    public Node Next {get;set;}
    public Node Prev { get;set;}
}

// tail -> head
public class LRUCache {
    private Node tail = new();
    private Node head = new();
    private int capacity = 0;
    private Dictionary<int, Node> storage = new();
    
    private void Link(Node left, Node right) {
        var leftNext = left.Next;
        
        left.Next = right;
        right.Next = leftNext;
        leftNext.Prev = right;
        right.Prev = left;
    }
    
    private void RemoveFromQueue(Node node) {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
    
    private void AddToQueue(Node node) {
        Link(tail, node);
    }
    
    private void MoveToEnd(Node node) {
        RemoveFromQueue(node);
        AddToQueue(node);
    }
    
    private void EnsureCapacity() {
        if(storage.Count <= capacity) {
            return;
        }
        
        storage.Remove(head.Prev.Key);
        RemoveFromQueue(head.Prev);
    }
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        tail.Next = head;
        head.Prev = tail;
    }
    
    public int Get(int key) {
        if(storage.ContainsKey(key)) {
            var node = storage[key];
            MoveToEnd(node);
            return node.Value;
        }
        
        return -1;
    }
    
    public void Put(int key, int value) {  
        if(storage.ContainsKey(key)) {
            var node = storage[key];
            node.Value = value;
            MoveToEnd(node);

        } else {
            if(storage.Count == capacity) {
                storage.Remove(key);
            }
            
            var node = new Node { Value = value, Key = key };
            storage[key] = node;
            AddToQueue(node);
        }
        
        EnsureCapacity();
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */