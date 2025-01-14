#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Interaction), true)]
public class InteractionDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, label, true);
    }
}

[CustomEditor(typeof(InteractionContainer))]
public class InteractionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InteractionContainer interactionContainer = (InteractionContainer)target;


        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Add default interaction", EditorStyles.boldLabel);
        if (GUILayout.Button("Clear"))
        {
            interactionContainer.defaultInteraction = null;
        }
        if (GUILayout.Button("Set as Chat"))
        {
            interactionContainer.defaultInteraction = new ChatInteraction();
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Add interaction", EditorStyles.boldLabel);
        if (GUILayout.Button("Add Chat"))
        {
            interactionContainer.interactions.Add(new ChatInteraction());
        }
        if (GUILayout.Button("Add Add Item"))
        {
            interactionContainer.interactions.Add(new AddItemInteraction());
        }
        if (GUILayout.Button("Add Ask"))
        {
            interactionContainer.interactions.Add(new AskInteraction());
        }
        if (GUILayout.Button("Add Get Item"))
        {
            interactionContainer.interactions.Add(new GetItemInteraction());
        }
    }
}
#endif
