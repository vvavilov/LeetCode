/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        List<int> solution = new();
        DistanceToChildTarget(root, target, solution, k);
        return solution;
    }
    
    private int DistanceToChildTarget(TreeNode node, TreeNode target, IList<int> solution, int distance) {
        if(node == null) {
            return -1;
        }
        
        if(node == target) {
            MarkNodesAtDistance(node, distance, solution);
            return 0;
        }
     
        var leftDistance = DistanceToChildTarget(node.left, target, solution, distance) + 1;
        
        if(leftDistance > 0) {
            var restDistance = distance - leftDistance;
            
            if(restDistance == 0) {
                solution.Add(node.val);
            } else {
                MarkNodesAtDistance(node.right, restDistance - 1, solution);
            }

            return leftDistance;
            
        }
        
        var rightDistance = DistanceToChildTarget(node.right, target, solution, distance) + 1;

        if(rightDistance > 0) {
            var restDistance = distance - rightDistance;
            
            if(restDistance == 0) {
                solution.Add(node.val);
            } else {
                MarkNodesAtDistance(node.left, restDistance - 1, solution);
            }

            return rightDistance;
        }
        
        return -1;
    }
    
    private void MarkNodesAtDistance(TreeNode node, int distance, IList<int> solution) {
        if(node == null || distance < 0) {
            return;
        }
        
        if(distance == 0) {
            solution.Add(node.val);
            return;
        }
        
        MarkNodesAtDistance(node.left, distance - 1, solution);
        MarkNodesAtDistance(node.right, distance - 1, solution);

    }
    
    
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class SolutionWithParents {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        Dictionary<int, TreeNode> parents = new();
        FillParents(root, parents);
        
        var distance = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(target);
        
        List<int> result = new();
        HashSet<int> visited = new();
        
        while(queue.Count > 0) {
            var count = queue.Count;
            
            for(int i = 0; i < count; i++) {
                var node = queue.Dequeue();
                
                if(visited.Contains(node.val)) {
                    continue;
                }
                
                if(k == distance) {
                    result.Add(node.val);
                    continue;
                }
                
                visited.Add(node.val);
                parents.TryGetValue(node.val, out var parent);
                
                if(parent != null) {
                    queue.Enqueue(parent);
                }
                
                if(node.left != null) {
                    queue.Enqueue(node.left);
                }
                
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            
            distance++;
        }
        
        return result;
        
    }
    
    private void FillParents(TreeNode node, Dictionary<int, TreeNode> parents) {
        if(node.left != null) {
            parents[node.left.val] = node;
            FillParents(node.left, parents);
        }
        
        if(node.right != null) {
            parents[node.right.val] = node;
            FillParents(node.right, parents);
        }
    } 
}