using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ExposedSOAttribute))]
public class ExposedSOAttributeDrawer : PropertyDrawer
{
    private Editor editor = null;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.objectReferenceValue != null)
        {
            Rect foldoutPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(foldoutPosition, property.isExpanded, GUIContent.none);
        }

        EditorGUI.PropertyField(position, property, label, true);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;

            if (editor == null)
                Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);

            editor.OnInspectorGUI();

            EditorGUI.indentLevel--;
        }
    }
}