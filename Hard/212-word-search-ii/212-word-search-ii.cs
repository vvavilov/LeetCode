public class Solution {
    private HashSet<string> output = new HashSet<string>();
    char[][] board;

    private (int y, int x)[] directions = new (int y, int x)[] {
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0)
    };

    public IList<string> FindWords(char[][] board, string[] words) {
        if(board.Length == 0) {
            return output.ToList();
        }
        
        this.board = board;
        var trie = BuildTrie(words);

        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board[0].Length; j++) {
                Backtrack((i, j), trie, new HashSet<(int y, int x)>());
            }
        }

        return output.ToList();
    }

    private void Backtrack((int y, int x) cell, TrieNode prev, HashSet<(int y, int x)> visited) {
        var letter = board[cell.y][cell.x];
        var letterNode = prev.Children[letter - 'a'];

        if(letterNode == null) {
            return;
        }

        if(letterNode.IsWordEnd) {
            if(!output.Contains(letterNode.Value)) {
                output.Add(letterNode.Value);
            }
        }

        visited.Add(cell);

        foreach(var dir in directions) {
            (int y, int x) neigh = (cell.y + dir.y, cell.x + dir.x);

            if(neigh.x < 0 || neigh.y < 0 || neigh.x == board[0].Length || neigh.y == board.Length) {
                continue;
            }

            if(visited.Contains(neigh)) {
                continue;
            }

            Backtrack(neigh, prev.Children[letter - 'a'], visited);
        }

        visited.Remove(cell);
    }

    private TrieNode BuildTrie(string[] words) {
        var trie = new TrieNode();
        
        foreach(var x in words) {
            var currentNode = trie;

            foreach(var letter in x) {
                if(currentNode.Children[letter - 'a'] == null) {
                    currentNode.Children[letter - 'a'] = new TrieNode();
                }

                currentNode = currentNode.Children[letter - 'a'];
            }

            currentNode.IsWordEnd = true;
            currentNode.Value = x;
        }


        return trie;
    }
}

public class TrieNode {
    public TrieNode[] Children {get;set;} = new TrieNode[26];
    public bool IsWordEnd {get;set;}
    public string Value {get;set;}
}