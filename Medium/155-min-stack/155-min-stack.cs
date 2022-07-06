public class Node {
    public int Value { get; set; }
    public Node Next { get; set; }
}

public class MinStack {
    private Node minVals = new Node();
    private Node vals = new Node();
    
    public MinStack() {
        
    }
    
    public void Push(int val) {
        vals = new Node {
            Value = val,
            Next = vals
        };
        
        if(minVals.Next == null || GetMin() >= val) {
            minVals = new Node {
                Value = val,
                Next = minVals,
            };
        }
    }
    
    public void Pop() {
        if(vals.Next == null) {
            throw new Exception("Stack is empty");
        }
        
        var value = vals.Value;
        vals = vals.Next;
        
        if(value == GetMin()) {
            minVals = minVals.Next;
        }
    }
    
    public int Top() => vals.Value;
    
    public int GetMin() => minVals.Value;
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */