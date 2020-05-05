using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public interface IShapeFactory
    {
        Shape GetShape(ShapeData shapeFactoryArg);
    }
}