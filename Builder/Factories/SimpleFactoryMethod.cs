using System;
using System.Collections.Generic;
using System.Text;

namespace Creational.Factories
{
    public class Point
    {
        private double x;
        private double y;

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        
        // Note: private constructor
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class SimpleFactoryMethod
    {
        public static void TestSimpleFactoryMethod()
        {
            var point1 = Point.NewCartesianPoint(1, 2);
            var point2 = Point.NewPolarPoint(5, 6);
        }
    }
}
