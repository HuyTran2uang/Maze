using System.Collections.Generic;
using System.Linq;

namespace Maze.Graph
{
    public class Node
    {
        public Node[] neighbourNodes;

        public Node()
        {
            neighbourNodes = new Node[4] { null, null, null, null };
        }

        public bool IsExistWall() => neighbourNodes.ToList().Where(i => i == null).Count() > 0;

        public void SetRandomWallUnDoor(Node node)
        {
            List<Node> walls = neighbourNodes.ToList().Where(i => i == null).ToList();
            int selectedIndexWall = UnityEngine.Random.Range(0, walls.Count);
            Node selectedNode = walls[selectedIndexWall];
            SetWall(node, selectedIndexWall);
            node.SetWall(this, 3 - selectedIndexWall);//3 is max index of walls
        }

        public void SetWall(Node neighbourNode, int indexWall)
        {
            neighbourNodes[indexWall] = neighbourNode;
        }
    }
}
