public class Solution {
//     1 2 3 4 5 6
//
        
        //     6 -> 6
    //     56 -> max(5,6);
    //    456 -> max(sum(4,f(6), f(5))
    //   3456 -> max(sum(3,f(56)), sum(4,f(6))
    //  23456 -> max(sum(2, f(456)), sum(3, f(56)))
    // 123456 -> max(sum(1, f(3456)), sum(2, f(456)),
//         f(n) = {
//                  6 -> n[6]
//                  5 -> n[5]
                    // 1-4 -> max(n[n] + n[n+2], n[n+1])
//         
            
            
    public int Rob(int[] nums) {
        
        
        var plan = MakePlan(nums, nums.Length - 1);
        return Math.Max(plan.Rob, plan.DoNotRob);
        
    }
    
    private State MakePlan(int[] nums, int houseNumber) {
        if(houseNumber == 0) {
            return new State {
                Rob = nums[0],
                DoNotRob = 0
            };
        }
        
        var previous = MakePlan(nums, houseNumber - 1);
        return new State {
            Rob = previous.DoNotRob + nums[houseNumber],
            DoNotRob = Math.Max(previous.DoNotRob, previous.Rob)
        };
        
    }
}

public class State {
    public int Rob;
    public int DoNotRob;
}