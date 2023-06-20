using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using GDIDrawer;

namespace Hweis1_LAB3
{
    class Fungus
    {
        static Random _rnd = new Random();
        Thread T;
        public Point _currentPoint;
        Dictionary<Point, int> _Fun = new Dictionary<Point, int>();
        CDrawer _canvas;
        Color _color;
        public Fungus(Point _start, CDrawer canvas, Color _c)
        {
           _currentPoint = _start;
            _canvas = canvas;
            _color = _c;
            T = new Thread(new ThreadStart(processing));
            T.Start();
        }
        private void processing()
        {
            while (true)
            {
                List<Point> possiblePoints = new List<Point>();
                possiblePoints = surrounding(_currentPoint);
                possiblePoints = Shuffle(possiblePoints);
                Dictionary<Point, int> _tempFun = new Dictionary<Point, int>();
                lock (_tempFun)
                {
                    foreach (Point p in possiblePoints)
                    {
                        if (_Fun.Keys.Contains(p))
                            _tempFun[p] = _Fun[p];
                        else
                            _tempFun[p] = 0;
                    }
                }
                _tempFun = _tempFun.OrderBy(o => o.Value).ToDictionary(o => o.Key, o => o.Value);
                _currentPoint = _tempFun.First().Key;
                lock (_Fun)
                {
                    if (_Fun.ContainsKey(_currentPoint))
                    {
                        if (_Fun[_currentPoint] + 16 > 255)
                            _Fun[_currentPoint] = 255;
                        else
                        _Fun[_currentPoint] += 16;
                    }
                    else
                    {
                        _Fun[_currentPoint] = 32;
                    }
                }
                lock (_canvas)
                {
                    Color _pixel = _canvas.GetBBPixel(_currentPoint.X, _currentPoint.Y);

                    if (_color.Equals(Color.Blue))
                        _canvas.SetBBPixel(_currentPoint.X, _currentPoint.Y,
                            Color.FromArgb(_pixel.R, _pixel.G, _Fun[_currentPoint]));
                    if (_color.Equals(Color.Red))
                        _canvas.SetBBPixel(_currentPoint.X, _currentPoint.Y,
                        Color.FromArgb(_Fun[_currentPoint], _pixel.G, _pixel.B));
                    if (_color.Equals(Color.Green))
                        _canvas.SetBBPixel(_currentPoint.X, _currentPoint.Y,
                        Color.FromArgb(_pixel.R, _Fun[_currentPoint], _pixel.B));
                }
                _canvas.Render();
                Thread.Sleep(0);
            }
        }

        private List<Point> surrounding(Point current)
        {
            List<Point> surr = new List<Point>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if(!(x.Equals(0) && y.Equals(0)))
                    {
                        if(_currentPoint.X+x > 0 && _currentPoint.Y+y > 0 && _currentPoint.X+x < 1000 && _currentPoint.Y+y < 1000)
                        surr.Add(new Point(_currentPoint.X+x, _currentPoint.Y+y));
                    }
                }
            }
            return surr;
        }
        
        private List<Point> Shuffle(List<Point> Points)
        {
            List<Point> newPoints = new List<Point>();
            int index;
            for (int i = 0; i < Points.Count; i++)
            {
                newPoints.Add(new Point());
                lock(_rnd)
                index = _rnd.Next(0, newPoints.Count());
                if (index.Equals(newPoints.Count))
                {
                    newPoints[Points.Count] = Points[i];
                }
                else
                {
                    newPoints[i] = newPoints[index];
                    newPoints[index] = Points[i];
                }
            }

            return newPoints;
        }
    }
}
