using UnityEngine;

namespace Genesis.ObjectiveSystem
{
    public abstract class ObjectiveControllerBase : MonoBehaviour
    {
        [SerializeField] private ObjectiveBase _objective;
        protected IObjective objective
            => _objective;
    }   
}