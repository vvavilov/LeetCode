public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        List<(int time, int id, int type)> events = new();
        var startType = 1;
        var endType = 0;
        
        for(int i = 0; i < intervals.Length; i++) {
            var interval = intervals[i];
            
            events.Add((interval[0], i, startType));
            events.Add((interval[1], i, endType));    
        }
        
        var sortedByTime = events.OrderBy(x => x.time).ThenBy(x => x.type);
        var meetingsCount = 0;

        HashSet<int> ongoingEvents = new(); 
        
        foreach(var x in sortedByTime) {
            if(x.type == startType) {
                ongoingEvents.Add(x.id);
            } else {
                ongoingEvents.Remove(x.id);
            }
            
            meetingsCount = Math.Max(meetingsCount, ongoingEvents.Count);
        }
        
        return meetingsCount;
        

    }
}