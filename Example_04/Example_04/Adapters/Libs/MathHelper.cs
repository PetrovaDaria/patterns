namespace Example_04.Adapters.Libs
{
    public class MathHelper
    {
        public int[] MatrixMultiply(int w1, int h1, int[] matrix1, int w2, int h2, int[] matrix2)
        {
            return new int[0];
        }

        public virtual int[] VectorMultiply(int[] vector1, int[] vector2)
        {
            return new int[0];
        }
    }

    public class MathHelper2 : MathHelper
    {
        public int Miltiply(int i1, int i2) => i1 * i2;

        public override int[] VectorMultiply(int[] vector1, int[] vector2)
        {
            return new int[0];
        }
    }
}
