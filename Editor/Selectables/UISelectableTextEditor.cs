using UnityEditor;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Selectables;

namespace WinuXGames.SplitFramework.UI.Editor.Selectables
{
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