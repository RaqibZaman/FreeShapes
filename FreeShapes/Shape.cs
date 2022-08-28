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

        // constructor
        public Shape()
        {
            currentNode = null;
            firstNode = null;
        }

        // I'll return coordinates for making a line
        // 
        public void addNode(Node newNode)
        {
            double x2 = newNode.X_cord;
            double y2 = newNode.Y_cord;
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
                ((MainWindow)System.Windows.Application.Current.MainWindow).makeLine(x1,y1,x2,y2);
                currentNode = newNode;
            }
        }

    }
}
