using System;

namespace Genesis.ObjectiveSystem
{
    public interface ICompletableObjective : IObjectiveBase
    {
        float completionRate { get; }
        
        bool isCompleted { get; }
        
        event Action Completed;
        
        void MarkAsCompleted();
    }   
}