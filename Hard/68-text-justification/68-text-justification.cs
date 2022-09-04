public class Solution {
    private string[] words;

    public IList<string> FullJustify(string[] words, int maxWidth) {
        this.words = words;
    
        var firstWordPos = 0;
        List<string> output = new();

        while(firstWordPos < words.Length) {
            var lastWordPos = firstWordPos;
            var reservedCount = words[firstWordPos].Length;
            var numberOfSymbols = reservedCount;

            while(lastWordPos + 1 < words.Length && 1 + words[lastWordPos + 1].Length <= maxWidth - reservedCount) {
                lastWordPos++;
                numberOfSymbols += words[lastWordPos].Length;
                reservedCount += words[lastWordPos].Length + 1;
            }

            var outputLine = lastWordPos == words.Length - 1
                ? FormatLastLine(firstWordPos, lastWordPos, maxWidth)
                : Justify(firstWordPos, lastWordPos, maxWidth, numberOfSymbols);

            output.Add(outputLine);
            firstWordPos = lastWordPos + 1;
        }

        return output;
    }

    private string Justify(int firstWord, int lastWord, int maxWidth, int symbolsCount) {
        var numberOfWords = lastWord - firstWord + 1;
        var slotsCount = numberOfWords - 1;
        var whitespaceCount = maxWidth - symbolsCount;
        var whitespacesCountPerSlot = 0;
        var extraWhitespaceSlotsCount = 0;

        if(slotsCount == 0) {
            whitespacesCountPerSlot = whitespaceCount;
        } else {
            whitespacesCountPerSlot = whitespaceCount / slotsCount;
            extraWhitespaceSlotsCount = whitespaceCount % slotsCount;
        }

        StringBuilder outputBuilder = new();
        
        for(int i = firstWord; i <= lastWord; i++) {
            outputBuilder.Append(words[i]);

            if(i != lastWord || i == firstWord) {
                outputBuilder.Append(new string(' ', whitespacesCountPerSlot));
            }

            if(extraWhitespaceSlotsCount > 0) {
                outputBuilder.Append(" ");
                extraWhitespaceSlotsCount--;
            }
        }

        return outputBuilder.ToString();
    }

    private string FormatLastLine(int firstWord, int lastWord, int maxWidth) {
        StringBuilder outputBuilder = new();

        for(int i = firstWord; i <= lastWord; i++) {
            outputBuilder.Append(words[i]);
            
            if(i != lastWord) {
                outputBuilder.Append(" ");
            }
        }

        outputBuilder.Append(new string(' ', maxWidth - outputBuilder.Length));
        return outputBuilder.ToString();
    }
}