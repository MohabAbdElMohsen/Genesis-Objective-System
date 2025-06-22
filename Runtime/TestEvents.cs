using UnityEngine;

public class TestEvents : MonoBehaviour
{
    public void OnObjectiveBegined()
    {
        Debug.Log("Objective has Begined");
    }
    
    public void OnObjectiveCompleted()
    {
        Debug.Log("Objective has Completed");
    }
    
    public void OnObjectiveCancelled()
    {
        Debug.Log("Objective has Cancelled");
    }
}
