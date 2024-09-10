using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : SerializedScriptableObject
{
    public int weaponID;
    public string weaponName;
    [PreviewField(height: 60), HideLabel]
    public Sprite weaponIcon;

    public float weaponDamage;
    public float weaponFireRate;
    public float weaponBulletSpeed;
    public int weaponAmmoCapacity;
    public float weaponReloadSpeed;
    public string weaponDescription;
    public GameObject weaponModel;
    public GameObject bullet;
}
