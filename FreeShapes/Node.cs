using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FreeShapes
{
    // I know I should use MVVM- and I would in a real project when I have more time to research C#
    // But for now this is a temporary solution
    internal class Node
    {
        // class var
        private double x_cord;
        private double y_cord;
        private Ellipse node;
        // for this freeshape project, a node has at most 2 lines
        // for a shape object, it can tell that it is completed when 
        // of its nodes have 2 lines
        private object line1 = null;   
        private object line2 = null;

        // constructor(s)
        public Node(double x, double y)
        {
            X_cord = x;
            Y_cord = y;
            node = makeCircle(x, y);
        }
        
        
        public Node(double x, double y, Ellipse circle)
        {
            X_cord = x;
            Y_cord = y;
            node = circle;
        }

        // properties
        public double X_cord 
        { 
            get { return x_cord; }
            set { x_cord = value; } // need to change circle's position
        }

        public double Y_cord
        {
            get { return y_cord; }
            set { y_cord = value; } // need to change circle's position
        }
        
        // methods
        private Ellipse makeCircle(double x, double y)
        {
            Ellipse circle = new Ellipse()
            {
                Width = 11,
                Height = 11,
                Stroke = Brushes.SteelBlue,
                StrokeThickness = 6,
            };

            circle.SetValue(Canvas.LeftProperty, x);
            circle.SetValue(Canvas.TopProperty, y);
            ((MainWindow)System.Windows.Application.Current.MainWindow).drawingArea.Children.Add(circle);
            return circle;
        }

    }
}
