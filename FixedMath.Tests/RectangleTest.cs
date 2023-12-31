﻿namespace FixedMath
{
    class RectangleTest
    {
        [Test]
        public void ConstructorsAndProperties()
        {
            var rectangle = new FixedRectangle(10, 20, 64, 64);

            // Constructor

            Assert.AreEqual(new FixedRectangle(){X = 10, Y = 20, Width = 64, Height = 64}, rectangle);

            // Constructor 2

            Assert.AreEqual(new FixedRectangle() { X = 1, Y = 2, Width = 4, Height = 45 }, new FixedRectangle(new FixedPoint(1, 2), new FixedPoint(4, 45)));

            // Left property

            Assert.AreEqual(10, rectangle.Left);

            // Right property

            Assert.AreEqual(64 + 10, rectangle.Right);

            // Top property

            Assert.AreEqual(20, rectangle.Top);

            // Bottom property

            Assert.AreEqual(64 + 20, rectangle.Bottom);

            // Location property

            Assert.AreEqual(new FixedPoint(10, 20), rectangle.Location);

            // Center property

            Assert.AreEqual(new FixedPoint(10+32,20+32), rectangle.Center);


            // Size property

            Assert.AreEqual(new FixedPoint(64,64), rectangle.Size);


            // IsEmpty property

            Assert.AreEqual(false, rectangle.IsEmpty);
            Assert.AreEqual(true, new FixedRectangle().IsEmpty);

            // Empty - static property

            Assert.AreEqual(new FixedRectangle(),FixedRectangle.Empty);
        }

        [Test]
        public void ContainsPoint()
        {
            FixedRectangle rectangle = new FixedRectangle(0,0,64,64);

            var p1 = new FixedPoint(-1, -1);
            var p2 = new FixedPoint(0, 0);
            var p3 = new FixedPoint(32, 32);
            var p4 = new FixedPoint(63, 63);
            var p5 = new FixedPoint(64, 64);

            bool result;

            rectangle.Contains(ref p1, out result);
            Assert.AreEqual(false, result);
            rectangle.Contains(ref p2, out result);
            Assert.AreEqual(true, result);
            rectangle.Contains(ref p3, out result);
            Assert.AreEqual(true, result);
            rectangle.Contains(ref p4, out result);
            Assert.AreEqual(true, result);
            rectangle.Contains(ref p5, out result);
            Assert.AreEqual(false, result);

            Assert.AreEqual(false, rectangle.Contains(p1));
            Assert.AreEqual(true, rectangle.Contains(p2));
            Assert.AreEqual(true, rectangle.Contains(p3));
            Assert.AreEqual(true, rectangle.Contains(p4));
            Assert.AreEqual(false, rectangle.Contains(p5));
        }

        [Test]
        public void ContainsVector2()
        {
            FixedRectangle rectangle = new FixedRectangle(0, 0, 64, 64);

            var p1 = new FixedVector2(-1, -1);
            var p2 = new FixedVector2(0, 0);
            var p3 = new FixedVector2(32, 32);
            var p4 = new FixedVector2(63, 63);
            var p5 = new FixedVector2(64, 64);

            bool result;

            rectangle.Contains(ref p1, out result);
            Assert.AreEqual(false, result);
            rectangle.Contains(ref p2, out result);
            Assert.AreEqual(true, result);
            rectangle.Contains(ref p3, out result);
            Assert.AreEqual(true, result);
            rectangle.Contains(ref p4, out result);
            Assert.AreEqual(true, result);
            rectangle.Contains(ref p5, out result);
            Assert.AreEqual(false, result);

            Assert.AreEqual(false, rectangle.Contains(p1));
            Assert.AreEqual(true, rectangle.Contains(p2));
            Assert.AreEqual(true, rectangle.Contains(p3));
            Assert.AreEqual(true, rectangle.Contains(p4));
            Assert.AreEqual(false, rectangle.Contains(p5));
        }

        [Test]
        public void ContainsInts()
        {
            FixedRectangle rectangle = new FixedRectangle(0, 0, 64, 64);

            int x1 = -1; int y1 = -1;
            int x2 = 0;  int y2 = 0;
            int x3 = 32; int y3 = 32;
            int x4 = 63; int y4 = 63;
            int x5 = 64; int y5 = 64;

            Assert.AreEqual(false, rectangle.Contains(x1,y1));
            Assert.AreEqual(true, rectangle.Contains(x2,y2));
            Assert.AreEqual(true, rectangle.Contains(x3,y3));
            Assert.AreEqual(true, rectangle.Contains(x4,y4));
            Assert.AreEqual(false, rectangle.Contains(x5,y5));
        }

        [Test]
        public void ContainsFloats()
        {
            FixedRectangle rectangle = new FixedRectangle(0, 0, 64, 64);

            float x1 = -1; float y1 = -1;
            float x2 = 0;  float y2 = 0;
            float x3 = 32; float y3 = 32;
            float x4 = 63; float y4 = 63;
            float x5 = 64; float y5 = 64;

            Assert.AreEqual(false, rectangle.Contains((Fixed)x1, (Fixed)y1));
            Assert.AreEqual(true, rectangle.Contains((Fixed)x2, (Fixed)y2));
            Assert.AreEqual(true, rectangle.Contains((Fixed)x3, (Fixed)y3));
            Assert.AreEqual(true, rectangle.Contains((Fixed)x4, (Fixed)y4));
            Assert.AreEqual(false, rectangle.Contains((Fixed)x5, (Fixed)y5));
        }

        [Test]
        public void ContainsRectangle()
        {
            var rectangle = new FixedRectangle(0, 0, 64, 64);
            var rect1 = new FixedRectangle(-1, -1, 32, 32);
            var rect2 = new FixedRectangle(0, 0, 32, 32);
            var rect3 = new FixedRectangle(0, 0, 64, 64);
            var rect4 = new FixedRectangle(1, 1, 64, 64);

            bool result;

            rectangle.Contains(ref rect1, out result);

            Assert.AreEqual(false, result);

            rectangle.Contains(ref rect2, out result);

            Assert.AreEqual(true, result);

            rectangle.Contains(ref rect3, out result);

            Assert.AreEqual(true, result);

            rectangle.Contains(ref rect4, out result);

            Assert.AreEqual(false, result);

            Assert.AreEqual(false, rectangle.Contains(rect1));
            Assert.AreEqual(true, rectangle.Contains(rect2));
            Assert.AreEqual(true, rectangle.Contains(rect3));
            Assert.AreEqual(false, rectangle.Contains(rect4));
        }

        [Test]
        public void Inflate()
        {
            FixedRectangle rectangle = new FixedRectangle(0,0,64,64);
            rectangle.Inflate(10,-10);
            Assert.AreEqual(new FixedRectangle(-10, 10, 84, 44),rectangle);

            FixedRectangle rectangleF = new FixedRectangle(0, 0, 64, 64);
            rectangleF.Inflate((Fixed)10.0f, (Fixed)(-10.0f));
            Assert.AreEqual(new FixedRectangle(-10, 10, 84, 44), rectangleF);

        }

        [Test]
        public void Intersect()
        {
            var first = new FixedRectangle(0, 0, 64, 64);
            var second = new FixedRectangle(-32, -32, 64, 64);
            var expected = new FixedRectangle(0, 0, 32, 32);

            // First overload testing(forward and backward)

            FixedRectangle result;
            FixedRectangle.Intersect(ref first, ref second, out result);

            Assert.AreEqual(expected, result);

            FixedRectangle.Intersect(ref second, ref first, out result);

            Assert.AreEqual(expected, result);

            // Second overload testing(forward and backward)

            Assert.AreEqual(expected, FixedRectangle.Intersect(first, second));
            Assert.AreEqual(expected, FixedRectangle.Intersect(second, first));
        }

        [Test]
        public void Union()
        {
            var first = new FixedRectangle(-64, -64, 64, 64);
            var second = new FixedRectangle(0, 0, 64, 64);
            var expected = new FixedRectangle(-64, -64, 128, 128);

            // First overload testing(forward and backward)

            FixedRectangle result;
            FixedRectangle.Union(ref first, ref second, out result);

            Assert.AreEqual(expected, result);

            FixedRectangle.Union(ref second, ref first, out result);

            Assert.AreEqual(expected, result);

            // Second overload testing(forward and backward)

            Assert.AreEqual(expected, FixedRectangle.Union(first, second));
            Assert.AreEqual(expected, FixedRectangle.Union(second, first));
        }

        [Test]
        public void ToStringTest()
        {
            StringAssert.IsMatch("{X:-10 Y:10 Width:100 Height:1000}",new FixedRectangle(-10,10,100,1000).ToString());
        }


        [Test]
        public void Deconstruct()
        {
            FixedRectangle rectangle = new FixedRectangle(int.MinValue, int.MaxValue, int.MinValue, int.MaxValue);

            int x, y, width, height;

            rectangle.Deconstruct(out x, out y, out width, out height);

            Assert.AreEqual(x, rectangle.X);
            Assert.AreEqual(y, rectangle.Y);
            Assert.AreEqual(width, rectangle.Width);
            Assert.AreEqual(height, rectangle.Height);
        }

    }
}
