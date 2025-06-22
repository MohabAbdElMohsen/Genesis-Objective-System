using UnityEngine;
using UnityEngine.Events;

namespace Genesis.ObjectiveSystem
{
    public sealed class ObjectiveUnityEventWrapper : MonoBehaviour
    {
        [SerializeField] private ScriptableObject _objective;
        
        public IObjective objective => _objective as IObjective;
        
        [SerializeField] private UnityEvent _completed;
        public UnityEvent completed => _completed;
        
        [SerializeField] private UnityEvent _failed;
        public UnityEvent failed => _failed;
        
        [SerializeField] private UnityEvent _cancelled;
        public UnityEvent cancelled => _cancelled;
        
        [SerializeField] private UnityEvent _reseted;
        public UnityEvent reseted => _reseted;

        private void OnEnable()
        {
            objective.Completed += OnObjectiveCompleted;
            objective.Failed += OnObjectiveFailed;
            objective.Cancelled += OnObjectiveCancelled;
            objective.Reseted += OnObjectiveReseted;
        }

        private void OnDisable()
        {
            objective.Completed -= OnObjectiveCompleted;
            objective.Failed -= OnObjectiveFailed;
            objective.Cancelled -= OnObjectiveCancelled;
            objective.Reseted += OnObjectiveReseted;
        }
        
        private void OnObjectiveCompleted()
            => _completed?.Invoke();

        private void OnObjectiveFailed()
            => _failed?.Invoke();

        private void OnObjectiveCancelled()
            => _cancelled?.Invoke();
        
        private void OnObjectiveReseted()
            => _reseted?.Invoke();
    }   
}