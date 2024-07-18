using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    internal class Matrix
    {
        private int[,] _matrix;

        public Matrix(int numRow, int numColumns, int minValue=0, int maxValue=100)
        {
            _matrix = new int[numRow, numColumns];
            FillRandomNumber(minValue, maxValue);
        }

        public Matrix(int numRow, int numColumns, int maxValue):this(numRow, numColumns, 0, maxValue) 
        {

        }

        public void FillRandomNumber(int minValue, int maxValue)
        {
            if (maxValue <= minValue || maxValue>Math.Pow(2,31)) throw new ArgumentException("the value is invalid");
            Random rnd = new Random();
            for (int i=0; i< _matrix.GetLength(0); i++) 
            {
                for(int j=0; j< _matrix.GetLength(1); j++)
                {           
                    _matrix[i,j] = rnd.Next(minValue, maxValue);
                }
            }
        }

        public bool IsSquareMatrix
        {
            get
            {
                if (_matrix.GetLength(0) == _matrix.GetLength(1)) return true;
                return false;
            }
        }

        public int ValueAt(int indexRow, int indexColumn)
        {
            if (indexRow < 0 || indexColumn < 0 || indexRow >= _matrix.GetLength(0) || indexColumn >= _matrix.GetLength(1)) 
                throw new ArgumentException("the index is invalid");
            return _matrix[indexRow, indexColumn];
        }

        public void sumElements()
        {
            int sum = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    sum += _matrix[i,j];
                }
            }
            
        }

        public int sumDiagonalElements()
        {
            if (IsSquareMatrix) throw new ArgumentException("the matrix isnot sqare");
            int sum = 0;
            for (int i=0; i<_matrix.GetLength(0); i++)
            {
                sum += _matrix[i, i];
            }
            return sum;
        }

        public int sumSubDiagonalElements()
        {
            if (IsSquareMatrix) throw new ArgumentException("the matrix isnot sqare");
            int sum = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                sum += _matrix[i, _matrix.GetLength(1) - i];
            }
            return sum;
        }

        public bool IsSymmetric
        {
            get
            {
                bool symmetric = false;
                if (IsSquareMatrix) throw new ArgumentException("the matrix isnot sqare");
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for(int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        if(i != j)
                        {
                            if(_matrix[i,j] == _matrix[j,i])
                            {
                                symmetric = true;
                            }else
                            {
                                symmetric = false;
                                break;
                            }
                        }
                    }
                }
                return symmetric;
            }
        }

        public int[,] GenerateTrasposedMatrix()
        {
            int[,] trasposedMatrix = new int[_matrix.GetLength(1),_matrix.GetLength(0)];
            
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for(int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        trasposedMatrix[j,i] = _matrix[i,j];
                    }
                }
                return trasposedMatrix;
        }
    }
}
