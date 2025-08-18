using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LifeManager))]
public class LifeManagerEditor : Editor
{
    LifeManager _target;

    IDamagable iDamagable;

    void OnEnable()
    {
        _target = target as LifeManager;
    }

    public override void OnInspectorGUI()
    {
                iDamagable = _target.gameObject.GetComponent<IDamagable>();

        base.OnInspectorGUI();
        if (iDamagable == null)
            EditorGUILayout.HelpBox("Aucun Script n 'implemente l'interface Idamageable", MessageType.Warning);
            
        
    }
}
