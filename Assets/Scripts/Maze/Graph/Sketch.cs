using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze.Graph
{
    public class Sketch : MonoBehaviourSingleton<Sketch>
    {
        [SerializeField] Cell cellPrefab;

        public void ShowMaze(int width, int height, Node[,] nodeGrid)
        {
            Vector3 curPos = Vector3.zero;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = Instantiate(cellPrefab, transform);

                    cell.transform.position = curPos;
                    curPos.x += 1;
                }
                curPos.y += 1;
                curPos.x = 0;
            }
        }
    }
}
