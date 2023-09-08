using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze.DFS
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] GameObject _topWall, _rightWall, _downWall, _leftWall;
        [SerializeField] SpriteRenderer _floorSR;

        public bool IsVisited { get; private set; }

        public void Visit()
        {
            IsVisited = true;
            _floorSR.color = new Color32(255, 0, 0, 255);
        }

        public void ClearTopWall()
        {
            _topWall.SetActive(false);
        }

        public void ClearRightWall()
        {
            _rightWall.SetActive(false);
        }

        public void ClearDownWall()
        {
            _downWall.SetActive(false);
        }

        public void ClearLeftWall()
        {
            _leftWall.SetActive(false);
        }
    }
}

