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

    public string perkDescription;
}
