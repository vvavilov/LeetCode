public class MaxPQComparer : IComparer<int> {
    public int Compare(int child, int parent) {
        if(parent > child) {
            return 1;
        }

        if(parent < child) {
            return -1;
        }

        return 0;
    }
}

public class Solution {
    private char prevUsed = ' ';

    public string LongestDiverseString(int a, int b, int c) {
        var output = new StringBuilder();
        var pq = new PriorityQueue<char, int>(new MaxPQComparer());

        if(a > 0) {
            pq.Enqueue('a', a);
        }

        if(b > 0) {
            pq.Enqueue('b', b);
        }

        if(c > 0) {
            pq.Enqueue('c', c);
        }

        while(pq.Count > 0) {
            pq.TryDequeue(out var maxLetter, out var maxCount);

            if(maxLetter != prevUsed) {
                var timesToAppend = Math.Min(maxCount, 2);
                output.Append(maxLetter, timesToAppend);
                prevUsed = maxLetter;
                
                if(maxCount > 2) {
                    pq.Enqueue(maxLetter, maxCount - timesToAppend);
                }
            } else {
                if(pq.Count == 0) {
                    return output.ToString();
                }
                
                pq.TryDequeue(out var secondMaxLetter, out var secondMaxCount);
                output.Append(secondMaxLetter, 1);
                prevUsed = secondMaxLetter;

                if(secondMaxCount > 1) {
                    pq.Enqueue(secondMaxLetter, secondMaxCount - 1);
                }

                pq.Enqueue(maxLetter, maxCount);

            }

        }

        return output.ToString();


    }

}
