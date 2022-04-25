using UnityEditor;
using EditorUtility = WinuXGames.SplitFramework.Utility.Editor.EditorUtility;

namespace WinuXGames.SplitFramework.UI.Editor
{
    public static class CustomGameObjectMenuItems
    {
        [MenuItem("GameObject/Split Framework/UI/Canvas", priority = 0)]
        private static void CreateUICanvas() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Canvas");
        
        [MenuItem("GameObject/Split Framework/UI/Text", priority = 0)]
        private static void CreateUIText() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Text");
        
        [MenuItem("GameObject/Split Framework/UI/Button", priority = 0)]
        private static void CreateUIButton() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Button");
    }
}