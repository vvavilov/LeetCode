public class Solution {
    public int MaxKilledEnemies(char[][] grid) {
        var enemiesAtCol = new int[grid[0].Length];
        var max = 0;
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        for(int row = 0; row < rows; row++) {
            var enemiesAtRow = 0;

            for(int col = 0; col < cols; col++) {    
                if(col == 0 || grid[row][col - 1] == 'W') {
                    enemiesAtRow = 0;

                    for(int k = col; k < cols; k++) {
                        if(grid[row][k] == 'E') {
                            enemiesAtRow++;
                            continue;
                        }
                        
                        if(grid[row][k] == 'W') {
                            break;
                        }
                    }
                }
                
                if(row == 0 || grid[row - 1][col] == 'W') {
                    enemiesAtCol[col] = 0;

                    for(int k = row; k < rows; k++) {
                        if(grid[k][col] == 'E') {
                            enemiesAtCol[col] += 1;
                            continue;
                        }
                        
                        if(grid[k][col] == 'W') {
                            break;
                        }
                    }
                }
                
                if(grid[row][col] == '0') {
//                     Console.WriteLine(i);
//                     Console.WriteLine(j);

//                     Console.WriteLine(enemiesAtRow);
//                     Console.WriteLine(enemiesAtCol[j]);

                    max = Math.Max(max, enemiesAtRow + enemiesAtCol[col]);
                }
            }
        }
        
        return max;
    }
}