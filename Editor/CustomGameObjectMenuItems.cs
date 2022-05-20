using UnityEditor;
using EditorUtility = WinuXGames.SplitFramework.Utility.Editor.EditorUtility;

namespace WinuXGames.SplitFramework.UI.Editor
{
    public static class CustomGameObjectMenuItems
    {
        [MenuItem("GameObject/Split Framework/UI/Manager", priority = 0)]
        private static void CreateUIManager() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/MAN_UI");
        
        
        [MenuItem("GameObject/Split Framework/UI/Canvas/Default", priority = 1)]
        private static void CreateUICanvasDefault() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Canvas/CanvasDefault");


        [MenuItem("GameObject/Split Framework/UI/Canvas/Default WorldSpace", priority = 1)]
        private static void CreateUICanvasDefaultWorldSpace() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Canvas/CanvasDefaultWorldSpace");
        
        
        [MenuItem("GameObject/Split Framework/UI/Image", priority = 2)]
        private static void CreateUIImage() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Image");
        
        
        [MenuItem("GameObject/Split Framework/UI/Panel/Default Big", priority = 3)]
        private static void CreateUIPanelDefaultBig() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Panel/PanelDefaultBig");
        
        
        [MenuItem("GameObject/Split Framework/UI/Panel/Default Small", priority = 3)]
        private static void CreateUIPanelDefaultSmall() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Panel/PanelDefaultSmall");
        
        
        [MenuItem("GameObject/Split Framework/UI/Text/Default Big", priority = 4)]
        private static void CreateUITextDefaultBig() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Text/TextDefaultBig");


        [MenuItem("GameObject/Split Framework/UI/Text/Default Small", priority = 4)]
        private static void CreateUITextDefaultSmall() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Text/TextDefaultSmall");


        [MenuItem("GameObject/Split Framework/UI/Button/Default Big", priority = 5)]
        private static void CreateUIButtonDefaultBig() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Button/ButtonDefaultBig");


        [MenuItem("GameObject/Split Framework/UI/Button/Default Small", priority = 5)]
        private static void CreateUIButtonDefaultSmall() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/Button/ButtonDefaultSmall");


        [MenuItem("GameObject/Split Framework/UI/InputField/Default", priority = 6)]
        private static void CreateUIInputFieldDefault() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/InputField/InputFieldDefault");
        
        
        [MenuItem("GameObject/Split Framework/UI/MenuPointList/Default", priority = 7)]
        private static void CreateUIMenuPointList() => EditorUtility.InstantiatePrefabFromResources("GameObjectMenuItemPresets/UI/MenuPointList/MenuPointListDefault");
    }
}