public class Solution {
    
    public string CountOfAtoms(string formula) {
        
        Stack<int> multipliers = new();
        SortedDictionary<string, int> byCount = new();

        var currentNumber = 0;
        var numberMultiplier = 1;
        
        multipliers.Push(1);

        for(int i = formula.Length - 1; i >= 0; i--) {
            var element = formula[i];

            if(Char.IsDigit(element)) {
                currentNumber = currentNumber + Int32.Parse(element.ToString()) * numberMultiplier;
                numberMultiplier *= 10;
                continue;
            }  

            if(element == '(') {
                multipliers.Pop();
            }

            if(element == ')') {
                multipliers.Push(multipliers.Peek() * (currentNumber == 0 ? 1 : currentNumber));
            }

            if(Char.IsUpper(element)) {
                Increase(byCount, multipliers.Peek() * (currentNumber == 0 ? 1 : currentNumber), element.ToString());    
            }

            if(Char.IsLower(element)) {
                var elementName = formula.Substring(i - 1, 2);
                Increase(byCount, multipliers.Peek() * (currentNumber == 0 ? 1 : currentNumber), elementName);
                i--;
            }

            currentNumber = 0;
            numberMultiplier = 1;
        }


        return Format(byCount);
    }
    
    private void Increase(SortedDictionary<string, int> byCount, int count, string name) {
        byCount.TryGetValue(name, out var current);
        byCount[name] = count + current;
    }
    
    private string Format(SortedDictionary<string, int> byCount) {
        StringBuilder result = new();
        
        foreach(var x in byCount) {
            result.Append(x.Key);
            
            if(x.Value > 1) {
                result.Append(x.Value);
            }
        }
        
        return result.ToString();
    }
}
