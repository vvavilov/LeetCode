public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var events = new PriorityQueue<int, (EventType type, int time)>(new ByTimeAndTypeComparer());
        
        for(int i = 0; i < intervals.Length; i++) {
            events.Enqueue(i, (EventType.Start, intervals[i][0]));
            events.Enqueue(i, (EventType.End, intervals[i][1]));
        }
        
        HashSet<int> meetings = new();
        var simultaniousMeetingsCount = 0;
        
        while(events.Count > 0) {
            events.TryDequeue(out var id, out var meetingEvent);
            
            if(meetingEvent.type == EventType.End) {
                meetings.Remove(id);
                continue;
            } 

            meetings.Add(id);
            simultaniousMeetingsCount = Math.Max(simultaniousMeetingsCount, meetings.Count);
            continue;
            
            
        }
        
        return simultaniousMeetingsCount;
    }
}

public enum EventType {
    Start,
    End
}

public class ByTimeAndTypeComparer : IComparer<(EventType type, int time)> {
    public int Compare((EventType type, int time) left, (EventType type, int time) right) {
        if(left.time == right.time) {
            if(left.type == right.type) {
                return 0;
            }
            
            if(left.type == EventType.Start) {
                return 1;
            }
            
            return -1;
        }
        
        if(left.time < right.time) {
            return -1;
        }
        
        return 1;
    }
}