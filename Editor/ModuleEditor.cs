using UnityEditor;
using UnityEngine;

namespace ARK.ObjectiveSystem.Editor
{
    [CustomEditor(typeof(Module), true)]
    public class ModuleEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            SerializedProperty descriptionProp = serializedObject.FindProperty("_description");
            if (descriptionProp != null)
                EditorGUILayout.PropertyField(descriptionProp, new GUIContent("Description"));
            
            SerializedProperty subObjectivesProp = serializedObject.FindProperty("_subObjectives");

            if (subObjectivesProp != null)
                EditorGUILayout.PropertyField(subObjectivesProp, new GUIContent("Interactions"));

            serializedObject.ApplyModifiedProperties();
        }
    }   
}