using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Matrix<T>
    {
        public T[,] map;
        public int indexRow;
        public int indexColumn;
        public bool isSquare;
        public T value;
        public Matrix(int n, int m, T[,] mat) {
            this.map = mat;
            this.indexColumn = m;
            this.indexRow = n;
            if (n == m)
            {
                this.isSquare = true;
                this.value = this.MatrixDetermine(this.indexRow, this.map);
            }
            else
            {
                this.isSquare = false;
            }
        }
        public void PrintMatrix() {
            for (int indexRow = 0; indexRow<this.indexRow; indexRow++){
                for (int indexColumn = 0; indexColumn < this.indexColumn; indexColumn++) {
                    dynamic a = this.map[indexRow, indexColumn];
                    double b = (double)a;
                    Math.Round(b, 2);
                    if (-0.00000005<b &&b < 0.0000000005) {
                        b = 0;
                    }
                    else if(0.9999<b && b<=1)
                        b = 1;
                    Console.Write(b+ " ");
                }
                Console.WriteLine("");
            }
        }

        public Matrix<T> MatrixMultiplication(Matrix<T> mat)
        {
            T[,] matmul;
            if (mat.indexRow != this.indexColumn)
            {
                return null;
            }
            matmul = new T[this.indexRow, mat.indexColumn];
            for (int i = 0; i < this.indexRow; i++)
            {
                for (int j = 0; j < mat.indexColumn; j++)
                {
                    dynamic sum = 0;
                    for (int k = 0; k < this.indexColumn; k++)
                    {
                        dynamic a = this.map[i, k];
                        dynamic b = mat.map[k, j];
                        sum = sum + (a * b);
                    }
                    matmul[i, j] = sum;
                }
            }
            return new Matrix<T>(this.indexRow, mat.indexColumn, matmul);
        }
        public Matrix<T> MatrixSumation(Matrix<T> mat) {
            if ((this.indexColumn != mat.indexColumn) && (this.indexRow != mat.indexRow)) {
                return null;
            }
            T[,] summat;
            summat = new T[this.indexRow, mat.indexColumn];
            for (int i = 0; i < this.indexRow; i++) {
                for (int j = 0; i <this.indexColumn;j++) {
                    dynamic a = this.map[i, j];
                    dynamic b = mat.map[i, j];
                    summat[i, j] = a + b;
                }
            }
            return new Matrix<T>(this.indexRow, this.indexColumn,summat);
        }
        public Matrix<T> MatrixSubtraction(Matrix<T> mat) {
            if ((this.indexColumn != mat.indexColumn) && (this.indexRow != mat.indexRow))
            {
                return null;
            }
            T[,] submat;
            submat = new T[this.indexRow, mat.indexColumn];
            for (int i = 0; i < this.indexRow; i++)
            {
                for (int j = 0; i < this.indexColumn; j++)
                {
                    dynamic a = this.map[i, j];
                    dynamic b = mat.map[i, j];
                    submat[i, j] = a - b;
                }
            }
            return new Matrix<T>(this.indexRow, this.indexColumn, submat);
        }
        public Matrix<T> MatrixTranspos()
        {
            T[,] mat = new T[this.indexColumn, this.indexRow];
            for (int i = 0; i < this.indexRow; i++)
            {
                for (int j = 0; j < this.indexColumn; j++)
                {
                    mat[j, i] = this.map[i, j];
                }
            }
            return new Matrix<T>(this.indexColumn, this.indexRow, mat);
        }
        public void MatrixRowOperation(int r1, int r2, T theta) {
            for (int j = 0; j < this.indexColumn; j++) {
                dynamic a = this.map[r1, j];
                dynamic b = this.map[r2, j];
                dynamic theta1 = theta;
                this.map[r1, j] = (T)(a + (b*theta1));
            }
        }
        public void MatrixColumnOperation(int c1, int c2, T theta)
        {
            for (int j = 0; j < this.indexRow; j++)
            {
                dynamic a = this.map[j,c1];
                dynamic b = this.map[j,c2];
                dynamic theta1 = theta;
                this.map[j,c1] = (T)(a + (b * theta1));
            }
        }

        public Matrix<T> MatrixConstantMultiplication(T value) {
            dynamic V = value;
            T[,] mat = new T[this.indexRow, this.indexColumn];
            for (int i = 0; i < this.indexRow; i++)
                for (int j = 0; j < this.indexColumn; j++)
                {
                    dynamic a = this.map[i, j];
                    mat[i,j] = (T)(a * V);
                }
            return new Matrix<T>(this.indexRow, this.indexColumn,mat);
        }
        
        public T getDet()
        {
            return this.value;
        }
        public Matrix<T> MatrixAdjoint() {
            dynamic a = this.value;
            if (!this.isSquare)
            {
                return null;
            }
            else if (a == 0)
            {
                return null;
            }
            T[,] mat = new T[this.indexRow, this.indexColumn];
            for (int i = 0; i < this.indexRow; i++)
            {
                for (int j = 0; j < this.indexColumn; j++)
                {
                    T[,] c = cropMatrix(this.indexColumn, i, j, this.map);
                    dynamic v2 = this.MatrixDetermine(this.indexColumn - 1, c);
                    mat[i, j] = (v2 * Math.Pow(-1, i + j));
                }
            }
            
            return new Matrix<T>(this.indexRow, this.indexColumn, mat).MatrixTranspos();
        }
        public Matrix<T> MatrixInvert()
        {
            dynamic d = this.value;
            return this.MatrixAdjoint().MatrixConstantMultiplication((1 / d));
        }

        private T MatrixDetermine(int x,T[,] mat) {
            if (x == 1) {
                return mat[0,0];
            }
            if (x == 2)
            {
                dynamic a = mat[0, 0];
                dynamic b = mat[0, 1];
                dynamic c = mat[1, 0];
                dynamic d = mat[1, 1];
                return (T)((a * d) - (b * c));
            }
            else {
                dynamic value = 0;
                for (int i = 0; i < x; i++) {
                    dynamic a = mat[0, i];
                    T[,] mat1 = cropMatrix(x,0,i, mat);
                    dynamic b = this.MatrixDetermine(x - 1, mat1);
                    value = value + (a * b *Math.Pow(-1,i));
                }
                return value;
            }
        }
        private T[,] cropMatrix(int size, int row,int column, T[,] mat) {
            T [,]mat1 = new T[size - 1, size - 1];
            int l = 0;
            for (int i = 0; i < size; i++) {
                int k = 0;
                if (i != row)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j != column)
                        {
                            mat1[l, k] = mat[i, j];
                            k++;
                        }
                    }
                    l++;
                }
            }
            return mat1;
        }
    }
}
