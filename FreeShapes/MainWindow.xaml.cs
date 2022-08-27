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
 * 2. Make node objects
 * 3. Make line objects
 * 
 */

namespace FreeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            makeLine();
            makeCircle(50, 50);
            makeCircle(150, 150);
            makeCircle(250, 250);
        }

        private void drawingArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // I need coordinates of mouse icon during mouse click

        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            // coordinates of mouse icon will keep changing until user clicks the mouse again

        }

        private void makeLine()
        {
            Line line = new Line();
            Thickness thickness = new Thickness(101, -11, 362, 250);
            line.Margin = thickness;
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 4;
            line.Stroke = System.Windows.Media.Brushes.Black;
            line.X1 = 10;
            line.X2 = 40;
            line.Y1 = 70;
            line.Y2 = 70;
            drawingArea.Children.Add(line);
        }

        private void makeCircle(double x, double y)
        {
            Ellipse circle = new Ellipse()
            {
                Width = 11,
                Height = 11,
                Stroke = Brushes.SteelBlue,
                StrokeThickness = 6,
            };

            drawingArea.Children.Add(circle);

            circle.SetValue(Canvas.LeftProperty, x);
            circle.SetValue(Canvas.TopProperty, y); 


        }
    }
}


/* References:
 * https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview
 * 
 */