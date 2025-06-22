namespace Genesis.ObjectiveSystem
{
    public interface IDescribableObjective : IObjectiveBase
    {
        string name { get; }
        string description { get; }
    }
}