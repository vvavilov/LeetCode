public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        for (int i = 0; i < mat.Length; i++) {
            for (int j = 0; j < mat[0].Length; j++) {
                if(mat[i][j] != 0) {
                    mat[i][j] = mat.Length + mat[0].Length;
                } 
            }
        }
        
        for (int i = 0; i < mat.Length; i++) {
            for (int j = 0; j < mat[0].Length; j++) {
                if(mat[i][j] == 0) {
                    continue;
                }
                if(i != 0) {
                    mat[i][j] = Math.Min(mat[i-1][j] + 1, mat[i][j]);
                }
                if(j !=0) {
                    mat[i][j] = Math.Min(mat[i][j-1] + 1, mat[i][j]);
                }
            }
        }
        
        for (int i = mat.Length - 1; i >=0; i--) {
            for (int j = mat[0].Length - 1; j >=0; j--) {
                if(mat[i][j] == 0) {
                    continue;
                }
                if(i < mat.Length - 1) {
                    mat[i][j] = Math.Min(mat[i+1][j] + 1, mat[i][j]);
                }
                if(j < mat[0].Length - 1) {
                    mat[i][j] = Math.Min(mat[i][j+1] + 1, mat[i][j]);
                }
            }
        }
        return mat;
    }
    
    public int[][] UpdateMatrixBFS(int[][] mat) {
        var queue = new Queue<(int x, int y)>();
        for (int i = 0; i < mat.Length; i++) {
            for (int j = 0; j < mat[i].Length; j++) {
                if(mat[i][j] == 0) {
                    queue.Enqueue((i, j));
                } else {
                    mat[i][j] = Int32.MaxValue;
                }
            }
        }
        
        while(queue.Count > 0) {
            (var y, var x) = queue.Dequeue();
            var value =  mat[y][x] + 1;
            
            if (y > 0) {
                if (mat[y-1][x] > value) {
                    mat[y-1][x] = value;
                    queue.Enqueue((y-1,x));
                }
            }
            
            if (x < mat[0].Length - 1) {
                if (mat[y][x+1] > value) {
                    mat[y][x+1] = value;
                    queue.Enqueue((y,x+1));
                }
            }
            
            if (y < mat.Length - 1) {
                if (mat[y+1][x] > value) {
                    mat[y+1][x] = value;
                    queue.Enqueue((y+1,x));
                }
            }
            
            if (x > 0) {
                if (mat[y][x-1] > value) {
                    mat[y][x-1] = value; 
                    queue.Enqueue((y,x-1));
                }
            }
        }
        
        return mat;
    }
    
    public int[][] UpdateMatrixStupid(int[][] mat) {
        // n*m*(n+m)
        var toProcessCount = mat.Length * mat[0].Length;
        for (int i = 0; i < mat.Length; i++) {
            for (int j = 0; j < mat[i].Length; j++) {
                var item = mat[i][j];
                if (item == 1) {
                    mat[i][j] = mat.Length + mat[i].Length;
                }
            }
        }
        
        var currentIteration = 0;
        while(toProcessCount > 0) {
            for (int i = 0; i < mat.Length; i++) {
                for (int j = 0; j < mat[i].Length; j++) {
                    var item = mat[i][j];
                    if (item == currentIteration) {
                        toProcessCount--;
                        if(j > 0) {
                            mat[i][j-1] = Math.Min(mat[i][j-1], currentIteration + 1);
                        }
                        if(i > 0) {
                            mat[i-1][j] = Math.Min(mat[i-1][j], currentIteration + 1);
                        }
                        if(j < mat[i].Length - 1) {
                            mat[i][j+1] = Math.Min(mat[i][j+1], currentIteration + 1);
                        }
                        if(i < mat.Length - 1) {
                            mat[i+1][j] = Math.Min(mat[i+1][j], currentIteration + 1);
                        }
                    }
                }
            }
            currentIteration++;
        }
        return mat;
    }
   
}