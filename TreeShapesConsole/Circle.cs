using System;
namespace Tree
{
    public class Circle : Shape
    {
        public override ShapeType GetShapeType()
        {
            return ShapeType.CIRCLE;
        }
        public override string ToString() { return  Color.Name.ToString()+"Circle"; }

    }
}