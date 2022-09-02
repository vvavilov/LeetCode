public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        
        
        var events = new PriorityQueue<(int id, EventType type), (EventType type, int time)>(new ByTimeAndTypeComparer());
        
        for(int i = 0; i < intervals.Length; i++) {
            events.Enqueue((i, EventType.Start), (EventType.Start, intervals[i][0]));
            events.Enqueue((i, EventType.End), (EventType.End, intervals[i][1]));
        }
        
        HashSet<int> meetings = new();
        var simultaniousMeetingsCount = 0;
        
        while(events.Count > 0) {
            var meetingEvent = events.Dequeue();
            
            Console.WriteLine("event " + meetingEvent.type + " " + meetingEvent.id);
            
            if(meetingEvent.type == EventType.End) {
                meetings.Remove(meetingEvent.id);
                continue;
            } 

            meetings.Add(meetingEvent.id);
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