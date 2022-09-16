public class Solution {

    
    public string IntToRoman(int num) {
        var result = new StringBuilder();
        var integers = new[] {1000,900,500,400,100,90,50,40,10,9,5,4,1};
        var romans = new[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        
        for(int i = 0; i < integers.Length; i++) {
            var integer = integers[i];
            var roman = romans[i];
            
            var count = num / integer;
            num -= count * integer;
            
            while(count-- > 0) {
                result.Append(roman);
            }
        }

//         if(num >= 1000) {
//             var numberOfM = num / 1000;
//             num -= numberOfM * 1000;

//             result.Append('M', numberOfM);
//         }

//         if(num >= 900) {
//             result.Append("CM");
//             num -= 900;
//         }

//         if(num >= 500) {
//             result.Append("D");
//             num -= 500;
//         }

//         if(num >= 400) {
//             result.Append("CD");
//             num -= 400;
//         }

//         if(num >= 100) {
//             var numberOfC = num / 100;
//             num -= numberOfC * 100;
//             result.Append('C', numberOfC);
//         }

//         if(num >= 90) {
//             result.Append("XC");
//             num -= 90;
//         }

//         if(num >= 50) {
//             result.Append('L');
//             num -= 50;
//         }

//         if(num >= 40) {
//             result.Append("XL");
//             num -= 40;
//         }

//         if(num >= 10) {
//             var numberOfX = num / 10;
//             result.Append('X', numberOfX);
//             num -= numberOfX * 10;
//         }

//         if(num == 9) {
//             result.Append("IX");
//             num -= 9;
//         }

//         if(num >= 5) {
//             result.Append('V');
//             num -= 5;
//         }

//         if(num == 4) {
//             result.Append("IV");
//             num -= 4;
//         }

//         result.Append('I', num);
        return result.ToString();



        // 0 - 4

    }
}