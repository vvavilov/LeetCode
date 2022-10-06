public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        /*
        1.Sort By teimstamp
        2. Union Find
        */
        
        var unionFind = new UnionFind(n);
        var orderedByTimestamp = logs.OrderBy(x => x[0]);
        
        foreach(var x in orderedByTimestamp) {
            unionFind.Union(x[1], x[2]);
            
            if(unionFind.HasSingleUnion) {
                return x[0];
            }
        }
        
        return -1;
    }
}

public class UnionFind {
    private int[] roots;
    private int unionsCount;
    
    public UnionFind(int n) {
        roots = new int[n];
        unionsCount = n;
        
        for(int i = 0; i < n; i++) {
            roots[i] = i;
        }
    }
    
    private int Root(int node) {        
        while(roots[node] != node) {
            var parent = roots[node];
            
            if(roots[parent] != parent) {
                roots[node] = roots[parent];
            }
            
            node = parent;
        }

        return node;
    }
    
    public void Union(int y, int x) {
        var yRoot = Root(y);
        var xRoot = Root(x);
        
        if(yRoot != xRoot) {
            roots[yRoot] = xRoot;
            unionsCount--;
        }
    }
    
    public bool HasSingleUnion {
        get {
            return unionsCount == 1;
        }
    }
}