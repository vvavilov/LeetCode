/**
 * This is the interface for the expression tree Node.
 * You should not remove it, and you can define some classes to implement it.
 */

public abstract class Node {
    public abstract int evaluate();
    // define your fields here
};

public abstract class Operator : Node {
    public Node Left {get;set;}
    public Node Right {get;set;}
    
    public override int evaluate() {
        return DoEvaluate(Left.evaluate(), Right.evaluate());
    }
    
    protected abstract int DoEvaluate(int left, int right);
}

public class Multiplication : Operator {
    protected override int DoEvaluate(int left, int right) {
        return left * right;
    }
}

public class Division : Operator {
    protected override int DoEvaluate(int left, int right) {
        return left / right;
    }
}

public class Substraction : Operator {
    protected override int DoEvaluate(int left, int right) {
        return left - right;
    }
}

public class Addition : Operator {
    protected override int DoEvaluate(int left, int right) {
        return left + right;
    }
}

public class Operand : Node {
    public int Value {get;set;}
    
    public override int evaluate() {
        return Value;
    }
}


/**
 * This is the TreeBuilder class.
 * You can treat it as the driver code that takes the postinfix input 
 * and returns the expression tree represnting it as a Node.
 */

public class TreeBuilder {
    public Node buildTree(string[] postfix) {
        Stack<Node> pending = new();
        var factory = new NodeFactory();

        foreach(var x in postfix) {
            var node = factory.Create(x);
            var op = node as Operator;
            
            if(op == null) {
                pending.Push(node);
            } else {
                op.Right = pending.Pop();
                op.Left = pending.Pop();
                pending.Push(node);
            }
        }
        
        return pending.Pop();
    }
}

public class NodeFactory {
    public Node Create(string source) {
        var isNumber = Int32.TryParse(source, out var number);
        
        if(isNumber) {
            return new Operand { Value = number };
        }
        
        switch(source) {
            case "*" :
                return new Multiplication();
            case "/" :
                return new Division();
            case "-" :
                return new Substraction();
            case "+" :
                return new Addition();

            default : throw new Exception();
        }
    }
}




/**
 * Your TreeBuilder object will be instantiated and called as such:
 * TreeBuilder obj = new TreeBuilder();
 * Node expTree = obj.buildTree(postfix);
 * int ans = expTree.evaluate();
 */