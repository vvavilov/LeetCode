public class ProductOfNumbers {
    private List<int> storage = new();
    private int lastZeroPos = -1;
    
    public ProductOfNumbers() {
        
    }
    
    public void Add(int num) {
        if(num == 0) {
            storage.Add(1);
            lastZeroPos = storage.Count - 1;
            return;
        }
        
        if(storage.Count == 0) {
            storage.Add(num);
            return;
        }

        storage.Add(storage[storage.Count - 1] * num);
    }
    
    public int GetProduct(int k) {
        var withoutZerosCount = storage.Count - lastZeroPos - 1;
        
        if(k > withoutZerosCount) {
            return 0;
        }
        
        if(k == storage.Count) {
            return storage[storage.Count - 1];
        }
                
        return storage[storage.Count - 1] / storage[storage.Count - k - 1];
        
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */

