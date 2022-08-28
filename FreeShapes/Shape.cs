using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShapes
{
    internal class Shape
    {
        // I need to keep track of the current node & new node to make lines
        // class var
        private Node? currentNode; // I should probably make get/setters for these
        private Node? firstNode;
        // a shape should probably have a list of nodes...
        private List<Node> nodes;


        // constructor
        public Shape()
        {
            currentNode = null;
            firstNode = null;
            nodes = new List<Node>();
        }

        public void AddNodeToShape(double x2, double y2)
        {
            Node newNode = new Node(x2, y2);
            nodes.Add(newNode);
            // if shape has no nodes then firstNode & currentNode are same
            if (firstNode == null)
            {
                firstNode = newNode;
                currentNode = newNode;
            } // if shape has only 1 node then 
            //else if (firstNode == currentNode)
            else
            {
                // get cord of currentNode, update currentNode to be newNode
                double x1 = currentNode.X_cord;
                double y1 = currentNode.Y_cord;
                // draw line between between currentNode & newNode
                ((MainWindow)System.Windows.Application.Current.MainWindow).makeLine(x1, y1, x2, y2);
                currentNode = newNode;
            }
        }

        // Check if mouse cursor is close by firstNode to complete the shape
        // if false, AddNodeToShape
        // if true, FinishShape
        public void CheckProximityToNode(double x, double y)
        {
            // check if there is no node
            // check if there is only 1 node
            // combine conditions: AddNodeToShape if there is less than 2 nodes
            if (nodes.Count < 2) {
                AddNodeToShape(x, y);
                return;
            }

            // check if x,y coordinates are close to firstNode
            double minX = firstNode.X_cord - 10;
            double maxX = firstNode.X_cord + 10;
            double minY = firstNode.Y_cord - 10;
            double maxY = firstNode.Y_cord + 10;

            if ((minX < x && x < maxX) && (minY < y && y < maxY))
            {
                FinishShape(firstNode, currentNode);
            }
            else
            {
                AddNodeToShape(x, y);
            }
        }

        public void FinishShape(Node firstNode, Node lastNode)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).makeLine
                (currentNode.X_cord, currentNode.Y_cord, firstNode.X_cord, firstNode.Y_cord);
        }
    }
}
