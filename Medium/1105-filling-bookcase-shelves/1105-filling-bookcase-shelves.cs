public class Solution {
    public int MinHeightShelves(int[][] books, int shelfWidth) {
        var dp = new Dictionary<(int bookPos, int curWidth), int>();
        return DFS(books, 0, 0, 0, shelfWidth, dp);
    }

    private int DFS(
        int[][] books,
        int bookPos,
        int currentHeight,
        int currentWidth,
        int shelfWidth,
        Dictionary<(int bookPos, int curWidth), int> dp
    ) {
        if(bookPos == books.Length) {
            return currentHeight;
        }

        if(dp.ContainsKey((bookPos, currentWidth))) {
            return dp[(bookPos, currentWidth)];
        }

        var book = books[bookPos];
        // next shelf
        var nextShelfResult = currentHeight + DFS(books, bookPos + 1, book[1], book[0], shelfWidth, dp);
        // currentShelf
        var currentShelfResult = Int32.MaxValue;

        if(currentWidth + book[0] <= shelfWidth) {
            var shelfHeight = Math.Max(currentHeight, book[1]);
            currentShelfResult = DFS(books, bookPos + 1, shelfHeight, currentWidth + book[0], shelfWidth, dp);
        }
        dp[(bookPos, currentWidth)] = Math.Min(nextShelfResult, currentShelfResult);
        return Math.Min(nextShelfResult, currentShelfResult);
    }
}