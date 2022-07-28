public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        var connections = new DisjointSet(n);
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                if(isConnected[i][j] == 1) {
                    connections.Connect(i, j);
                }
            }
        }
        
        return connections.UnionsCount();
    }
}

public class DisjointSet {
    private int[] connections;
    private int[] rank;
    
    public DisjointSet(int n) {
        connections = new int[n];
        rank = new int[n];

        for(int i = 0; i < connections.Length; i++) {
            connections[i] = i;
            rank[i] = 1;
        }
    }
    
    private int Root(int x) {
        while(connections[x] != x) {
            var parent = connections[x];
            connections[x] = connections[parent];
            x = parent;
        }
        
        return x;
    }
    
    public void Connect(int i, int j) {
        var leftRoot = Root(i);
        var rightRoot = Root(j);
        
        if(leftRoot == rightRoot) {
            return;
        }
        
        var leftRank = rank[leftRoot];
        var rightRank = rank[rightRoot];
        
        if(leftRank > rightRank) {
            connections[rightRoot] = leftRoot;
        } else if (rightRank > leftRank) {
            connections[leftRoot] = rightRoot;
        } else {
            connections[rightRoot] = leftRoot;
            rank[leftRank]++;
        }
    }
    
    public int UnionsCount() {
        var count = 0;
        
        for(int i = 0; i < connections.Length; i++) {
            if(i == connections[i]) {
                count++;
            }
        }
        
        return count;
    }
}