public class Solution {
    public string ReorganizeString(string s) {
        var byCount = GroupByCount(s);
        var heap = new PriorityQueue<char, int>(byCount, new MaxHeapComparer());
        
        var result = new StringBuilder();
        
        var lastAdded = '0';
        
        while(heap.Count > 0) {
            heap.TryDequeue(out var firstTryLetter, out var firstTryCount);

            if(firstTryLetter == lastAdded) {
                if(heap.Count == 0) {
                    return string.Empty;
                }

                heap.TryDequeue(out var secondTryLetter, out var secondTryCount);
                AddLetter(secondTryLetter, secondTryCount, heap, result);
            }
            
            AddLetter(firstTryLetter, firstTryCount, heap, result);
            lastAdded = firstTryLetter;
        }
        
        return result.ToString();
        
    }
    
    private void AddLetter(char letter, int count, PriorityQueue<char, int> heap, StringBuilder sb) {
        sb.Append(letter);

        if(count > 1) {
            heap.Enqueue(letter, count - 1);    
        }
    }
    
    private IEnumerable<(char letter, int count)> GroupByCount(string s) {
        Dictionary<char, int> letters = new();
        
        foreach(var x in s) {
            var count = 0;
            letters.TryGetValue(x, out count);
            letters[x] = count + 1;
        }
        
        return letters.Select(pair => (pair.Key, pair.Value));
    } 
    
    
}

public class MaxHeapComparer : IComparer<int> {
    public int Compare(int parentCount, int childCount) {
        if(parentCount == childCount) {
            return 0;
        }
        
        if(parentCount < childCount) {
            return 1;
        }
        
        return -1;
    }
}