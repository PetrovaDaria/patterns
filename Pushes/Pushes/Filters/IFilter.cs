namespace Pushes
{
    public interface IFilter
    {
        bool Filter(System system, Push push);
    }
}
