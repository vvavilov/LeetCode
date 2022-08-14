// 3 8 0 9 2 5

public class RLEIterator {
    private int current = 0;
    private int[] encoding;

    public RLEIterator(int[] encoding) {
        this.encoding = encoding;
    }
    
    public int Next(int n) {
        if(current >= encoding.Length) {
            return -1;
        }

        while(n > CurrentCount()) {
            n -= CurrentCount();

            if(!GoNext()) {
                return -1;
            }
        }

        if(CurrentCount() > n) {
            encoding[current] -= n;
            return encoding[current + 1];
        }

        if(CurrentCount() == n) {
            var currentElement = encoding[current + 1];
            GoNext();
            return currentElement;
        }

        return -1;
    }

    private int CurrentCount() {
        return encoding[current];
    }

    private bool GoNext() {
        current += 2;
        return current < encoding.Length;
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(encoding);
 * int param_1 = obj.Next(n);
 */