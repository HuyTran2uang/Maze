using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Maze.DFS
{
    public class MazeGenerator : MonoBehaviour
    {
        [SerializeField] Cell _cellPrefab;
        [SerializeField] int _totalRows, _totalCols;
        Cell[,] _grid;

        private void Start()
        {
            CreateMaze(20, 25);
        }

        public void CreateMaze(int totalRows, int totalCols)
        {
            _totalRows = totalRows;
            _totalCols = totalCols;

            _grid = new Cell[_totalRows, _totalCols];

            for (int row = 0; row < _totalRows; row++)
            {
                for (int col = 0; col < _totalCols; col++)
                {
                    Cell cell = Instantiate(_cellPrefab, transform);
                    cell.transform.position = new Vector3(row, col, 0);
                    _grid[row, col] = cell;
                }
            }

            GenerateMaze(null, _grid[0, 0]);
        }

        void GenerateMaze(Cell prevCell, Cell curCell)
        {
            curCell.Visit();
            ClearWalls(prevCell, curCell);

            Cell nextCell;

            do
            {
                nextCell = GetNextUnVisitedCell(curCell);

                if (nextCell != null)
                {
                    GenerateMaze(curCell, nextCell);
                }
            } while (nextCell != null);
        }

        Cell GetNextUnVisitedCell(Cell curCell)
        {
            var unvisitedCells = GetUnvisitedCells(curCell);
            return unvisitedCells.OrderBy(i => Random.Range(0, 9)).FirstOrDefault();
        }

        IEnumerable<Cell> GetUnvisitedCells(Cell curCell)
        {
            int row = (int)curCell.transform.position.x;
            int col = (int)curCell.transform.position.y;

            if (row + 1 < _totalRows)
            {
                Cell cell = _grid[row + 1, col];

                if (!cell.IsVisited)
                {
                    yield return cell;
                }
            }

            if (row - 1 >= 0)
            {
                Cell cell = _grid[row - 1, col];

                if (!cell.IsVisited)
                {
                    yield return cell;
                }
            }

            if (col + 1 < _totalCols)
            {
                Cell cell = _grid[row, col + 1];

                if (!cell.IsVisited)
                {
                    yield return cell;
                }
            }

            if (col - 1 >= 0)
            {
                Cell cell = _grid[row, col - 1];

                if (!cell.IsVisited)
                {
                    yield return cell;
                }
            }
        }

        void ClearWalls(Cell prevCell, Cell curCell)
        {
            if (prevCell == null) return;
            if (prevCell.transform.position.x < curCell.transform.position.x)
            {
                prevCell.ClearRightWall();
                curCell.ClearLeftWall();
                return;
            }
            if (prevCell.transform.position.x > curCell.transform.position.x)
            {
                prevCell.ClearLeftWall();
                curCell.ClearRightWall();
                return;
            }
            if (prevCell.transform.position.y < curCell.transform.position.y)
            {
                prevCell.ClearTopWall();
                curCell.ClearDownWall();
                return;
            }
            if (prevCell.transform.position.y > curCell.transform.position.y)
            {
                prevCell.ClearDownWall();
                curCell.ClearTopWall();
                return;
            }
        }
    }
}
