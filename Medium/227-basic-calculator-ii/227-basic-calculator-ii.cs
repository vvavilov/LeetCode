public class Solution {
    public int Calculate(string s) {
        var postfixNotation = BuildPostfix(s);
        var numbers = new Stack<int>();
        
        foreach(var token in postfixNotation) {
            var op = token as Operator;
            
            if(op == null) {
                numbers.Push((token as Number).Value);   
            } else {
                var right = numbers.Pop();
                var left = numbers.Pop();
                var result = 0;
                switch (op.Value) {
                    case '*' :
                        result = left * right;
                        break;
                    case '/' :
                        result = left / right;
                        break;
                    case '+':
                        result = left + right;
                        break;
                    case '-':
                        result = left - right;
                        break;
                }
                
                numbers.Push(result);
            }
        }
        return numbers.Pop();
    }
    
    
    private List<IToken> BuildPostfix(string s) {
        List<IToken> output = new();
        Stack<Operator> operators = new();
        
        for (int i = 0; i < s.Length; i++) {
            var symbol = s[i];
            
            if(symbol == ' ') {
                continue;
            }
            
            if(Char.IsDigit(symbol)) {
                var start = i;
                
                while(i + 1 < s.Length && Char.IsDigit(s[i+1])) {
                    i++;
                }
                
                var number = Int32.Parse(s.Substring(start, i - start + 1));
                output.Add(new Number(number));
                continue;
            }
            
            var op = new Operator(symbol);
            
            while(operators.Count > 0
                  && (operators.Peek().HasBiggerPriority(op) || operators.Peek().HasSamePriority(op))
            ) {
                  output.Add(operators.Pop());
            }
                  
            operators.Push(op);
        }
        
        while(operators.Count > 0) {
            output.Add(operators.Pop());
        }           
        
        return output;
    }
}

public interface IToken {
    
}

public class Number : IToken {
    public int Value {get;set; }
    
    public Number(int value) {
        this.Value = value;
    }
}

public class Operator : IToken {
    public char Value {get;set;}
    
    public Operator(char value) {
        this.Value = value;
    }
    
    public bool HasBiggerPriority(Operator other) {
        if(Value == '*' || Value == '/') {
            return other.Value == '-' || other.Value == '+';
        }
        
        return false;
        
    }
    
    public bool HasSamePriority(Operator other) {
        if(Value == '*' || Value == '/') {
            return other.Value == '*' || other.Value == '/';
        }
        
        return other.Value == '+' || other.Value == '-';
    }
}
