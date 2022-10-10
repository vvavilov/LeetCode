public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        PriorityQueue<string, (string value, int count)> pq = new(new ByFrequencyAndLexocographicalComparer());
        Dictionary<string, int> byCount = new();

        foreach(var x in words) {
            byCount.TryGetValue(x, out var count);
            byCount[x] = count + 1;
        }

        foreach(var x in byCount) {
            pq.Enqueue(x.Key, (x.Key, x.Value));

            if(pq.Count > k) {
                pq.Dequeue();
            }
        }

        var result = new List<(string value, int count)>();

        while(pq.Count > 0) {
            pq.TryDequeue(out var value, out var key);
            result.Add((value, key.count));
        }

        return result.OrderByDescending(x => x.count).ThenBy(x => x.value).Select(x => x.value).ToList();
    }
}

public class ByFrequencyAndLexocographicalComparer : IComparer<(string value, int freq)> {
    public int Compare((string value, int freq) left, (string value, int freq) right) {
        if(left.freq == right.freq) {
            return String.Compare(right.value, left.value);
        }

        return left.freq - right.freq;
    }
}