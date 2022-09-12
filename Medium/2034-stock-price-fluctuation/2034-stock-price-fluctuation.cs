public class StockPrice {
    IndexedPriorityQueue minPriceQueue = new (new MinHeapComparer());
    IndexedPriorityQueue  maxPriceQueue = new (new MaxHeapComparer());
    int latestPrice = 0;
    int latestPriceTime = 0;

    public StockPrice() {
        
    }
    
    public void Update(int timestamp, int price) {
        if(timestamp >= latestPriceTime) {
            latestPrice = price;
            latestPriceTime = timestamp;
        }

        minPriceQueue.Update(timestamp, price);
        maxPriceQueue.Update(timestamp, price);
    }
    
    public int Current() {
        return latestPrice;
    }
    
    public int Maximum() {
        return maxPriceQueue.Peek();
    }
    
    public int Minimum() {
        return minPriceQueue.Peek();
    }
}

public class IndexedPriorityQueue {
    private List<int> prices = new List<int>();
    private Dictionary<int, int> timestampToPos = new();
    private Dictionary<int, int> posToTimestamp = new();
    private IComparer<int> comparer;

    public IndexedPriorityQueue(IComparer<int> comparer) {
        this.comparer = comparer;
    }

    private int ParentPos(int nodePos) => (nodePos - 1) / 2;
    private int Parent(int nodePos) => prices[ParentPos(nodePos)];
    private int LeftPos(int nodePos) => nodePos * 2 + 1;
    private int RightPos(int nodePos) => nodePos * 2 + 2;
    private int Val(int pos) => prices[pos];


    private void Swap(int leftPos, int rightPos) {
        var temp = prices[leftPos];
        prices[leftPos] = prices[rightPos];
        prices[rightPos] = temp;

        var leftTimestamp = posToTimestamp[leftPos];
        var rightTimestamp = posToTimestamp[rightPos];
        timestampToPos[leftTimestamp] = rightPos;
        timestampToPos[rightTimestamp] = leftPos;
        posToTimestamp[leftPos] = rightTimestamp;
        posToTimestamp[rightPos] = leftTimestamp;  
    }

    public int Peek() {
        return prices[0];
    }

    private int MoveUp(int nodePos) {
        while(Parent(nodePos) >= 0 && comparer.Compare(Parent(nodePos), prices[nodePos]) < 0) {
            Swap(nodePos, ParentPos(nodePos));
            nodePos = ParentPos(nodePos);
        }

        return nodePos;
    }

    private void Add(int timestamp, int price) {
        prices.Add(price);
        timestampToPos[timestamp] = prices.Count - 1;
        posToTimestamp[prices.Count - 1] = timestamp;
        var newPos = MoveUp(prices.Count - 1);
    }

    private void UpdateByIndex(int index, int price) {
        prices[index] = price;
        var position = MoveUp(index);

        if(position != index) {
            return;
        }

        Heapify(index);   
    }

    private void Heapify(int index) {
        if(LeftPos(index) >= prices.Count) {
            return;
        }

        while(LeftPos(index) <= prices.Count - 1) {
            var newPos = index;
            var left = Val(LeftPos(index));

            if(comparer.Compare(Val(index), left) < 0) {
                newPos = LeftPos(index);
            }

            if(RightPos(index) <= prices.Count - 1) {
                var right = Val(RightPos(index));

                if(comparer.Compare(Val(newPos), right) < 0) {
                    newPos = RightPos(index);
                }
            }

            if(index == newPos) {
                return;
            }

            Swap(newPos, index);
            index = newPos;
        }
    }

    public void Update(int timestamp, int price) {
        if(timestampToPos.ContainsKey(timestamp)) {
            UpdateByIndex(timestampToPos[timestamp], price);
        } else {
            Add(timestamp, price);
        }
    }
}

public class MinHeapComparer : IComparer<int> {
    public int Compare(int parent, int child) {
        if(parent == child) {
            return 0;
        }

        if(parent < child) {
            return 1;
        }

        return -1;
    }
}

public class MaxHeapComparer : IComparer<int> {
    public int Compare(int parent, int child) {
        if(parent == child) {
            return 0;
        }

        if(parent > child) {
            return 1;
        }

        return -1;
    }
}

/**
 * Your StockPrice object will be instantiated and called as such:
 * StockPrice obj = new StockPrice();
 * obj.Update(timestamp,price);
 * int param_2 = obj.Current();
 * int param_3 = obj.Maximum();
 * int param_4 = obj.Minimum();
 */