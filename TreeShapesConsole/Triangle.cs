using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tree
{
    public class Triangle : Shape
    {

        public override ShapeType GetShapeType()
        {
            return ShapeType.TRIANGLE;
        }

        public override string ToString() { return Color.Name.ToString() + "Triangle"; }
    }
}