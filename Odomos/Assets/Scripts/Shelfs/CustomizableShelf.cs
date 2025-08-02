using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CustomizableShelf : MonoBehaviour
{
    [SerializeField] public List<GameObject> _itemsOnShelf1Upper= new List<GameObject>();
    [SerializeField] public List<GameObject> _itemsOnShelf1Lower = new List<GameObject>();
    [SerializeField] public List<GameObject> _itemsOnShelf2Upper = new List<GameObject>();
    [SerializeField] public List<GameObject> _itemsOnShelf2Lower = new List<GameObject>();
    [SerializeField] int _shelf1UpperItemIndex=0;
    [SerializeField] int _shelf1LoweritemIndex = 0;
    [SerializeField] int _shelf2UpperItemIndex=0;
    [SerializeField] int _shelf2lowerItemIndex = 0;

    public void SetItems1UpperVisibility()
    {
        
        foreach (var item in _itemsOnShelf1Upper)
        {
            item.gameObject.SetActive(false);
        }
        if(_shelf1UpperItemIndex >= 0) _itemsOnShelf1Upper[_shelf1UpperItemIndex].SetActive(true);
    }
    public void SetItems1LowerVisibility()
    {
        foreach (var item in _itemsOnShelf1Lower)
        {
            item.gameObject.SetActive(false);
        }
        if (_shelf1LoweritemIndex >= 0) _itemsOnShelf1Lower[_shelf1LoweritemIndex].SetActive(true);
    }

    public void SetItems2UpperVisibility()
    {
        foreach (var item in _itemsOnShelf2Upper)
        {
            item.gameObject.SetActive(false);
        }
        if (_shelf2UpperItemIndex >= 0) _itemsOnShelf2Upper[_shelf2UpperItemIndex].SetActive(true);
    }

    public void SetItems2LowerVisibility()
    {
        foreach (var item in _itemsOnShelf2Lower)
        {
            item.gameObject.SetActive(false);
        }
        if (_shelf2lowerItemIndex >= 0 && _shelf2lowerItemIndex< _itemsOnShelf2Lower.Count) _itemsOnShelf2Lower[_shelf2lowerItemIndex].SetActive(true);
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(CustomizableShelf))]
public class CustomizableShlefEditor:Editor
{
    private CustomizableShelf _target;
    SerializedProperty _shelf1UpperItemIndex;
    SerializedProperty _shelf1LoweritemIndex;
    SerializedProperty _shelf2UpperItemIndex;
    SerializedProperty _shelf2lowerItemIndex;

    SerializedProperty _itemsOnShelf1Upper;
    SerializedProperty _itemsOnShelf1Lower;
    SerializedProperty _itemsOnShelf2Upper;
    SerializedProperty _itemsOnShelf2Lower;
    private void OnEnable()
    {
        _target = (CustomizableShelf)target;
        _shelf1UpperItemIndex = serializedObject.FindProperty("_shelf1UpperItemIndex");
        _shelf1LoweritemIndex = serializedObject.FindProperty("_shelf1LoweritemIndex");
        _shelf2UpperItemIndex = serializedObject.FindProperty("_shelf2UpperItemIndex");
        _shelf2lowerItemIndex = serializedObject.FindProperty("_shelf2lowerItemIndex");

        _itemsOnShelf1Upper = serializedObject.FindProperty("_itemsOnShelf1Upper");
        _itemsOnShelf1Lower = serializedObject.FindProperty("_itemsOnShelf1Lower");
        _itemsOnShelf2Upper = serializedObject.FindProperty("_itemsOnShelf2Upper");
        _itemsOnShelf2Lower = serializedObject.FindProperty("_itemsOnShelf2Lower");
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(_shelf1UpperItemIndex);
        EditorGUILayout.PropertyField(_shelf1LoweritemIndex);
        EditorGUILayout.PropertyField(_shelf2UpperItemIndex);
        EditorGUILayout.PropertyField(_shelf2lowerItemIndex);

        EditorGUILayout.PropertyField(_itemsOnShelf1Upper);
        EditorGUILayout.PropertyField(_itemsOnShelf1Lower);
        EditorGUILayout.PropertyField(_itemsOnShelf2Upper);
        EditorGUILayout.PropertyField(_itemsOnShelf2Lower);

        if (_shelf2lowerItemIndex.intValue >= _itemsOnShelf2Lower.arraySize) _shelf2lowerItemIndex.intValue = _itemsOnShelf2Lower.arraySize - 1;

        if (_itemsOnShelf1Upper.arraySize > 1) _target.SetItems1UpperVisibility();
        if (_itemsOnShelf1Lower.arraySize > 1) _target.SetItems1LowerVisibility();
        if (_itemsOnShelf2Upper.arraySize > 1) _target.SetItems2UpperVisibility();
        if (_itemsOnShelf2Lower.arraySize > 1) _target.SetItems2LowerVisibility();
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
