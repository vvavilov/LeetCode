public class Solution {
	public  IList<IList<string>> SuggestedProducts(string[] products, string prefix) {
		StringBuilder subPrefix = new();
		List<IList<string>> result = new();
		var trie = BuildTrie(products);

        for(int i = 0; i < prefix.Length; i++) {
            subPrefix.Append(prefix[i]);
            var suggestingPerSubprefix = trie.GetSuggestions(subPrefix.ToString());			
            result.Add(suggestingPerSubprefix);
        }

        return result;
    }


    private ProductsTrie BuildTrie(string[] products) {
        var trie = new ProductsTrie();
                
        foreach(var x in products) {
            trie.AddWord(x);
        }

        return trie;
    }
}

public class ProductsTrie {
    public TrieNode Root { get; set; } = new TrieNode();

    public void AddWord(string word) {
        Root.AddWord(word, 0);
    }

    public IList<string> GetSuggestions(string prefix) {
        var pos = 0;
        var currentNode = Root;

        while(pos < prefix.Length) {
            var relatedNodePos = prefix[pos] - 'a';
            currentNode = currentNode.Children[relatedNodePos];

            if(currentNode == null) {
                return new List<string>();
            }

            pos++;
        }

        StringBuilder sb = new();
        sb.Append(prefix);
        List<string> words = new();
        currentNode.GetWords(words, sb);
        return words;
    }
}

public class TrieNode {
    public TrieNode[] Children { get; set; }
    public bool WordEnd { get;set;}

    public TrieNode() {
        Children = new TrieNode[26];
    }

    public void AddWord(string word, int pos) {
        if(pos == word.Length) {
            WordEnd = true;
            return;
        }

        var childrenToAdd  = word[pos] - 'a';

        if(Children[childrenToAdd] == null) {
            Children[childrenToAdd] = new TrieNode();
        }
        
        Children[childrenToAdd].AddWord(word, pos + 1);
    }

    public void GetWords(IList<string> words, StringBuilder acc) {
        if(WordEnd) {
            words.Add(acc.ToString());
        }

        for(int i = 0; i < Children.Length; i++) {
            if(words.Count == 3) {
                break;
            }

            if(Children[i] == null) {
                continue;
            }

            acc.Append((char)(i + 'a'));
            Children[i].GetWords(words, acc);	
            acc.Remove(acc.Length - 1, 1);
        }
    }
}
