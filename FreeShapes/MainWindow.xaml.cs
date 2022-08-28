using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/* Requirements (Due Tuesday, August 30th, 2022 at 11:59 PM.):
 * [] 1. Open an image file within your application.
 * [] 2. Draw a free shape over the image using mouse clicks.
 * [] 3. Change the free shape by moving its different edges (connections between lines).
 * [] 4. Change the color of the shape by clicking on it and selecting a different color from a color palette.
 * [] 5. Drag/drop the shape to change its location.
 * [] 6. Select the shape and be able to delete it.
 * [] 7. Save the image file.
 * [] The user can open the image using your application and update the shapes that were drawn in a previous session.
 * [] Add error handling
 * 
 * So what do I do first?
 * 1. Be able to draw objects on the window
 * 2. Make myLine, node, shape objects
 * 3. A node object draws the circle
 * 3. extend a line object to each of the nodes
 * 
 * >>> 4. Make Shape Object <<<
 * 
 * So basically I need to make a shape object that keeps track of the placement of all the nodes.
 * When the user clicks on a pre-existing node of an uncomplete shape, it completes the shape
 * > objects: lines, nodes, shapes
 * > shape objects keeps track of the lines and nodes
 * 
 * So I start with 1 shape object, it collects the nodes & makes the lines. Once a shape object is
 * completed, I then instantiate another shape object. Maybe have an array of shape objects?
 * I will also need a method to track where the mouse is in respect to the shapes, etc.
 * 
 * 
 * 
 */

namespace FreeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // this MainWindow class is inherting Window class from "using System.Windows"
    public partial class MainWindow : Window
    {
        public int debugCtr = 0;    // for sillyDebug method
        Shape[] shapeArr = new Shape[100]; // should use dynamic array, but for this example I will keep it simple
        int currShapeInd;
        public MainWindow()
        {
            InitializeComponent();
            
            currShapeInd = 0;
            Shape shape =  new Shape();
            shapeArr[0] = shape;

        }

        private void drawingArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sillyDebug();
            Point p = Mouse.GetPosition(drawingArea);
            // I need to check if position is close to other nodes
            // if close to node, finish shape and start new shape
            // else continue placing nodes for same shape
            // So that means I need to keep track of the positions of all the nodes in a shape
            // a node will have a x,y position. So if 3pixels close by, join & finish shape

            // -5 to align to tip of cursor
            //shapeArr[0].AddNodeToShape((double)p.X - 6, (double)p.Y - 6);
            shapeArr[0].CheckProximityToNode((double)p.X - 6, (double)p.Y - 6);
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            // coordinates of mouse icon will keep changing until user clicks the mouse again

        }

        public void makeLine(double x1, double y1, double x2, double y2)
        {
            Line line = new Line();
            //line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 1;
            line.Stroke = System.Windows.Media.Brushes.Black;
            line.X1 = x1 + 6;
            line.Y1 = y1 + 6;
            line.X2 = x2 + 6;
            line.Y2 = y2 + 6;
            drawingArea.Children.Add(line);
        }

        private void sillyDebug()
        {
            if (debugCtr == 0)
            {
                debugMsg.Text = " click!";
                debugCtr = 1;
            }
            else
            {
                debugMsg.Text = " clack!";
                debugCtr = 0;
            }
            
        }
    }
}


/* References:
 * https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview
 * Stack Overflow
 * Google.com :D ... Core tool of all Software Devs
 * https://www.tutorialspoint.com/wpf/wpf_mouse.htm
 * 
 */