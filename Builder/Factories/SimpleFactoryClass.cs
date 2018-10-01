using System;
using System.Collections.Generic;
using System.Text;

namespace Creational.Factories.SimpleClassFactory
{
    // NOte: static class, no object can be instantiated of this class
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class SimpleFactoryClassExample
    {
        public static void TestSimpleFactoryMethod()
        {
            var point1 = PointFactory.NewCartesianPoint(1, 2);
            var point2 = PointFactory.NewPolarPoint(5, 6);
        }
    }
}
