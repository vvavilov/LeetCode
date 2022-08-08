public class Solution {
    private Dictionary<int, string> digits = new Dictionary<int, string> {
        { 1, "One" },
        { 2, "Two" },
        { 3, "Three" },
        { 4, "Four" },
        { 5, "Five" },
        { 6, "Six" },
        { 7, "Seven" },
        { 8, "Eight" },
        { 9, "Nine" }
    };
    
    private Dictionary<int, string> singleDecimal = new Dictionary<int, string> {
        { 1, "Eleven" },
        { 2, "Twelve" },
        { 3, "Thirteen" },
        { 4, "Fourteen" },
        { 5, "Fifteen" },
        { 6, "Sixteen" },
        { 7, "Seventeen" },
        { 8, "Eighteen" },
        { 9, "Nineteen" },
        { 0, "Ten" }
    };
    
    private Dictionary<int, string> multiDecimal = new Dictionary<int, string> {
        { 2, "Twenty" },
        { 3, "Thirty" },
        { 4, "Forty" },
        { 5, "Fifty" },
        { 6, "Sixty" },
        { 7, "Seventy" },
        { 8, "Eighty" },
        { 9, "Ninety" }
    };
    
    private Dictionary<int, string> ranks = new Dictionary<int, string> {
        { 1, "Thousand" },
        { 2, "Million" },
        { 3, "Billion" },
        { 4, "Three" }
    };
    
    public string NumberToWords(int num) {
        if(num == 0) {
            return "Zero";
        }

        Stack<string> parts = new();
        
        var rankCount = 0;
        
        while(num > 0) {
            var rankBuilder = new StringBuilder();
            var rank = num % 1000;    
            num /= 1000;
            
            var rankString = RankToString(rank);
            
            if(rankString != "") {
                rankBuilder.Append(rankString);
            }
            
            var rankName = GetRankName(rankCount);
            
            if(rankString != "" && rankName != "") {
                rankBuilder.Append(" ");
                rankBuilder.Append(rankName);
            }
            
            var rankRepresentation = rankBuilder.ToString();
            
            if(rankRepresentation != "") {
                parts.Push(rankRepresentation);            
            }

            rankCount++;
        }
        
        var stringBuilder = new StringBuilder();
        
        while(parts.Count > 0) {
            stringBuilder.Append(parts.Pop());
            stringBuilder.Append(" ");
        }
        
        return stringBuilder.ToString().Trim();
    }
    
    public string GetRankName(int rank) {
        if(rank == 0) {
            return "";
        }
        
        return ranks[rank];
    }
    
    public string DigitToString(int x) {   
        if(x == 0) {
            return "";
        }

        return digits[x];
    }
    
    private string RankToString(int x) {
        var result = new StringBuilder();
        var rank = x / 100;
        
        if(rank > 0) {
            result.Append(DigitToString(rank));
            result.Append(" Hundred");
        }
        
        var decimals = DecimalToString(x % 100);
        
        if(decimals != "") {
            if(rank > 0) {
                result.Append(" ");
            }

            result.Append(decimals);
        }
        
        return result.ToString();
    }
    
    private string DecimalToString(int x) {
        var firstDigit = x % 10;
        var dec = x / 10;
        
        if(dec == 0) {
            return DigitToString(firstDigit);
        }
        
        if(dec == 1) {
            return singleDecimal[firstDigit];
        }
        
        var builder = new StringBuilder();
        builder.Append(multiDecimal[dec]);
        
        if(firstDigit > 0) {
            builder.Append(" ");
            builder.Append(DigitToString(firstDigit));
        }

        return builder.ToString();
    }
    
    
}