public class Solution {
    (int y, int x)[] directions = new (int y, int x)[] {
        (0, 1),
        (1, 1),
        (1, 0),
        (1, -1),
        (0, -1),
        (-1,-1),
        (-1, 0),
        (-1, 1)
    };
    
    public char[][] UpdateBoard(char[][] board, int[] click) {
        var y = click[0];
        var x = click[1];
        
        if(board[y][x] == 'M') {
            board[y][x] = 'X';
            return board;
        }
        
        Queue<(int y, int x)> toProcess = new();
        HashSet<(int y, int x)> visited = new();
        
        toProcess.Enqueue((y, x));
        visited.Add((y, x));
        
        while(toProcess.Count > 0) {
            var cell = toProcess.Dequeue();
            var minesAround = CalculateMinesAround(board, cell);
            
            if(minesAround != 0) {
                board[cell.y][cell.x] = minesAround.ToString()[0];
            } else {
                board[cell.y][cell.x] = 'B';
                
                ProcessNeighbours(board, cell, (neigh) => {
                    if(!visited.Contains(neigh)) {
                        toProcess.Enqueue(neigh);
                        visited.Add(neigh);
                    }
                });
            }
        }
        
        return board;
    }
    
    private int CalculateMinesAround(char[][] board, (int y, int x) cell) {
        var minesAround = 0;
            
        ProcessNeighbours(board, cell, (neigh) => {
            var neighValue = board[neigh.y][neigh.x];

            if(neighValue == 'M') {
                minesAround++;
            }
        });
        
        return minesAround;
    }
    
    private void ProcessNeighbours(char[][] board, (int y, int x) cell, Action<(int y, int x)> action) {
        foreach(var dir in directions) {
            var neighY = cell.y + dir.y;
            var neighX = cell.x + dir.x;
            
            if(IsInBound(board, neighY, neighX)) {
                action((neighY, neighX));
            }
        }
    }
    
    private bool IsInBound(char[][] board, int y, int x) {
        if(y < 0 || x < 0 || y == board.Length || x == board[0].Length) {
            return false;
        }
        
        return true;
    } 
}