using UnityEditor;
using UnityEditor.UI;
using WinuXGames.SplitFramework.UI.UI;

namespace WinuXGames.SplitFramework.UI.Editor.CustomInspectors
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UISelectable))]
    public class UISelectableEditor : SelectableEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_uiDependency"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Navigation"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_onSelectUnityEvent"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_onSubmitUnityEvent"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}