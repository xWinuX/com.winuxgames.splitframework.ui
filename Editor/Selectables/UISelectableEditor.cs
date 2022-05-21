using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Editor.Selectables
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UISelectable), true)]
    public class UISelectableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("General", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_uiElement"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_uiDependency"));
            EditorGUILayout.Separator();

            GUILayout.Label("Selection", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_selectBehaviourSO"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_onSelectUnityEvent"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_onSubmitUnityEvent"));
            EditorGUILayout.Separator();

            serializedObject.ApplyModifiedProperties();
        }
    }
}