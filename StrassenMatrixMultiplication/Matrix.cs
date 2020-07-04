public class Matrix{

    public int Row { get; set; }
    public int Column { get; set; }
    public int[,] Value { get; set; }

    public Matrix(int row, int column, int[,] value)
    {
        this.Row = row;
        this.Column = column;
        this.Value = value;
    }
    

}