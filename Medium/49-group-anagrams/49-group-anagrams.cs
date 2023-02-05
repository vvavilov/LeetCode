public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, IList<string>> groupedById = new();
        
        foreach(var x in strs) {
            var id = GetGroupId(x);
            var group = groupedById.ContainsKey(id)
                ? groupedById[id]
                : new List<string>();
            
            group.Add(x);
            groupedById[id] = group;
        }
        
        return groupedById.Values.ToList();
        
    }
    
    private string GetGroupId(string s) {
        var counts = new int[26];
        
        foreach(var x in s) {
            counts[(int)(x - 'a')]++;
        }
        
        var id = new StringBuilder();
        
        for(int i = 0; i < counts.Length; i++) {
            id.Append($"{i}:{counts[i]}_");
        }
        
        return id.ToString();
    }
}