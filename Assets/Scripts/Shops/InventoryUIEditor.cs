using UnityEditor;

[CustomEditor(typeof(InventoryUI))]
public class InventoryUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var inventoryType = serializedObject.FindProperty("inventoryType");
        var food = serializedObject.FindProperty("food");
        var skillLevel = serializedObject.FindProperty("skillLevel");
        var countText = serializedObject.FindProperty("countText");

        EditorGUILayout.PropertyField(inventoryType);

        if (inventoryType.enumValueIndex == (int)InventoryUI.InventoryType.Food)
            EditorGUILayout.PropertyField(food);
        else EditorGUILayout.PropertyField(skillLevel);

        EditorGUILayout.PropertyField(countText);
        serializedObject.ApplyModifiedProperties();
    }
}