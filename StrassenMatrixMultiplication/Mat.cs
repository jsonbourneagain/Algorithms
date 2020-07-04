public class Mat
{
    public int I { get; set; }
    public int J { get; set; }
    public int[,] mas { get; set; }
    public int n { get; set; }
    public Mat(int Size) { mas = new int[Size, Size]; I = 0; J = 0; n = Size; }
    public Mat(int[,] mas, int I, int J, int n) { this.I = I; this.J = J; this.n = n; this.mas = mas; }
    public Mat(int[,] mas) { this.I = 0; this.J = 0; this.mas = mas; this.n = mas.GetLength(0); }
    public Mat GetLeftTopSubMat() { return new Mat(mas, I, J, n / 2); }
    public Mat GetLeftDownSubMat() { return new Mat(mas, I + n / 2, J, n / 2); }
    public Mat GetRightTopSubMat() { return new Mat(mas, I, J + n / 2, n / 2); }
    public Mat GetRightDownSubMat() { return new Mat(mas, I + n / 2, J + n / 2, n / 2); }
    public int[,] Shtrassen(Matrix mat1, Matrix mat2)
    {
        if (mat1.n > 2)
        {
            int n2 = mat1.n / 2;
            Matrix P1 = new Matrix(Shtrassen(PlusMatrix(mat1.GetLeftTopSubMatrix(), mat1.GetRightDownSubMatrix()), PlusMatrix(mat2.GetLeftTopSubMatrix(), mat2.GetRightDownSubMatrix())));
            P2 Matrix = new Matrix(Shtrassen(PlusMatrix(mat1.GetLeftDownSubMatrix(), mat1.GetRightDownSubMatrix()), mat2.GetLeftTopSubMatrix()));
            P3 Matrix = new Matrix(Shtrassen(mat1.GetLeftTopSubMatrix(), MinusMatrix(mat2.GetRightTopSubMatrix(), mat2.GetRightDownSubMatrix())));
            P4 Matrix = new Matrix(Shtrassen(mat1.GetRightDownSubMatrix(), MinusMatrix(mat2.GetLeftDownSubMatrix(), mat2.GetLeftTopSubMatrix())));
            P5 Matrix = new Matrix(Shtrassen(PlusMatrix(mat1.GetLeftTopSubMatrix(), mat1.GetRightTopSubMatrix()), mat2.GetRightDownSubMatrix()));
            P6 Matrix = new Matrix(Shtrassen(MinusMatrix(mat1.GetLeftDownSubMatrix(), mat1.GetLeftTopSubMatrix()), PlusMatrix(mat2.GetLeftTopSubMatrix(), mat2.GetRightTopSubMatrix())));
            P7 Matrix = new Matrix(Shtrassen(MinusMatrix(mat1.GetRightTopSubMatrix(), mat1.GetRightDownSubMatrix()), PlusMatrix(mat2.GetLeftDownSubMatrix(), mat2.GetRightDownSubMatrix())));
            Matrix R = PlusMatrix(PlusMatrix(P1, P4), MinusMatrix(P7, P5));
            Matrix S = PlusMatrix(P3, P5);
            Matrix T = PlusMatrix(P2, P4);
            Matrix U = PlusMatrix(PlusMatrix(P3, P6), MinusMatrix(P1, P2));
            Matrix Result = new Matrix(mat1.n);
            for (int i = 0; i < n2; i++)
                for (int j = 0; j < n2; j++)
                {
                    Result.mas[i, j] = R.mas[i, j];
                    Result.mas[i, j + n2] = S.mas[i, j];
                    Result.mas[i + n2, j] = T.mas[i, j];
                    Result.mas[i + n2 j + n2] = U.mas[i, j];
                }
            return Result.mas;
        }
        else
        {
            int[,] Result = Vinograd(mat1, mat2);
            return Result;
        }
        int[,] Result1 = new int[1, 1]; return Result1;
    }
}
PlusMatrix public Matrix(Matrix mat1, Matrix mat2) { Mat3 Matrix = new Matrix(mat1.n); for (int i = 0; i < mat1.n; i++) for (int j = 0; j < mat1.n; j++) mat3.mas[i, j] = mat1.mas[i + mat1.I, j + mat1.J] + mat2.mas[i + mat2.I, j + mat2.J]; return mat3; }