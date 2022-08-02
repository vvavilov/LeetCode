/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

class Solution {
    private HashSet<(int y, int x)> visited = new(); 
    
    public void CleanRoom(Robot robot) {
        Backtrack(robot, (0, 0), Direction.Top);
    }
    
    private void Backtrack(Robot robot, (int y, int x) coord, Direction dir) {
        robot.Clean();
        visited.Add(coord);
        
        for(int i = 0; i < 4; i++) {
            var nextCoord = NextCoord(coord.y, coord.x, dir);

            if(!visited.Contains(nextCoord)) {
                if(robot.Move()) {
                    Backtrack(robot, nextCoord, dir);
                    MoveBack(robot);
                }
            }
            
            robot.TurnRight();
            dir = NextDirection(dir);
        };
    }
    
    private void MoveBack(Robot robot) {
        robot.TurnLeft();
        robot.TurnLeft();
        robot.Move();
        robot.TurnLeft();
        robot.TurnLeft();
    }
    
    private (int y, int x) NextCoord(int y, int x, Direction direction) {
        return direction switch {
            Direction.Top => (y + 1, x),
            Direction.Right => (y, x + 1),
            Direction.Down => (y - 1, x),
            Direction.Left => (y, x - 1),
            _ => throw new Exception("unknown direction")
        };
    }
    
    private Direction NextDirection(Direction direction) {
        return direction switch {
            Direction.Top => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Top,
            _ => throw new Exception("unknown direction")
        };
    }
}

public enum Direction {
    Top,
    Down,
    Left,
    Right
}