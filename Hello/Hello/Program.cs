using System;
using Hello;
namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            double [,] matt1 ={ {1,3},{2,7} };
            double[,] matt2 = { { 1, 0 }, { 0, 1 } };

            Matrix<double> mat1 = new Matrix<double>(2, 2, matt1);
            Matrix<double> mat2 = new Matrix<double>(2, 2, matt2);
            Matrix<double> matin = mat1.MatrixInvert();
            Console.WriteLine("Matrix invers:\n");
            matin.PrintMatrix();

            mat1.MatrixRowOperation(1, 0, -2);
            mat2.MatrixRowOperation(1, 0, -2);

            mat1.MatrixRowOperation(0, 1, -3);
            mat2.MatrixRowOperation(0, 1, -3);

            Console.WriteLine("\n\nMatrix invers:\n");
            mat2.PrintMatrix();
        }
    }
}
