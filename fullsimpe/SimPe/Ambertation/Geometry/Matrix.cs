// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Globalization;

using SimPe.Geometry;
using SimPe;

namespace Ambertation.Geometry
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Matrix : IDisposable, ICloneable
	{
		private double[][] m;

		private int rows;

		private int cols;

		public int Rows => rows;

		public int Columns
		{
			get
			{
				if (rows == 0)
				{
					return 0;
				}

				return cols;
			}
		}

		public double this[int row, int col]
		{
			get
			{
				return m[row][col];
			}
			set
			{
				m[row][col] = value;
			}
		}

		public bool Identity
		{
			get
			{
				if (rows != cols)
				{
					return false;
				}

				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						if (i == j)
						{
							if (this[i, j] != 1.0)
							{
								return false;
							}
						}
						else if (this[i, j] != 0.0)
						{
							return false;
						}
					}
				}

				return true;
			}
		}

		public bool Invertable => Determinant() != 0.0;

		public bool Orthogonal
		{
			get
			{
				if (rows != cols)
				{
					return false;
				}

				Matrix matrix = this * GetTranspose();
				if (!matrix.Identity)
				{
					return false;
				}

				matrix = GetTranspose() * this;
				if (!matrix.Identity)
				{
					return false;
				}

				return true;
			}
		}

		public double Trace
		{
			get
			{
				if (Rows != Columns)
				{
					throw new GeometryException("Unable to get Trace for a non Square Matrix (" + ToString() + ")");
				}

				double num = 0.0;
				for (int i = 0; i < Rows; i++)
				{
					num += this[i, i];
				}

				return num;
			}
		}

		public Matrix()
			: this(4, 4)
		{
		}

		public Matrix(int row, int col)
		{
			rows = row;
			cols = col;
			m = new double[row][];
			for (int i = 0; i < row; i++)
			{
				m[i] = new double[col];
			}
		}

		public Matrix GetTranspose()
		{
			Matrix matrix = new Matrix(cols, rows);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					matrix[j, i] = this[i, j];
				}
			}

			return matrix;
		}

		public static Matrix GetIdentity(int row, int col)
		{
			Matrix matrix = new Matrix(row, col);
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					if (i == j)
					{
						matrix[i, j] = 1.0;
					}
					else
					{
						matrix[i, j] = 0.0;
					}
				}
			}

			return matrix;
		}

		public static Matrix operator *(Matrix m1, Matrix m2)
		{
			if (m1.cols != m2.rows)
			{
				throw new GeometryException("Unable to multiplicate Matrices (" + m1.ToString() + " * " + m2.ToString() + ")");
			}

			Matrix matrix = new Matrix(m1.rows, m2.cols);
			for (int i = 0; i < matrix.rows; i++)
			{
				for (int j = 0; j < matrix.cols; j++)
				{
					double num = 0.0;
					for (int k = 0; k < m1.cols; k++)
					{
						num += m1[i, k] * m2[k, j];
					}

					matrix[i, j] = num;
				}
			}

			return matrix;
		}

		public static Matrix operator *(Matrix m1, double d)
		{
			Matrix matrix = new Matrix(m1.rows, m1.cols);
			for (int i = 0; i < matrix.rows; i++)
			{
				for (int j = 0; j < matrix.cols; j++)
				{
					matrix[i, j] = m1[i, j] * d;
				}
			}

			return matrix;
		}

		public static Matrix operator *(double d, Matrix m1)
		{
			return m1 * d;
		}

		public static Matrix operator /(Matrix m1, double d)
		{
			if (d == 0.0)
			{
				throw new GeometryException("Unable to divide by Zero.");
			}

			Matrix matrix = new Matrix(m1.rows, m1.cols);
			for (int i = 0; i < matrix.rows; i++)
			{
				for (int j = 0; j < matrix.cols; j++)
				{
					matrix[i, j] = m1[i, j] / d;
				}
			}

			return matrix;
		}

		public static Matrix operator /(double d, Matrix m1)
		{
			return m1 / d;
		}

		public static Matrix operator ^(Matrix m1, float val)
		{
			if (m1.rows != m1.cols)
			{
				throw new GeometryException("Attempt to find the power of a non square matrix");
			}

			Matrix result = m1;
			for (int i = 0; (float)i < val; i++)
			{
				result *= m1;
			}

			return result;
		}

		public static Matrix operator +(Matrix m1, Matrix m2)
		{
			if (m1.rows != m2.rows || m1.cols != m2.cols)
			{
				throw new GeometryException("Attempt to add matrixes of different sizes.");
			}

			Matrix matrix = new Matrix(m1.rows, m1.cols);
			for (int i = 0; i < m1.rows; i++)
			{
				for (int j = 0; j < m1.cols; j++)
				{
					matrix[i, j] = m1[i, j] + m2[i, j];
				}
			}

			return matrix;
		}

		public static Matrix operator -(Matrix m1, Matrix m2)
		{
			if (m1.rows != m2.rows || m1.cols != m2.cols)
			{
				throw new GeometryException("Attempt to subtract matrixes of different sizes.");
			}

			Matrix matrix = new Matrix(m1.rows, m1.cols);
			for (int i = 0; i < m1.rows; i++)
			{
				for (int j = 0; j < m1.cols; j++)
				{
					matrix[i, j] = m1[i, j] - m2[i, j];
				}
			}

			return matrix;
		}

		public static Matrix operator !(Matrix m1)
		{
			return m1.GetInverse();
		}

		public Matrix GetInverse()
		{
			double num = Determinant();
			if (num == 0.0)
			{
				throw new GeometryException("Attempt to invert a singular matrix.");
			}

			if (rows == 2 && cols == 2)
			{
				Matrix matrix = new Matrix(2, 2);
				matrix[0, 0] = this[1, 1];
				matrix[0, 1] = 0.0 - this[0, 1];
				matrix[1, 0] = 0.0 - this[1, 0];
				matrix[1, 1] = this[0, 0];
				return matrix / num;
			}

			return Adjoint() / num;
		}

		public override string ToString()
		{
			return rows + "x" + cols + "-Matrix";
		}

		private string RowString(int wd)
		{
			string text = "";
			for (int i = 0; i < cols; i++)
			{
				text += Helpers.ForceLength("+", wd + 1, '-', front: false);
			}

			return text + "+\n";
		}

		public string ToString(string format, int wd)
		{
			string text = "";
			text += RowString(wd);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					text += "|";
					text += Helpers.ForceLength(this[i, j].ToString(format), wd, '0', front: true);
				}

				text += "|\n";
				text += RowString(wd);
			}

			return text;
		}

		public string ToMaple()
		{
			return ToMaple(rows, cols);
		}

		public string ToMaple(int rows, int cols)
		{
			string text = "<";
			for (int i = 0; i < cols; i++)
			{
				if (i != 0)
				{
					text += " | ";
				}

				text += "<";
				for (int j = 0; j < rows; j++)
				{
					if (j != 0)
					{
						text += " ,";
					}

					text += this[j, i].ToString("N6", CultureInfo.InvariantCulture);
				}

				text += ">";
			}

			return text += ">";
		}

		public override int GetHashCode()
		{
			double num = 0.0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					num += this[i, j];
				}
			}

			return (int)num;
		}

		public override bool Equals(object obj)
		{
			if ((object)obj.GetType() != typeof(Matrix))
			{
				return false;
			}

			Matrix matrix = (Matrix)obj;
			if (rows != matrix.rows || cols != matrix.cols)
			{
				return false;
			}

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (this[i, j] != matrix[i, j])
					{
						return false;
					}
				}
			}

			return true;
		}

		public static bool operator ==(Matrix m1, Matrix m2)
		{
			return object.Equals(m1, m2);
		}

		public static bool operator !=(Matrix m1, Matrix m2)
		{
			return !(m1 == m2);
		}

		public Matrix Adjoint()
		{
			if (rows < 2 || cols < 2)
			{
				throw new GeometryException("Adjoint matrix is not available. (" + ToString() + ")");
			}

			Matrix matrix = new Matrix(rows - 1, cols - 1);
			Matrix matrix2 = new Matrix(cols, rows);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					matrix = Minor(i, j);
					matrix2[j, i] = (double)(int)Math.Pow(-1.0, i + j) * matrix.Determinant();
				}
			}

			return matrix2;
		}

		public Matrix Minor(int row, int column)
		{
			if (rows < 2 || cols < 2)
			{
				throw new GeometryException("Minor not available. (" + ToString() + ")");
			}

			int num = 0;
			Matrix matrix = new Matrix(rows - 1, cols - 1);
			for (int i = 0; i < matrix.rows; i++)
			{
				int row2 = ((i < row) ? i : (i + 1));
				for (int j = 0; j < matrix.cols; j++)
				{
					num = ((j < column) ? j : (j + 1));
					matrix[i, j] = this[row2, num];
				}
			}

			return matrix;
		}

		public double Determinant()
		{
			if (rows != cols)
			{
				throw new GeometryException("You can only compute the Determinant of a Square Matrix. (" + ToString() + ")");
			}

			double num = 0.0;
			if (rows == 2 && cols == 2)
			{
				return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
			}

			if (rows == 3 && cols == 3)
			{
				return this[0, 0] * this[1, 1] * this[2, 2] + this[0, 1] * this[1, 2] * this[2, 0] + this[0, 2] * this[1, 0] * this[2, 2] - this[0, 2] * this[1, 1] * this[2, 0] - this[0, 1] * this[1, 0] * this[2, 2] - this[0, 0] * this[1, 2] * this[2, 1];
			}

			Matrix matrix = new Matrix(rows - 1, cols - 1);
			for (int i = 0; i < cols; i++)
			{
				matrix = Minor(0, i);
				num += (double)(int)Math.Pow(-1.0, i) * this[0, i] * matrix.Determinant();
			}

			return num;
		}

		private void SwapRow(int row1, int row2)
		{
			for (int i = 0; i < cols; i++)
			{
				double value = this[row1, i];
				this[row1, i] = this[row2, i];
				this[row2, i] = value;
			}
		}

		private void MultiplyRow(int row, double d)
		{
			for (int i = 0; i < cols; i++)
			{
				this[row, i] *= d;
			}
		}

		private void AddRow(int trow, int row2, double d)
		{
			for (int i = 0; i < cols; i++)
			{
				this[trow, i] += this[row2, i] * d;
			}
		}

		public double DeterminantFast()
		{
			if (rows != cols)
			{
				throw new GeometryException("You can only compute the Determinant of a Square Matrix. (" + ToString() + ")");
			}

			double num = 1.0;
			try
			{
				Matrix matrix = (Matrix)Clone();
				for (int i = 0; i < rows; i++)
				{
					if (matrix[i, i] == 0.0)
					{
						for (int j = i + 1; j < matrix.rows; j++)
						{
							if (matrix[j, i] != 0.0)
							{
								matrix.SwapRow(i, j);
								num *= -1.0;
							}
						}
					}

					num *= matrix[i, i];
					double num2 = matrix[i, i];
					num2 = ((matrix[i, i] == 0.0) ? 0.0 : (1.0 / num2));
					matrix.MultiplyRow(i, num2);
					for (int j = i + 1; j < matrix.rows; j++)
					{
						matrix.AddRow(j, i, 0.0 - matrix[j, i]);
					}

					for (int j = i - 1; j >= 0; j--)
					{
						matrix.AddRow(j, i, 0.0 - matrix[j, i]);
					}
				}

				return num;
			}
			catch (Exception)
			{
				throw new GeometryException("Determinant of the given matrix could not be calculated");
			}
		}

		public Matrix ReducedEchelonForm()
		{
			try
			{
				Matrix matrix = (Matrix)Clone();
				for (int i = 0; i < rows; i++)
				{
					if (matrix[i, i] == 0.0)
					{
						for (int j = i + 1; j < matrix.rows; j++)
						{
							if (matrix[j, i] != 0.0)
							{
								matrix.SwapRow(i, j);
							}
						}
					}

					if (matrix[i, i] == 0.0)
					{
						continue;
					}

					if (matrix[i, i] != 1.0)
					{
						for (int j = i + 1; j < matrix.rows; j++)
						{
							if (matrix[j, i] == 1.0)
							{
								matrix.SwapRow(i, j);
							}
						}
					}

					matrix.MultiplyRow(i, 1.0 / matrix[i, i]);
					for (int j = i + 1; j < matrix.rows; j++)
					{
						matrix.AddRow(j, i, 0.0 - matrix[j, i]);
					}

					for (int j = i - 1; j >= 0; j--)
					{
						matrix.AddRow(j, i, 0.0 - matrix[j, i]);
					}
				}

				return matrix;
			}
			catch (Exception inner)
			{
				throw new GeometryException("Unable to calculate Determinant.", inner);
			}
		}

		public static Matrix Translation(Vector3 v)
		{
			return Translation(v.X, v.Y, v.Z);
		}

		public static Matrix Translation(double x, double y, double z)
		{
			Matrix matrix = new Matrix(4, 4);
			matrix[0, 0] = 1.0;
			matrix[0, 1] = 0.0;
			matrix[0, 2] = 0.0;
			matrix[0, 3] = x;
			matrix[1, 0] = 0.0;
			matrix[1, 1] = 1.0;
			matrix[1, 2] = 0.0;
			matrix[1, 3] = y;
			matrix[2, 0] = 0.0;
			matrix[2, 1] = 0.0;
			matrix[2, 2] = 1.0;
			matrix[2, 3] = z;
			matrix[3, 0] = 0.0;
			matrix[3, 1] = 0.0;
			matrix[3, 2] = 0.0;
			matrix[3, 3] = 1.0;
			return matrix;
		}

		public static Matrix Scale(double s)
		{
			return Scale(s, s, s);
		}

		public static Matrix Scale(double x, double y, double z)
		{
			Matrix matrix = new Matrix(4, 4);
			matrix[0, 0] = x;
			matrix[0, 1] = 0.0;
			matrix[0, 2] = 0.0;
			matrix[0, 3] = 0.0;
			matrix[1, 0] = 0.0;
			matrix[1, 1] = y;
			matrix[1, 2] = 0.0;
			matrix[1, 3] = 0.0;
			matrix[2, 0] = 0.0;
			matrix[2, 1] = 0.0;
			matrix[2, 2] = z;
			matrix[2, 3] = 0.0;
			matrix[3, 0] = 0.0;
			matrix[3, 1] = 0.0;
			matrix[3, 2] = 0.0;
			matrix[3, 3] = 1.0;
			return matrix;
		}

		public static Matrix RotateX(double angle)
		{
			Matrix identity = GetIdentity(4, 4);
			identity[1, 1] = Math.Cos(angle);
			identity[1, 2] = 0.0 - Math.Sin(angle);
			identity[2, 1] = Math.Sin(angle);
			identity[2, 2] = Math.Cos(angle);
			return identity;
		}

		public static Matrix RotateY(double angle)
		{
			Matrix identity = GetIdentity(4, 4);
			identity[0, 0] = Math.Cos(angle);
			identity[0, 2] = Math.Sin(angle);
			identity[2, 0] = 0.0 - Math.Sin(angle);
			identity[2, 2] = Math.Cos(angle);
			return identity;
		}

		public static Matrix RotateZ(double angle)
		{
			Matrix identity = GetIdentity(4, 4);
			identity[0, 0] = Math.Cos(angle);
			identity[0, 1] = 0.0 - Math.Sin(angle);
			identity[1, 0] = Math.Sin(angle);
			identity[1, 1] = Math.Cos(angle);
			return identity;
		}

		public Vector3 GetEulerAngles()
		{
			Vector3 zero = Vector3.Zero;
			zero.X = Math.Asin(0.0 - this[1, 2]);
			if (zero.X < Math.PI / 2.0)
			{
				if (zero.X > -Math.PI / 2.0)
				{
					zero.Y = (float)Math.Atan2(this[0, 2], this[2, 2]);
					zero.Z = (float)Math.Atan2(this[1, 0], this[1, 1]);
				}
				else
				{
					zero.Y = (float)(-1.0 * Math.Atan2(0.0 - this[0, 1], this[0, 0]));
				}
			}

			return zero;
		}

		public void Dispose()
		{
			if (m != null)
			{
				for (int i = 0; i < rows; i++)
				{
					m[i] = new double[0];
				}

				m = new double[0][];
				m = null;
			}
		}

		public virtual object Clone()
		{
			Matrix matrix = new Matrix(rows, cols);
			for (int i = 0; i < matrix.rows; i++)
			{
				for (int j = 0; j < matrix.cols; j++)
				{
					matrix[i, j] = this[i, j];
				}
			}

			return matrix;
		}

		public void MakeEmpty()
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					this[i, j] = 0.0;
				}
			}
		}

		public void MakeIdentity()
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (j == i)
					{
						this[i, j] = 1.0;
					}
					else
					{
						this[i, j] = 0.0;
					}
				}
			}
		}

		public double[] GetFields()
		{
			double[] array = new double[rows * cols];
			int num = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					array[num++] = this[i, j];
				}
			}

			return array;
		}

		public void SetFields(double[] flds)
		{
			if (flds.Length < rows * cols)
			{
				throw new GeometryException("Filed Array is to short for a " + rows + "x" + cols + " Matrix.");
			}

			int num = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					this[i, j] = flds[num++];
				}
			}
		}
	}
}
