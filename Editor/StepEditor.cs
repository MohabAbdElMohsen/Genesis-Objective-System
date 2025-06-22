using UnityEditor;
using UnityEngine;

namespace ARK.ObjectiveSystem.Editor
{
    [CustomEditor(typeof(Step), true)]
    public class StepEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            SerializedProperty descriptionProp = serializedObject.FindProperty("_description");
            if (descriptionProp != null)
                EditorGUILayout.PropertyField(descriptionProp, new GUIContent("Description"));

            serializedObject.ApplyModifiedProperties();
        }
    }   
}