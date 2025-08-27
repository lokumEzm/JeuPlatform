using UnityEngine;

[CreateAssetMenu(fileName = "LightningScriptable", menuName = "Scriptable Objects/LightningScriptable", order = 1)]
public class LightningScriptable : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
}
