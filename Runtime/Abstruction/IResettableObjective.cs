using System;

namespace Genesis.ObjectiveSystem
{
    public interface IResettableObjective
    {
        event Action Reseted;
        
        void Reset();
    }   
}