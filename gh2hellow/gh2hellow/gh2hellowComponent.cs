using System;
using Grasshopper2.Components;
using Grasshopper2.UI;
using GrasshopperIO;
using Rhino.Geometry;
using MIConvexHull;
using System.Collections.Generic;
using Grasshopper2.Data;
using Grasshopper2.Extensions;
using System.Drawing.Printing;

namespace gh2hellow
{
    [IoId("75ba9513-e713-4489-b60b-6b1808a84981")]
    public sealed class gh2hellowComponent : Component
    {
        public gh2hellowComponent() : base(new Nomen(
            "gh2hellowComponent",
            "Description",
            "Chapter",
            "Section"))
        {

        }

        public gh2hellowComponent(IReader reader) : base(reader) { }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void AddInputs(InputAdder inputs)
        {
           inputs.AddPoint("pointsinput", "ipts", "多个点作为输入",Grasshopper2.Parameters.Access.Twig);
           inputs.AddInteger("随机", "seed", "种子", Grasshopper2.Parameters.Access.Item);
           inputs.AddNumber("起伏", "h", "起伏高度", Grasshopper2.Parameters.Access.Item);




        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void AddOutputs(OutputAdder outputs)
        {
            //outputs.AddPoint("output0", "output0", "output0", Grasshopper2.Parameters.Access.Twig);
            //outputs.AddInteger("output1", "output1", "output1", Grasshopper2.Parameters.Access.Item);
            outputs.AddPoint("output0", "output0", "output0", Grasshopper2.Parameters.Access.Twig);
            outputs.AddLine("output1", "output1", "output1", Grasshopper2.Parameters.Access.Twig);




        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="access">The IDataAccess object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void Process(IDataAccess access)
        {
            access.GetItem<int>(1, out int seed);
            access.GetItem<double>(2, out double hb);

            Random ran = new Random(seed);
            access.GetTwig<Point3d>(0, out var pts);
            var pts1 = new Point3d[pts.LeafCount];
            var ls = new Line[pts.LeafCount];

            for (int i = 0; i < pts.LeafCount; i++)
            {
                Point3d p = pts.ItemAt(i);
                Point3d p1 = new Point3d(p.X, p.Y, p.Z + hb*ran.NextDouble());
                pts1[i] = p1;
                ls[i] = new Line(p,p1);
            }

            access.SetTwig<Point3d>(0,pts1);
            access.SetTwig<Line>(1,ls);



        }

    }
}
