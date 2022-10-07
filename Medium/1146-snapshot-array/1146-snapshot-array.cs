public class SnapshotArray {
    List<(int value, int version)>[] versions;
    HashSet<int> dirty = new(); 
    int currentVersion = 0;

    public SnapshotArray(int length) {
        versions = new List<(int value, int version)>[length];
        
        for(int i = 0; i < versions.Length; i++) {
            versions[i] = new List<(int value, int version)>();
            versions[i].Add((0, currentVersion));
            dirty.Add(i);
        }
    }
    
    public void Set(int index, int val) {
        if(dirty.Contains(index)) {
            var last = versions[index].Count - 1;
            versions[index][last] = (val, versions[index][last].version);
        } else {
            dirty.Add(index);
            versions[index].Add((val, currentVersion));
        }
    }
    
    public int Snap() {
        dirty = new();
        currentVersion++;
        return currentVersion - 1;
    }
    
    public int Get(int index, int snap_id) {
        var item = versions[index];
        return FindEqualOrClosestLower(item, snap_id);
    }
    
    private int FindEqualOrClosestLower(List<(int value, int version)> versions, int version) {
        var left = 0;
        var right = versions.Count - 1;
        
        while(left < right) {
            var mid = (int)Math.Ceiling((right - left) / 2f) + left;
            
            if(versions[mid].version == version) {
                return versions[mid].value;
            }
            
            if(versions[mid].version < version) {
                left = mid;
            } else {
                right = mid - 1;  
            }
        }
        
        return versions[left].value;
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */