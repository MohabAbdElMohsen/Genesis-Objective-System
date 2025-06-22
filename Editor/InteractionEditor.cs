using UnityEditor;
using UnityEngine;

namespace ARK.ObjectiveSystem
{
    [CustomEditor(typeof(Interaction), true)]
    public class InteractionEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            SerializedProperty descriptionProp = serializedObject.FindProperty("_description");
            if (descriptionProp != null)
                EditorGUILayout.PropertyField(descriptionProp, new GUIContent("Description"));
            
            SerializedProperty subObjectivesProp = serializedObject.FindProperty("_subObjectives");

            if (subObjectivesProp != null)
                EditorGUILayout.PropertyField(subObjectivesProp, new GUIContent("Steps"));
            
            SerializedProperty tokenProp = serializedObject.FindProperty("_token");

            if (tokenProp != null)
                EditorGUILayout.PropertyField(tokenProp, new GUIContent("Token"));

            serializedObject.ApplyModifiedProperties();
        }
    }   
}