public class Solution {
    private int count = 0;
    private List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
    private int mod = (int)Math.Pow(10, 9) + 7;

    
    public int CountVowelPermutation(int n) {
        if (n == 0) {
            return 0;
        }
        
        var dp = InitBaseCount();        
        
        while(--n > 0) {
            OneMorePosition(dp);
        }
        
        return (int)((dp['a'] + dp['e'] + dp['i'] + dp['o'] + dp['u']) % mod);
    }
    
    private void OneMorePosition(Dictionary<char, long> counts) {
        var nextCount = new Dictionary<char, long>();

        foreach(var x in vowels) {
            nextCount[x] = 0;
            
            foreach(var next in Next(x)) {
                if(Int64.MaxValue - nextCount[x] <= counts[next]) { Console.WriteLine("more than long"); } ;
                
                nextCount[x] += counts[next];
            }
            
            nextCount[x] = nextCount[x] % mod;
        }
        
        foreach(var pair in nextCount) {
            counts[pair.Key] = pair.Value;
        }
    }
    
    private Dictionary<char, long> InitBaseCount() {
        return new Dictionary<char, long> {
            { 'a', 1 },
            { 'e', 1 },
            { 'i', 1 },
            { 'o', 1 },
            { 'u', 1 },
        };
    }
    
    private List<char> Next(char x) {
        switch (x) {
            case 'a': return new List <char> { 'e' };
            case 'e': return new List <char> { 'a', 'i' };
            case 'i': return new List <char> { 'a', 'e', 'o', 'u' };
            case 'o': return new List <char> { 'i', 'u' };
            case 'u': return new List <char> { 'a' };
        };
        
        throw new Exception("letter is not supported");
    }
}