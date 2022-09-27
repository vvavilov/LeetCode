public class Solution {
    public string SimplifyPath(string path) {
        var tokens = path.Split('/')
            .Where(token => token != "")
            .Where(token => token != ".")
            .ToArray();

        Stack<string> simplified = new();

        foreach(var x in tokens) {
            if(x != "..") {
                simplified.Push(x);
                continue;
            }

            if(simplified.Count == 0) {
                continue;
            }

            simplified.Pop();
        }


        var result = "/" + String.Join("/", simplified.Reverse());
        return result;
    }
}
// //../folder1//folder2/folder3/

/*
1. split by slashes
2a. remove single slashes from the array
2b. remove single dots and multuple dots
3. trim entities to remove beginning and ending slashes
4. combining entities with single slashes between tham
5. add single slash at the beginning

*/