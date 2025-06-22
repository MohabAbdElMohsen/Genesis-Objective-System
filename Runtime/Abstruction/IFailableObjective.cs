using System;

namespace Genesis.ObjectiveSystem
{
    public interface IFailableObjective
    {
        bool isFailed { get; }

        event Action Failed;
        
        void MarkAsFailed();
    }
}