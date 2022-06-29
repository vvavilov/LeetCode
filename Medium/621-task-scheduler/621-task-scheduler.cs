public class MaxPriorityComparer : IComparer<int>
{
    public int Compare(int parent, int child)
    {
        if(parent == child) {
            return 0;
        }
        
        if(parent > child) {
            return -1;
        }
        
        return 1;        
    }
}
    
public class Solution {
    private int cooldownValue = 0;
    private int currentTime = 0;
    private Dictionary<char, int> scheduledTasks = new();
    private PriorityQueue<char, int> tasksToSchedule = new(new MaxPriorityComparer());
    
    private void Tick(Action action) {
        action();
        currentTime++;
    }
    
    private void ScheduleSingle() {
        Queue<(char task, int count)> pendingTasks = new();

        while(tasksToSchedule.Count > 0) {
            tasksToSchedule.TryDequeue(out var task, out var count);
            
            var notScheduledTime = Int32.MinValue;
            var time = scheduledTasks.TryGetValue(task, out var existing) ? existing : notScheduledTime;
            
            var cooledDown = cooldownValue + time < currentTime;

            if(cooledDown) {
                scheduledTasks[task] = currentTime;
                
                if(count > 1) {
                    pendingTasks.Enqueue((task, count - 1));
                }
                
                break;
            }

            pendingTasks.Enqueue((task, count));            
        }
        
        foreach(var x in pendingTasks) {
            tasksToSchedule.Enqueue(x.task, x.count);
        }
    }
    
    
    public int LeastInterval(char[] tasks, int n) {
        cooldownValue = n;
        BuildPriorityQueue(tasks);
        
        while(tasksToSchedule.Count > 0) {
            Tick(ScheduleSingle);
        }
        
        return currentTime;
    }
    
    private void BuildPriorityQueue(char[] tasks) {
        foreach(var pair in GroupByCount(tasks)) {
            tasksToSchedule.Enqueue(pair.Key, pair.Value);
        }
    }
    
    private Dictionary<char, int> GroupByCount(char[] tasks) {
        Dictionary<char, int> groups = new();
        var cur = 0;
        
        foreach(var x in tasks) {
            groups.TryGetValue(x, out cur);
            groups[x] = ++cur;
        }
        
        return groups;
    }
}