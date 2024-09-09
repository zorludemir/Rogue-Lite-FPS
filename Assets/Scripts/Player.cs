using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float maxHealth;
    public float healthRegeneration;

    public float movementSpeed;

    public float damage;
    public float fireRate;
    public float fireRange;

    public float xpMultiplier;
    public float goldMultiplier;

    
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }
}
