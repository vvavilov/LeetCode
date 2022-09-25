public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var graph = BuildGraph(beginWord, wordList);

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        var length = 1;
        var visited = new HashSet<string>();
        

        while(queue.Count > 0) {
            length++;
            var count = queue.Count;

            while(count-- > 0) {
                var current = queue.Dequeue();

                if(visited.Contains(current)) {
                    continue;
                }

                visited.Add(current);

                foreach(var neighbour in graph[current]) {
                    if(neighbour == endWord) {
                        return length;
                    } else {
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        return 0;
    }

    private Dictionary<string, IList<string>> BuildGraph(string beginWord, IList<string> wordList) {
        var words = new HashSet<string>(wordList);
        Dictionary<string, IList<string>> graph = new();
        graph[beginWord] = GetNeighborWords(beginWord, words);

        foreach(var word in words) {
            graph[word] = GetNeighborWords(word, words);               
        }

        return graph;
    }

    private IList<string> GetNeighborWords(string word, HashSet<string> words) {
        List<string> result = new();

        for(int letterPos = 0; letterPos < word.Length; letterPos++) {
            var array = word.ToCharArray();

            for(int i = 0; i < 26; i++) {
                var letter = (char)('a' + i);

                if(word[letterPos] == letter) {
                    continue;
                }

                array[letterPos] = letter;
                var newWord = new string(array);

                if(words.Contains(newWord)) {
                    result.Add(newWord);
                }
            }
        }
        
        return result;
    }
}