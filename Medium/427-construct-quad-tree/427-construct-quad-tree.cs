/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

// 0 1
// 
// 1 0
//
//

public class Solution {
    public Node Construct(int[][] grid) {
        if(grid.Length == 0) {
            return null;
        }

        return Dfs(grid, 0, 0, grid.Length);
    }
    
    private Node Dfs(int[][] grid, int x, int y, int size) {
        if(size == 1) {
            return new Node {
                val = grid[y][x] == 1,
                isLeaf = true
            };
        }
        
        var halfSize = size / 2;
        var xMid = x + halfSize;
        var yMid = y + halfSize;
        
        
        var topLeft = Dfs(grid, x, y , halfSize);
        var topRight = Dfs(grid, xMid, y, halfSize);
        var bottomLeft = Dfs(grid, x, yMid, halfSize);
        var bottomRight = Dfs(grid, xMid, yMid, halfSize);
        
        return BuildNode(topLeft, topRight, bottomLeft, bottomRight);
    }
    
    private Node BuildNode(Node topLeft, Node topRight, Node bottomLeft, Node bottomRight) {
        var allLeafs = topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf;
        
        if(allLeafs
           && topLeft.val == topRight.val
           && topLeft.val == bottomLeft.val
           && topLeft.val == bottomRight.val
          ) {
            return new Node {
                isLeaf = true,
                val = topLeft.val
            };
        }
        
        return new Node {
            isLeaf = false,
            topLeft = topLeft,
            topRight = topRight,
            bottomLeft = bottomLeft,
            bottomRight = bottomRight
        };
    }
}