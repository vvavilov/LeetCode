// 3 8 2 5 0 9 2 6

public class RLEIterator {
    private int current = 0;
    private int[] encoding;

    public RLEIterator(int[] encoding) {
        this.encoding = encoding;
    }
    
    public int Next(int n) {
        while(HasNext() && n > CurrentCount) {
            n -= CurrentCount;
            MoveCurrent();
        }

        if(!HasNext()) {
            return -1;
        }

        var currentValue = CurrentValue;
        CurrentCount -= n;

        if(CurrentCount == 0) {
            MoveCurrent();
        }

        return currentValue;
    }

    private bool HasNext() {
        return current < encoding.Length;
    }

    private int CurrentCount {
        get => encoding[current];
        set => encoding[current] = value;
    }

    private int CurrentValue {
        get => encoding[current + 1];
    }

    private void MoveCurrent() {
        current += 2;
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(encoding);
 * int param_1 = obj.Next(n);
 */