public class Solution {
    public string AddStrings(string num1, string num2) {
        var result = new StringBuilder();
        var num1Pos = num1.Length - 1;
        var num2Pos = num2.Length - 1;
        var carry = 0;

        while(num1Pos >= 0 && num2Pos >= 0) {
            carry = AppendNumber(result, (int)Char.GetNumericValue(num1[num1Pos]), (int)Char.GetNumericValue(num2[num2Pos]), carry);
            num1Pos--;
            num2Pos--;
        }

        while(num2Pos >= 0) {
            carry = AppendNumber(result, (int)Char.GetNumericValue(num2[num2Pos]), 0, carry);
            num2Pos--;
        }

        while(num1Pos >= 0) {
            carry = AppendNumber(result, (int)Char.GetNumericValue(num1[num1Pos]), 0, carry);
            num1Pos--;
        }

        if(carry == 1) {
            result.Append(1);
        }

        return new string(result.ToString().Reverse().ToArray());
    }

    private int AppendNumber(StringBuilder sb, int digit1, int digit2, int carry) {
        var sum = carry + digit1 + digit2;
        sb.Append(sum % 10);
        return sum > 9 ? 1 : 0;
    }
}