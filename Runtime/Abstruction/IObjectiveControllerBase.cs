namespace Genesis.ObjectiveSystem
{
    public interface IObjectiveControllerBase<T> where T : class, IObjectiveBase
    {
        public T objective { get; }
    }   
}