using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze.Graph
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] GameObject top, left, right, down;
    }
}