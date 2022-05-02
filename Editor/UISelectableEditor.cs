using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Selectables;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UISelectable), true)]
    public class UISelectableEditor : SelectableEditor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("General", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_uiElement"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_uiDependency"));
            EditorGUILayout.Separator();
            
            GUILayout.Label("Navigation", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Navigation"));
            EditorGUILayout.Separator();
            
            GUILayout.Label("Selection", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_selectBehaviour"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_onSelectUnityEvent"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_onSubmitUnityEvent"));
            EditorGUILayout.Separator();

            serializedObject.ApplyModifiedProperties();
        }
    }

    [CanEditMultipleObjects]
    [CustomEditor(typeof(UISelectableText), true)]
    public class UISelectableTextEditor : UISelectableEditor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Selector Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_selectorOffset"));
            EditorGUILayout.Separator();
            
            base.OnInspectorGUI();
        }
    }
}