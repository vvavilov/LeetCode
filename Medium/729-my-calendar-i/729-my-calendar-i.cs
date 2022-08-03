public class MyCalendar {
    IntervalTree tree = new();

    public MyCalendar() {
    
    }
    
    public bool Book(int start, int end) {
        if(tree.Intersects(start, end)) {
            return false;
        }
        
        tree.Insert(start, end);
        return true;
    }
}

public class IntervalNode {
    public int MaxEnd { get; set; }
    public int Start { get; set; }
    public int End { get;set; }
    public IntervalNode Left {get;set;}
    public IntervalNode Right {get;set;}
    
    public bool Intersects(int start, int end) {
        if(IntersectsWith(start, end)) {
            return true;
        }

        if(Left != null && Left.MaxEnd >= start) {
            return Left.Intersects(start, end);
        }
        
        if(Right != null) {
            return Right.Intersects(start, end);
        }
        
        return false;
    }
    
    private bool IntersectsWith(int start, int end) {
        
        var notIntersect = End <= start || Start >= end;
        return !notIntersect;
    }
        
    public void Insert(int start, int end) {
        MaxEnd = Math.Max(MaxEnd, end);
        
        if(start < Start) {
            if(Left == null) {
                Left = From(start, end);
            } else {
                Left.Insert(start, end);
            }
        }
        
        if(start > Start) {
            if(Right == null) {
               Right = From(start, end);
            } else {
                Right.Insert(start, end);
            }
        }
        
        Console.WriteLine("MaxEnd: {0}, Left: {1}-{2}, Right: {3}-{4} ", MaxEnd, Left?.Start, Left?.End, Right?.Start, Right?.End);
    }
    
    public static IntervalNode From(int start, int end) => 
        new IntervalNode {
            Start = start,
            End = end,
            MaxEnd = end
        };
}

public class IntervalTree {
    private IntervalNode root;
    
    public bool Intersects(int start, int end) {
        if(root == null) {
            return false;
        }
        
        return root.Intersects(start, end);
    }
    
    public void Insert(int start, int end) {
        if(root == null) {
            root = IntervalNode.From(start, end);
            return;
        }
        
        root.Insert(start, end);
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */