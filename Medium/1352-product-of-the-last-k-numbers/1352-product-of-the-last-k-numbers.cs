public class ProductOfNumbers {
    private List<int> storage = new List<int>();
    private List<int> product = new List<int>();

    public ProductOfNumbers() {
        
    }
    
    public void Add(int num) {
        product = new List<int>();
        storage.Add(num);
    }
    
    // storage: 1 2 3 4 5
    // product: 5 20 60
    // 3 , 3, 4

    public int GetProduct(int k) {
        var precalculatedCount = product.Count;

        if(k <= precalculatedCount) {
            return product[k - 1];
        }

        var prevProduct = precalculatedCount > 0 ? product[product.Count - 1] : 1;

        for(int i = 0; i < k - precalculatedCount; i++) {
            var element = storage[storage.Count - 1 - precalculatedCount - i];
            prevProduct *= element;
            product.Add(prevProduct);
        }

        return prevProduct;
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */