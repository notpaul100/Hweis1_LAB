using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace Hweis1_LAB3
{
    public partial class Form1 : Form
    {
        private const int _width = 1000;
        private const int _height = 1000;
        static CDrawer _canvas = new CDrawer(_width, _height, true);
        List<Shape> _shapes = new List<Shape>();
        Fungus Fung;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UI_btnStart_Click(object sender, EventArgs e)
        {
            UI_btnStart.Enabled = false;
            Fung = new Fungus(new Point(_width / 2, _height / 2), _canvas, Color.Red);
            Fung = new Fungus(new Point(_width / 2, _height / 2), _canvas, Color.Blue);
            Fung = new Fungus(new Point(_width / 2, _height / 2), _canvas, Color.Green);


            // center solid anchors
            _shapes.Add(new FixedSquare(new Point(450, 500), Color.Red, null));
            _shapes.Add(new FixedSquare(new Point(550, 500), Color.Red, _shapes[0]));

            _shapes.Add(new AniPoly(new PointF(100, 300), Color.Tomato, 3, null, 0.1));
            _shapes.Add(new AniPoly(new PointF(135, 300), Color.Tomato, 3, null, -0.1, 1));
            _shapes.Add(new AniPoly(new PointF(170, 300), Color.Tomato, 3, null, 0.1));

            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(800, 300), Color.LightCoral, null));
                local.Add(new AniHighlight(Color.Yellow, 30, local[0], -0.2));
                _shapes.AddRange(local);
            }
            // ccw orbit chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new OrbitBall(Color.Yellow, 50, _shapes[0], -0.1, Math.PI));
                local.Add(new OrbitBall(Color.Pink, 50, local[0], -0.15, Math.PI));
                local.Add(new OrbitBall(Color.Blue, 50, local[1], -0.2, Math.PI));
                local.Add(new OrbitBall(Color.Green, 50, local[2], -0.25, Math.PI));
                _shapes.AddRange(local);
            }
            // cw orbit chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new OrbitBall(Color.Yellow, 50, _shapes[1], 0.05));
                local.Add(new OrbitBall(Color.Pink, 50, local[0], 0.075));
                local.Add(new OrbitBall(Color.Blue, 50, local[1], 0.1));
                local.Add(new OrbitBall(Color.Green, 50, local[2], 0.125));
                _shapes.AddRange(local);
            }
            // show 3-tier cloud of quad balls orbiting the same block
            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(800, 500), Color.GreenYellow, null));
                local.Add(new OrbitBall(Color.Yellow, 30, local[0], 0.1, 0));
                local.Add(new OrbitBall(Color.Yellow, 30, local[0], 0.1, Math.PI / 2));
                local.Add(new OrbitBall(Color.Yellow, 30, local[0], 0.1, Math.PI));
                local.Add(new OrbitBall(Color.Yellow, 30, local[0], 0.1, 3 * Math.PI / 2));
                local.Add(new OrbitBall(Color.Yellow, 60, local[0], -0.05, 0));
                local.Add(new OrbitBall(Color.Yellow, 60, local[0], -0.05, Math.PI / 2));
                local.Add(new OrbitBall(Color.Yellow, 60, local[0], -0.05, 3 * Math.PI));
                local.Add(new OrbitBall(Color.Yellow, 60, local[0], -0.05, 3 * Math.PI / 2));
                local.Add(new OrbitBall(Color.Yellow, 90, local[0], 0.025, 0));
                local.Add(new OrbitBall(Color.Yellow, 90, local[0], 0.025, Math.PI / 2));
                local.Add(new OrbitBall(Color.Yellow, 90, local[0], 0.025, Math.PI));
                local.Add(new OrbitBall(Color.Yellow, 90, local[0], 0.025, 3 * Math.PI / 2));
                _shapes.AddRange(local);
            }

            // show the top row of solid blocks with incremental offset animated vwballs
            {
                List<Shape> localA = new List<Shape>();
                List<Shape> localB = new List<Shape>();
                for (int i = 50; i < 1000; i += 50)
                    localA.Add(new FixedSquare(new PointF(i, 100), Color.Cyan, null));
                _shapes.AddRange(localA);
                double so = 0;
                foreach (Shape s in localA)
                    localB.Add(new VWobbleBall(Color.Purple, 50, s, 0.1, so += 0.7));
                _shapes.AddRange(localB);
            }

            // fixed/double h/v wobble + orbit chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(200, 500), Color.Cyan, null));
                local.Add(new VWobbleBall(Color.Red, 100, local[0], 0.1));
                local.Add(new HWobbleBall(Color.Red, 100, local[1], 0.15));
                local.Add(new OrbitBall(Color.LightBlue, 25, local[2], 0.2));
                _shapes.AddRange(local);
            }

            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(500, 200), Color.Wheat, null));
                for (int i = 1; i < 20; ++i)
                    local.Add(new HWobbleBall(Color.Orange, 25, local[i - 1], 0.1));
                _shapes.AddRange(local);
            }




            foreach (Shape shape in _shapes)
            {

                if (shape is FixedSquare square)
                    square.Render(_canvas);
                if (shape is AniShape Ball)
                    Ball.Render(_canvas);
            }
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape is AniPoly Poly)
                    Poly.Tick();
                if (shape is AniHighlight Light)
                    Light.Tick();
                if (shape is OrbitBall Orb)
                    Orb.Tick();
                if (shape is VWobbleBall Vwob)
                    Vwob.Tick();
                if (shape is HWobbleBall Hwob)
                    Hwob.Tick();
            }
            _canvas.Clear();
            foreach (Shape shape in _shapes)
            {
                
                if (shape is FixedSquare square)
                    square.Render(_canvas);
                if (shape is AniShape Ball)
                    Ball.Render(_canvas);
            }
        }
    }
}
