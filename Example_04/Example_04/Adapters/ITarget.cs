namespace Example_04.Adapters
{
    public interface ITarget
    {
        int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2);
        int[] VectorMultiply(int[] vector1, int[] vector2);
    }
}
