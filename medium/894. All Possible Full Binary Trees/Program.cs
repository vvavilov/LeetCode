/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<TreeNode> AllPossibleFBT(int n) {
        var trees = new List<TreeNode>[n + 1];
        trees[0] = new List<TreeNode>();
        trees[1] = new List<TreeNode> { new TreeNode() };
        
        for(int i = 2; i < trees.Length; i++) {
            trees[i] = new List<TreeNode>();
            
            if(i % 2 == 0) {
                continue;
            }
            
            for(int j = 1; j <= i - 1; j+=2) {
                var leftNodes = trees[j];
                var rightNodes = trees[i - j - 1];
                
                foreach(var left in leftNodes) {
                    foreach(var right in rightNodes) {
                        trees[i].Add(new TreeNode(0, left, right));
                    }
                }
            }
        }
        
        return trees[n];
    }
    
    
    
    Dictionary<int, IList<TreeNode>> mem = new Dictionary<int, IList<TreeNode>>();
    public IList<TreeNode> AllPossibleFBT_TopDown(int n) {
        if(mem.ContainsKey(n)) {
            return mem[n];
        }
        if(n % 2 == 0) {
            return new List<TreeNode>();
        }

        if(n == 1) {
            return new List<TreeNode> { new TreeNode() };
        }
        
        var nodes = new List<TreeNode>();
        
        for(int i = 1; i < n; i+=2) {
            var lefts = AllPossibleFBT(i);
            var rights = AllPossibleFBT(n - i - 1);
            
            foreach(var left in lefts) {
                foreach(var right in rights) {
                    nodes.Add(new TreeNode(0, left, right));
                }
            }
        }
        
        mem[n] = nodes;
        return nodes;
    }
}