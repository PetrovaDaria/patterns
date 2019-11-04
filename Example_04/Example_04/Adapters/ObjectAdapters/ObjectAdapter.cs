using System.Linq;
using Example_04.Adapters.Libs;

namespace Example_04.Adapters.ObjectAdapters
{
    public class ObjectAdapter : ITarget
    {
        private readonly MathHelper _mathHelper;

        public ObjectAdapter(MathHelper mathHelper)
        {
            _mathHelper = mathHelper;
        }

        public int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
        {
            var h1 = matrix1.GetLength(0);
            var w1 = matrix1.GetLength(1);

            var h2 = matrix2.GetLength(0);
            var w2 = matrix2.GetLength(1);

            var result = _mathHelper.MatrixMultiply(h1, w1, matrix1.Cast<int>().ToArray(), h2, w2, matrix2.Cast<int>().ToArray());

            return new int[0, 0];
        }

        public int[] VectorMultiply(int[] vector1, int[] vector2)
        {
            return _mathHelper.VectorMultiply(vector1, vector2);
        }
    }
}
