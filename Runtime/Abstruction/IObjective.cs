namespace Genesis.ObjectiveSystem
{
    public interface IObjective : IDescribableObjective, ICompletableObjective, IFailableObjective, ICancelableObjective, IResettableObjective
    { }  
}