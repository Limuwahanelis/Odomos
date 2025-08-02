#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CopyObjectForwardDir : MonoBehaviour
{
    [SerializeField] Transform _objectToCopy;
    private void Start()
    {
        CopyForwardDir();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.forward = _objectToCopy.forward;
    }

    protected void CopyForwardDir()
    {
        if (_objectToCopy == null) _objectToCopy = Camera.main.transform;
        transform.forward= _objectToCopy.forward;
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(CopyObjectForwardDir))]
    public class CopyObjectForwardDirEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Copy forward dir"))
            {
                (target as CopyObjectForwardDir).CopyForwardDir();
            }
        }
    }
 #endif
}
