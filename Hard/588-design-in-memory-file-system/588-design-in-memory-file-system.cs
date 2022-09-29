

public class FileSystem {
    public Folder Root = new Folder();
    
    public FileSystem() {
        
    }
    
    private IList<string> SplitPath(string path) {
        if(path == "/") {
            return new List<string>();
        }
        return path.Trim('/').Split('/');
        
    } 
    
    public IList<string> Ls(string path) {
        var entities = SplitPath(path);
        Folder folder = Root;
        
        if(path == "/") {
            return Root.Children.Keys.ToList<string>();
        }
        
        foreach(var x in entities.SkipLast(1)) {
            folder = folder.GetOrCreateFolder(x);
        }
        
        if(folder.Children[entities.Last()] is File) {
            return new List<string> { entities.Last() };
        }
        
        return folder.GetOrCreateFolder(entities.Last()).Children.Keys.ToList<string>();
    }
    
    public void Mkdir(string path) {
        var entities = SplitPath(path);
        var folder = Root;
        
        foreach(var x in entities) {
            folder = folder.GetOrCreateFolder(x);
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        var entities = SplitPath(filePath);
        var folder = Root;
        
        foreach(var x in entities.SkipLast(1)) {
            folder = folder.GetOrCreateFolder(x);
        }
        
        var existingFile = folder.GetOrCreateFile(entities.Last());
        existingFile.Content += content;
    }
    
    public string ReadContentFromFile(string filePath) {
        var entities = SplitPath(filePath);
        var folder = Root;
        
        foreach(var x in entities.SkipLast(1)) {
            folder = folder.GetOrCreateFolder(x);
        }
        
        return folder.GetOrCreateFile(entities.Last()).Content;
    }
}

public interface IEntity {
}

public class Folder : IEntity {
    public SortedDictionary<string, IEntity> Children {get;set;} = new();
    
    public Folder GetOrCreateFolder(string name) {
        if(!Children.ContainsKey(name)) {
            Children[name] = new Folder();
        }

        return (Folder)Children[name];
    }
    
    public File GetOrCreateFile(string name) {
        if(!Children.ContainsKey(name)) {
            Children[name] = new File();
        }
        
        return (File)Children[name];
    }

}

public class File : IEntity {
    public string Content {get;set;}
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */