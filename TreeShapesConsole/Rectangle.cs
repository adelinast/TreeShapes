using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public class Rectangle : Shape
    {

        public override ShapeType GetShapeType()
        {
            return ShapeType.RECTANGLE;
        }

        public override string ToString() { return Color.Name.ToString() + "Rectangle"; }

    }
}