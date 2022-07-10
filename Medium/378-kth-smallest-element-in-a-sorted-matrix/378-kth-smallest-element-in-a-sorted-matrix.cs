public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        var queue = CreateQueueWithFirstColumnValues(matrix, k);
        (int row, int column) item = (0, 0);
        var itemsCount = k;
        
        while(k-- > 0) {
            item = queue.Dequeue();
        
            (int row, int column) next = (item.row, item.column + 1);
            
            if(next.column == matrix[0].Length) {
                continue;
            }
            
            var nextValue = matrix[next.row][next.column];
            queue.Enqueue(next, nextValue);
            
            if(queue.Count > itemsCount) {
                queue.Dequeue();
            };
        }
        
        return matrix[item.row][item.column];
    }
    
    private PriorityQueue<(int row, int column), int> CreateQueueWithFirstColumnValues(int[][] matrix, int k) {
        PriorityQueue<(int row, int column), int> queue = new();
        
        for(int i = 0; i < matrix.Length; i++) {
            if(queue.Count == k) {
                break;
            }
            queue.Enqueue((i, 0), matrix[i][0]);
        }
        
        return queue;
    }
}