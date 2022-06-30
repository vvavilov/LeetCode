public class LRUCache {
    private PriorityQueue evictionOrder;
    private Dictionary<int, Item> cache;
    private int capacity;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        evictionOrder = new PriorityQueue();
        cache = new Dictionary<int, Item>();
    }
    
    public int Get(int key) {
        cache.TryGetValue(key, out var item);
        
        if(item == null) {
            return -1;
        }

        evictionOrder.Refresh(item);
        return item.Value;
    }
    
    private void AddItem(int key, int value) {
        if(cache.Count == capacity) {
            var lruItem = evictionOrder.Dequeue();
            cache.Remove(lruItem.Key);
        }
        
        var item = new Item(key, value);
        evictionOrder.Enqueue(item);
        cache[key] = item;
    }
    
    private void UpdateItem(Item item, int value) {
        item.Value = value;
        evictionOrder.Refresh(item);
    }
    
    public void Put(int key, int value) {
        cache.TryGetValue(key, out var existingItem);
        
        if(existingItem != null) {
            UpdateItem(existingItem, value);
        } else {
            AddItem(key, value);
        }
    }
}

public class Item {
    public Item(int key, int value) {
        Value = value;
        Key = key;
    }
    
    public int Value {get;set;}
    public int Key {get;set;}
    public int Pos {get;set;}

    public long LastRead {get;set;}
    
    public void Refresh() {
        LastRead = DateTime.Now.Ticks;
    }
}

public class PriorityQueue {
    private List<Item> storage = new();
    
    
    public void Enqueue(Item item) {
        storage.Add(item);
        item.Pos = Last;
        item.Refresh();
        
        var current = Last;
        
        while(current > 0 && LastRead(current) < LastRead(Parent(current))) {
            Swap(current, Parent(current));
            current = Parent(current);
        }
    }
    
    private int Last => storage.Count - 1;
    private int Parent(int pos) => (pos - 1) / 2;
    private int Left(int pos) => pos * 2 + 1;
    private int Right(int pos) => pos * 2 + 2;

    private Item At(int pos) => storage[pos];
    
    private long LastRead(int pos) => At(pos).LastRead;
    
    private void Heapify(int pos) {
        var minPos = pos;
        
        if(Left(pos) <= Last && LastRead(Left(pos)) < LastRead(pos)) {
            minPos = Left(pos);
        }
        
        if(Right(pos) <= Last && LastRead(Right(pos)) < LastRead(minPos)) {
            minPos = Right(pos);
        }
        
        if(minPos == pos) {
            return;
        }
        
        Swap(minPos, pos);
        Heapify(minPos);
    }
    
    private void Swap(int x, int y) {
        var temp = At(x);
        storage[x] = storage[y];
        storage[y] = temp;
        storage[x].Pos = x;
        storage[y].Pos = y;
    }
    
    public Item Dequeue() {
        var item = storage[0];
        Swap(0, Last);
        storage.RemoveAt(Last);
        Heapify(0);
        
        return item;
    }
    
    public void Refresh(Item item) {
        item.Refresh();
        Heapify(item.Pos);
    }
}



/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */