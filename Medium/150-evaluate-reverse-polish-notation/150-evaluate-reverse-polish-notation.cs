public class Solution {
    public int EvalRPN(string[] tokens) {
        var numbers = new Stack<int>();

        for(int i = 0; i < tokens.Length; i++) {
            var token = tokens[i];
            var isNumber = Int32.TryParse(token, out var number);

            if(!isNumber) {
                ExecuteOperation(numbers, token);
            } else {
                numbers.Push(number);
            }
        }

        return numbers.Pop();
    }

    private void ExecuteOperation(Stack<int> numbers, string op) {
        var right = numbers.Pop();
        var left = numbers.Pop();
        var result = 0;

        switch(op) {
            case "*" :
                result = right * left;
                break;
            case "/" :
                result = left / right;
                break;
            case "+" :
                result = left + right;
                break;
            case "-" :
                result = left - right;
                break;
        }

        numbers.Push(result);
    }
}