using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Genesis.ObjectiveSystem
{
    public abstract  class ObjectiveBase : ScriptableObject, IObjective
    {
        [SerializeField] private string _description;
        public string description
            => _description;

        public abstract float completionRate { get; }

        public virtual bool isCompleted
            => completionRate >= 1.0f;
        
        public bool isFailed { get; protected set; }
        
        public bool isCancelled { get; protected set; }

        public event Action Completed;
        public event Action Failed;
        public event Action Cancelled;
        public event Action Reseted;

        protected void InvokeCompleted()
            => Completed?.Invoke();
        
        protected void InvokeFailed()
            => Failed?.Invoke();
        protected void InvokeCancelled()
            => Cancelled?.Invoke();
        
        protected void InvokeReseted()
            => Reseted?.Invoke();
        
        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
#endif
        }

        protected virtual void OnDisable()
        {
            Reset();
            
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= OnPlayModeChanged;
#endif
        }
        
        public abstract void MarkAsCompleted();

        public abstract void MarkAsCancelled();
        
        public abstract void MarkAsFailed();

        public abstract void Reset();
        
#if UNITY_EDITOR
        private void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
                Reset();
        }
#endif
    }   
}