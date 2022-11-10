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
    public int FindDistance(TreeNode root, int p, int q) {
        return Dfs(root, p, q).Between;
    }
    
    private Distance Dfs(TreeNode node, int p,  int q) {
        if(node == null) {
            return Distance.NotFound();
        }
        
        var leftResult = Dfs(node.left, p, q);
        
        if(leftResult.HasBetween) {
            return leftResult;
        }
        
        var rightResult = Dfs(node.right, p, q);
        
        if(rightResult.HasBetween) {
            return rightResult;
        }
        
        if(leftResult.HasToNode && rightResult.HasToNode) {
            return Distance.OfBetween(leftResult.ToNode + rightResult.ToNode);
        }
        
        var childDistance = DistanceToSingleChild(leftResult, rightResult);
        
        if(node.val == p && node.val == q) {
            return Distance.OfBetween(0);
        }
        
        if(node.val == p || node.val == q) {
            if(childDistance.HasToNode) {
                return Distance.OfBetween(childDistance.ToNode);
            }
        
            return Distance.OfToNode(1);
        }
        
        if(childDistance.HasToNode) {
            return Distance.OfToNode(childDistance.ToNode + 1);
        }
    
        return childDistance;
    }
    
    private Distance DistanceToSingleChild(Distance left, Distance right) {
        if(left.HasToNode) {
            return left;
        }
        
        
        if(right.HasToNode) {
            return right;
        }
        
        return Distance.NotFound();
    }
}

public class Distance {
    public int Between {get;set;}
    public int ToNode {get;set;}
    
    public bool HasBetween {
        get {
            return Between != -1;
        }
    }
    
    public bool HasToNode {
        get {
            return ToNode != -1;
        }
    }
    
    public static Distance OfBetween(int betweenDistance) {
        return new Distance {
            Between = betweenDistance,
            ToNode = -1
        };
    }
    
    public static Distance OfToNode(int toNodeDistance) {
        return new Distance {
            ToNode = toNodeDistance,
            Between = -1
        };
    }
    
    public static Distance NotFound() {
        return new Distance {
            Between = -1,
            ToNode = -1
        };
    }
}