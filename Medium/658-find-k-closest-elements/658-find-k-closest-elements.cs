public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        List<int> result = new();

        if(k == 0) {
            return result;
        }
        
        var closestOne = FindSingleClosest(arr, x);
        
        Console.WriteLine(closestOne);
        var numberOfItems = k;

        k--;
        var left = closestOne - 1;
        var right = closestOne + 1;
        
        
        while(k > 0) {
            if(left < 0) {
                break;
            }
            
            var closest = GetClosestOfTwo(left, right, x, arr);
    
            if(closest == left) {
                left--;    
            } else {
                right++;
            }

            k--;
        }
        
        while(numberOfItems > 0) {
            result.Add(arr[left + 1]);
            left++;
            numberOfItems--;
        }
        
        return result;
    }
    
    private int GetClosestOfTwo(int left, int right, int x, int[] arr) {
        if(left < 0) {
            return right;
        }
        
        if(right == arr.Length) {
            return left;
        }
        
        var leftDif = Math.Abs(x - arr[left]);
        var rightDif = Math.Abs(x - arr[right]);
        
        if(leftDif == rightDif ) {
            return left;    
        }
        
        if(leftDif < rightDif) {
            return left;
        }
        
        return right;
    }
    
    private int FindSingleClosest(int[] arr, int x) {
        var left = 0;
        var right = arr.Length - 1;
        
        while(right - left > 1) {
            var mid = (right + left) / 2;
            var val = arr[mid];
            
            if(val == x) {
                return mid;
            }
            
            if(val > x) {
                right = mid;
                continue;
            }
            
            left = mid;
        }
        
        return GetClosestOfTwo(left, right, x, arr);
    }
}