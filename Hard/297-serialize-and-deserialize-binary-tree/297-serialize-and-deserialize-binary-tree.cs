/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) {
            return string.Empty;
        }

        var result = new StringBuilder();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0) {
            var node = queue.Dequeue();

            if(node == null) {
                result.Append(".,");
                continue;
            }

            result.Append(node.val + ",");
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
    
        result.Remove(result.Length - 1, 1);
        return result.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(String.IsNullOrEmpty(data)) {
            return null;
        }

        int?[] nodes = data.Split(",").Select(x => {
            var isDigit = Int32.TryParse(x, out var value);
            int? result = isDigit ? value : null;

            return result;
        }).ToArray();

        var pos = 1;
        var root = new TreeNode(nodes[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count > 0 && pos < nodes.Length) {
            var node = queue.Dequeue();

            var left = nodes[pos] == null ? null : new TreeNode(nodes[pos].Value);
            var right = nodes[pos + 1] == null ? null : new TreeNode(nodes[pos + 1].Value);
            node.left = left;
            node.right = right;

            if(left != null) {
                queue.Enqueue(left);
            }

            if(right != null) {
                queue.Enqueue(right);
            }

            pos = pos + 2;
        }

        return root;
    }

}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));