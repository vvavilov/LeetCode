public class Logger {
    private Dictionary<string, int> messages = new();
    
    public Logger() {
                
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        var exists = messages.TryGetValue(message, out var existingTimestamp);
        
        if(!exists) {
            messages.Add(message, timestamp);
            return true;
        }
        
        if(timestamp - existingTimestamp >= 10) {
            messages[message] = timestamp;
            return true;
        }
        
        return false;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */