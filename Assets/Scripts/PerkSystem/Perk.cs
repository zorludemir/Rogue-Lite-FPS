using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu()]
[InlineEditor]
public class Perk : SerializedScriptableObject
{
    public int perkID;
    public string perkName;
    [PreviewField(height: 60), HideLabel]
    public Sprite perkIcon;

    [LabelWidth(100)]
    public string perkDescription;
    public bool isUpgraded;
    public int needToUpgradePerkID;
    public enum Type
    {
        Upgrade,
        Skill,
        Passive,
    }
    public Type type;

}
