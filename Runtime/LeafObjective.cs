using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Genesis.ObjectiveSystem
{
    [Serializable]
    [CreateAssetMenu(fileName = "LeafObjective", menuName = "Genesis/Modules/Objective System/Create/Leaf Objective")]
    public class LeafObjective : ObjectiveBase
    {
        private float _completionRate;
        
        public override float completionRate
            => _completionRate;
        
        public override void MarkAsCompleted()
        {
            if (isCompleted || isCancelled)
                return;

            _completionRate = 1.0f;
            
            InvokeCompleted();
        }

        public override void MarkAsFailed() { }
        
        public override void MarkAsCancelled()
        {
            if (isCompleted || isCancelled)
                return;
            
            isCancelled = true;
            
            InvokeCancelled();
        }
        
        public override void Reset()
        {
            _completionRate = 0.0f;

            isFailed = false;
            isCancelled = false;
            
            InvokeReseted();
        }
    }   
}