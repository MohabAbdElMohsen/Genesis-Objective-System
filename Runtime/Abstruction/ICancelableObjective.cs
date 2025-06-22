using System;

namespace Genesis.ObjectiveSystem
{
    public interface ICancelableObjective : IObjectiveBase
    {
        bool isCancelled { get; }

        event Action Cancelled;
        
        void MarkAsCancelled();
    }   
}