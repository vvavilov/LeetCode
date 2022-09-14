public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        (var letterLogs, var digitLogs) = Parse(logs);
        var sortedLetters = letterLogs.OrderBy(x => x.Content).ThenBy(x => x.Id).Select(x => x.Id + " " + x.Content);
        return sortedLetters.Concat(digitLogs.Select(x => x.Id + " " + x.Content)).ToArray();
    }

    public (List<LogInfo> letterLogs, List<LogInfo> digitLogs) Parse(string[] logs) {
        var letterLogs = new List<LogInfo>();
        var digitLogs = new List<LogInfo>();

        foreach(var log in logs) {
            var logInfo = ParseLog(log);

            if(logInfo.Type == LogType.Digit) {
                digitLogs.Add(logInfo);
            } else {
                letterLogs.Add(logInfo);
            }
        }

        return (letterLogs, digitLogs);
    }

    private LogInfo ParseLog(string log) {
        var words = log.Split(" ");
        var firstWord = words[1];

        var type = Char.IsDigit(firstWord[0]) ? LogType.Digit : LogType.Letter;
        return new LogInfo {
            Id = words[0],
            Content = String.Join(' ', words.Skip(1)),
            Type = type
        };
    }
}

public enum LogType {
    Digit,
    Letter
}

public class LogInfo {
    public string Id { get;set;}
    public string Content {get;set;}
    public LogType Type { get; set;} 
}