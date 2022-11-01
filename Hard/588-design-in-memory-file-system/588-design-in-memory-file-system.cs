public class FileSystem {
    private Folder Root = new();

    public FileSystem() {
        
    }
    
    public IList<string> Ls(string path) {
        var pathSegments = SplitPath(path);
        
        if(pathSegments.Count == 0) {
            return Root.List();
        }
        
        var folder = Root;
        
        foreach(var x in pathSegments.SkipLast(1)) {
            folder = (Folder)folder.Children[x];
        }
        
        return folder.Children[pathSegments.Last()].List();
    }
    
    public void Mkdir(string path) {
        var pathSegments = SplitPath(path);
        var folder = Root;
        
        foreach(var x in pathSegments) {
            if(!folder.Children.ContainsKey(x)) {
                folder.Children[x] = new Folder();
            } 
            
            folder = (Folder)folder.Children[x];
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        var pathSegments = SplitPath(filePath);
        var folder = NavigateToFolder(pathSegments.SkipLast(1));
        var fileName = pathSegments.Last();
        
        if(!folder.Children.ContainsKey(fileName)) {
            folder.Children[fileName] = new File { Name = fileName };
        }
        
        var file = (File)folder.Children[fileName];
        
        file.Content = file.Content + content;
    }
    
    public string ReadContentFromFile(string filePath) {
        var pathSegments = SplitPath(filePath);
        var folder = NavigateToFolder(pathSegments.SkipLast(1));
        
        var fileName = pathSegments.Last();
        return ((File)folder.Children[fileName]).Content;
        
    }
    
    private List<string> SplitPath(string path) {
        if(path == "/") {
            return new List<string>();
        }
        return path.Split('/').Skip(1).ToList();
    }
    
    private Folder NavigateToFolder(IEnumerable<string> path) {
        var folder = Root;

        foreach(var x in path) {            
            folder = (Folder)folder.Children[x];
        }
        
        return folder;
    }
}

public interface Entity {
    List<string> List();
}

public class Folder : Entity {
    public SortedDictionary<string, Entity> Children { get; set; } = new();
    
    public List<string> List() {
        return Children.Keys.ToList();
    }
}

public class File : Entity {
    public string Name { get; set; }
    
    public List<string> List() {
        return new List<string> { Name };
    }
    
    public string Content { get; set; }
}



/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */