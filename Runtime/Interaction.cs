using UnityEngine;
using Genesis.ObjectiveSystem;

namespace ARK.ObjectiveSystem
{
    [CreateAssetMenu(fileName = "Interaction", menuName = "VRC/Modules/Objective System/Create/Interaction")]
    public class Interaction : CompositeObjective
    {
        [SerializeField] private string _token;
    }   
}