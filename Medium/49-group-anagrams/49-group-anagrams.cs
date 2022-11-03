public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        
        foreach(var word in strs) {
            var keys = new int[26];
            
            foreach(var letter in word) {
                var letterPos = letter - 'a';
                keys[letterPos]++;
            }
            
            var hashKeyBuilder = new StringBuilder();
            
            foreach(var letterCount in keys) {
                hashKeyBuilder.Append(letterCount);
                hashKeyBuilder.Append("_");
            }
            
            var hashKey = hashKeyBuilder.ToString();
            
            if(!dict.ContainsKey(hashKey)) {
                dict[hashKey] = new List<string>();
            }
            
            dict[hashKey].Add(word);
        }
        
        return dict.Values.ToList();
    }
}

public class SolutionDict {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        
        foreach(var s in strs) {
            var array = s.ToArray();
            Array.Sort(array);
            var sorted = new String(array);
            
            if(!dict.ContainsKey(sorted)) {
                dict[sorted] = new List<string>();
            }
            
            dict[sorted].Add(s);
        }
        
        return dict.Aggregate(new List<IList<string>>(), (acc, cur) => {
            acc.Add(cur.Value);
            return acc;
        });
    }
}