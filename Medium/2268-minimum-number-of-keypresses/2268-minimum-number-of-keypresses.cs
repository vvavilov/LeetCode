public class Solution {
    public int MinimumKeypresses(string s) {
        var lettersFrequency = new Dictionary<char, int>();
        
        foreach(var x in s) {
            lettersFrequency.TryGetValue(x, out var count);
            lettersFrequency[x] = count + 1;
        }
        
        var orderedByFrequency = lettersFrequency.OrderByDescending(x => x.Value).Select(x => x.Value).ToList();
        var total = 0;
        
        for(int i = 0; i < orderedByFrequency.Count; i++) {
            Console.WriteLine("i  " + i);

            var toPress = i / 9 + 1;
            Console.WriteLine("toPress  " + toPress);
            Console.WriteLine("orderedByFrequency [i] " + orderedByFrequency[i]);


            total += toPress * orderedByFrequency[i];
        }
        
        return total;
    }
}