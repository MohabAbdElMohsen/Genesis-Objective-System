using System;
using System.Collections.Generic;
using UnityEngine;

namespace Genesis.ObjectiveSystem
{
    [Serializable]
    [CreateAssetMenu(fileName = "CompositeObjective", menuName = "Genesis/Modules/Objective System/Create/Composite Objective")]
    public class CompositeObjective : ObjectiveBase
    {
        [SerializeField] private List<ObjectiveBase> _subObjectives;
        
        private int _completedSubObjectivesCount;

        public override float completionRate => _completedSubObjectivesCount / _subObjectives?.Count ?? 0.0f;

        protected override void OnEnable()
        {
            Initialize();
            
            base.OnEnable();
        }

        private void Initialize()
        {
            foreach (IObjective objective in _subObjectives)
            {
                if (objective == null)
                    throw new Exception($"{name} objective mustn't contain null objective.");
                
                objective.Completed += OnObjectiveCompleted;
                objective.Reseted += OnObjectiveReseted;
            }
        }

        public override void MarkAsCompleted()
        {
            if (isCompleted || isCancelled)
                return;
            
            CompleteSubObjectives();
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
            if (!isCompleted)
                return;
            
            _completedSubObjectivesCount = 0;

            isFailed = false;
            isCancelled = false;
            
            InvokeReseted();
        }

        private void PartialReset()
        {
            if (!isCompleted)
                return;
            
            if (_completedSubObjectivesCount > 0)
                _completedSubObjectivesCount--;
            
            isFailed = false;
            isCancelled = false;
            
            InvokeReseted();
        }
        
        private void CompleteSubObjectives()
        {
            foreach (IObjective objective in _subObjectives)
                objective?.MarkAsCompleted();
        }

        private void OnObjectiveCompleted()
        {
            _completedSubObjectivesCount++;
                
            if ((_completedSubObjectivesCount) >= _subObjectives.Count)
            {
                InvokeCompleted();
                    
                return;
            }
        }

        private void OnObjectiveReseted()
            => PartialReset();
    }
}