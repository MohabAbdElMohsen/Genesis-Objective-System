using UnityEngine;
using Sirenix.OdinInspector;
using Genesis.ObjectiveSystem;

namespace ARK.ObjectiveSystem
{
    public class ObjectiveController : MonoBehaviour, IObjectiveController
    {
        [SerializeField] private ObjectiveBase _objective;
        public IObjective objective { get; }

        [ShowInInspector][ReadOnly][Range(0.0f, 1.0f)] public float completionRate => objective?.completionRate ?? 0.0f;
        [ShowInInspector][ReadOnly] public bool isCompleted => objective?.isCompleted ?? false;
        [ShowInInspector][ReadOnly] public bool isCancelled => objective?.isCancelled ?? false;

        [Button("Mark Objective As Completed")]
        private void MarkObjectiveAsCompleted()
            => objective?.MarkAsCompleted();
        
        [Button("Mark Objective As Failed")]
        private void MarkObjectiveAsFailed()
            => objective?.MarkAsFailed();
        
        [Button("Mark Objective As Cancelled")]
        private void MarkObjectiveAsCancelled()
            => objective?.MarkAsCancelled();

        [Button("Reset")]
        private void Reset()
            => objective?.Reset();
    }   
}