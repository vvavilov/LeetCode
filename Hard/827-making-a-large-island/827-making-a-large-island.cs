public class Solution {
    public int LargestIsland(int[][] grid) {
        if(grid.Length == 0) {
            return 0;
        }

        var directions = new (int y, int x)[] {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0)
        };

        var n = grid.Length;

        var union = new DisjoinedSet(n * n);
        var result = 0;
        
        for(int i = 0; i < grid.Length; i++) {
            for(int j = 0; j < grid[0].Length; j++) {
                if(grid[i][j] == 0) {
                    continue;
                }

                foreach(var dir in directions) {
                    var neighY = dir.y + i;
                    var neighX = dir.x + j;

                    if(!IsInside(neighY, neighX, grid.Length)) {
                        continue;
                    }

                    if(grid[neighY][neighX] == 0) {
                        continue;
                    }

                    union.Join(neighY * n + neighX, i * n + j);
                }
            }
        }

        for(int i = 0; i < grid.Length; i++) {
            for(int j = 0; j < grid[0].Length; j++) {
                result = Math.Max(result, union.GetSize(i * n + j));

                if(grid[i][j] == 1) {
                    continue;
                }

                var processedCells = new List<int>();
                var potentialSum = 1;

                foreach(var dir in directions) {
                    var neighY = dir.y + i;
                    var neighX = dir.x + j;

                    if(!IsInside(neighY, neighX, grid.Length)) {
                        continue;
                    }

                    if(grid[neighY][neighX] == 0) {
                        continue;
                    }

                    var neighId = neighY * n + neighX;
                    var alreadyCalculated = processedCells.Any(x => union.IsSame(x, neighId));

                    if(alreadyCalculated) {
                        processedCells.Add(neighId);
                        continue;
                    }

                    processedCells.Add(neighId);
                    potentialSum += union.GetSize(neighId);
                }

                result = Math.Max(result, potentialSum);
            }
        }

        return result;
    }

    public bool IsInside(int y, int x, int size) {
        return x >= 0 && y >= 0 && x < size && y < size;
    }
}

public class DisjoinedSet {
    private int[] roots;
    private int[] size;
    
    public DisjoinedSet(int n) {
        roots = new int[n];
        size = new int[n];

        for(int i = 0 ; i < n; i++) {
            roots[i] = i;
            size[i] = 1;
        }
    }

    private int Root(int cell) {
        var parent = roots[cell];

        while(cell != roots[cell]) {
            parent = roots[cell];
            roots[cell] = roots[parent];
            cell = parent;
        }

        return cell;
    }

    public void Join(int left, int right) {
        var leftRoot = Root(left);
        var rightRoot = Root(right);

        if(leftRoot == rightRoot) {
            return;
        } 

        roots[leftRoot] = rightRoot;
        size[rightRoot] += size[leftRoot];
    }

    public int GetSize(int island) {
        return size[Root(island)];
    }

    public bool IsSame(int left, int right) {
        return Root(left) == Root(right);
    }
}

/*
1 0 0 0 1 0 1 0 1
0 1 0 0 1 0 0 0 0
1 0 1 0 1 1 0 0 0
1 1 1 1 1 0 0 0 0
1 1 0 1 0 1 1 1 0
0 0 0 1 0 1 0 1 1
1 1 1 1 0 0 1 1 0
0 1 1 1 0 1 0 0 1
1 1 1 0 1 0 1 0 1

*/