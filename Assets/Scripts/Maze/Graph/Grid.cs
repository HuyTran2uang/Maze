using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze.Graph
{
    public struct Grid
    {
        Node mazeCeneter;

        public void CreateRandomMaze()
        {
            mazeCeneter = new Node();
            int countNode = 20;
            Node current = mazeCeneter;
            while (countNode > 0)
            {
                Node next = new Node();
                current.SetRandomWallUnDoor(next);
                current = next;
                countNode--;
            }
        }
    }
}