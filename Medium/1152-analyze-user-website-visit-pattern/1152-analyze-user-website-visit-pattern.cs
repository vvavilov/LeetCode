public class Solution {
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website) {
        var byUser = GroupByUsers(username, timestamp, website);
        var sortedVisits = byUser.Select(x => SortByTimestamp(x)).ToList();
        
        var patterns = new Dictionary<(string first, string second, string third), int>();
        
        foreach(var userVisits in sortedVisits) {
            var userPatterns = new HashSet<(string first, string second, string third)>();
            
            for(int first = 0; first < userVisits.Count - 2; first++) {
                for(int second = first + 1; second < userVisits.Count - 1; second++) {
                    for(int third = second + 1; third < userVisits.Count; third++) {
                        userPatterns.Add((userVisits[first], userVisits[second], userVisits[third]));
                    }
                }
            }
            
            foreach(var x in userPatterns) {
                patterns.TryGetValue(x, out var count);
                patterns[x] = count + 1;
            }
        }
        
        var bestMatch = patterns.OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key.first)
            .ThenBy(x => x.Key.second)
            .ThenBy(x => x.Key.third)
            .First().Key;
        
        return new List<string> {bestMatch.first, bestMatch.second, bestMatch.third};
    }
    
    private List<List<(int time, string site)>> GroupByUsers(string[] userName, int[] timeStamp, string[] website) {
        var groups = new Dictionary<string, List<(int time, string site)>>();
        
        for(int i = 0; i < timeStamp.Length; i++) {
            var user = userName[i];
            if(!groups.ContainsKey(user)) {
                groups[user] = new List<(int time, string site)>();
            }
            
            groups[user].Add((timeStamp[i], website[i]));
        }
        
        return groups.Values.ToList();
    }
    
    private List<string> SortByTimestamp(List<(int time, string site)> visits) {
        return visits.OrderBy(x => x.time).Select(x => x.site).ToList();
    }
    
}