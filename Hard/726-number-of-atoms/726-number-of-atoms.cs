public class Solution {
    public string CountOfAtoms(string formula) {
        SortedDictionary<string, int> byCount = new();
        Stack<int> multipliers = new();
        multipliers.Push(1);
        
        var i = formula.Length - 1;
        
        while(i >= 0) {
            var symbol = formula[i];
            var elementName = "";
            var elementCount = 0;
            
            if(symbol == '(') {
                multipliers.Pop();
                i = i - 1;
                continue;
            }
            
            if(symbol == ')') {
                multipliers.Push(multipliers.Peek());
                i = i - 1;
                continue;
            }
            
            if(Char.IsDigit(symbol)) {
                (var token, var startingPos) = ParseDigit(formula, i);
                
                if(token is ClosingBracket) {
                    var closingToken = token as ClosingBracket;
                    multipliers.Push(closingToken.Count * multipliers.Peek());
                    i = startingPos - 1;
                    continue;
                } else {
                    var element = token as Element;
                    elementName = element.Name;
                    elementCount = element.Count;
                }
                
                i = startingPos - 1;

            } else {
                if(Char.IsUpper(symbol)) {
                    elementName = symbol.ToString();
                    elementCount = 1;
                    i = i - 1;
                }
        
                if(Char.IsLower(symbol)) {
                    elementName = formula.Substring(i - 1, 2);
                    elementCount = 1;
                    i = i - 2;
                }
            }
            
            byCount.TryGetValue(elementName, out var count);
            byCount[elementName] = count + multipliers.Peek() * elementCount;
        }

        var result = new StringBuilder();
        
        foreach(var x in byCount) {
            result.Append(x.Key);
            
            if(x.Value > 1) {
                result.Append(x.Value);
            }

        }

        return result.ToString();
    }
    
    private (IToken token, int startPos) ParseDigit(string formula, int pos) {        
        var multiplier = 1;
        var count = 0;
        
        while(true) {
            if(Char.IsDigit(formula[pos])) {
                count = Int32.Parse(formula[pos].ToString()) * multiplier + count;
                multiplier *= 10;
                pos--;
                continue;
            }
            
            if (formula[pos] == ')')  {
                return (new ClosingBracket { Count = count }, pos);   
            }
            
            if (Char.IsUpper(formula[pos])) {
                return (new Element { Count = count, Name = formula[pos].ToString() }, pos);
            }
            
            if(Char.IsLower(formula[pos])) {
                return (new Element { Count = count, Name = formula.Substring(pos - 1, 2) }, pos - 1);
            }            
        }
        
        return (null, 0);

    }
}

public interface IToken {
    
}

public class ClosingBracket : IToken {
    public int Count { get; set; }
}

public class Element: IToken {
    public int Count { get; set; }
    public string Name { get; set; }
}

