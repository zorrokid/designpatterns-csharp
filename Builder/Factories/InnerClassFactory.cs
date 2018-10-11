using System;
using System.Collections.Generic;
using System.Text;

namespace Creational.Factories.InnerClassFactory
{
    public class Point
    {
        private double x;
        private double y;

        // Note: private constructor
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point Origin = new Point(0, 0);

        // Note: static class, cannot be instantiated
        public static class Factory
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
    }
    public class InnerClassFactoryExample
    {
        public static void TestInnerClassFactory()
        {
            var point1 = Point.Factory.NewCartesianPoint(1, 2);
            var point2 = Point.Factory.NewPolarPoint(5, 6);
        }
    }
}
