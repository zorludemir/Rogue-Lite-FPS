using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Upgrade Variables")]
    public int maxHealth;
    public int healthRegeneration;

    public int movementSpeed;

    public int damage;
    public int fireRate;
    public int bulletSpeed;
    public int reloadSpeed;
    public int ammoCapacity;

    public int xpMultiplier;
    public int goldMultiplier;

    [Header("Passive Variables")]
    public int lifeSteal;
    public int ignite;

    [Header("Ingame Variables")]
    public float currentHealth;
    public float currentXP;
    public float currentGold;
    public float xpToLevelUp;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        currentHealth = CalculateMaxHealth();
    }
    private void Start()
    {
        StartCoroutine(RegenerateHealth());
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
    public void IncreaseXP(float amount)
    {
        currentXP += amount * CalculateXPMultiplier();
        if (currentXP >= xpToLevelUp)
        {
            PerkManager.Instance.ShowPerk();
            currentXP -= xpToLevelUp;
            xpToLevelUp += 15;
            UIManager.Instance.UpdateXPIndicator();
        }
        UIManager.Instance.UpdateXPIndicator();
    }
    public void IncreaseGold(float amount)
    {
        currentGold += amount * CalculateGoldMultiplier();
    }
    public IEnumerator RegenerateHealth()
    {
        while (true)
        {
            currentHealth += CalculateHealthRegeneration();
            if (currentHealth >= CalculateMaxHealth()) { currentHealth = CalculateMaxHealth(); }
            UIManager.Instance.UpdateHealthIndicator();
            yield return new WaitForSeconds(1);
        }
    }
    #region Calculations
    public float CalculateDamage()
    {
        return PlayerShoot.Instance.weapon.weaponDamage + damage * 3;
    }
    public float CalculateFireRate()
    {
        return PlayerShoot.Instance.weapon.weaponFireRate + fireRate * 3;
    }
    public float CalculateBulletSpeed()
    {
        return PlayerShoot.Instance.weapon.weaponBulletSpeed + bulletSpeed * 10;
    }
    public float CalculateMaxHealth()
    {
        return 100 + maxHealth * 20;
    }
    public float CalculateHealthRegeneration()
    {
        return 1 + healthRegeneration;
    }
    public float CalculateMovementSpeed()
    {
        return 5 + movementSpeed;
    }
    public int CalculateAmmoCapacity()
    {
        return PlayerShoot.Instance.weapon.weaponAmmoCapacity + ammoCapacity * 2;
    }
    public float CalculateReloadSpeed()
    {
        float baseReloadTime = PlayerShoot.Instance.weapon.weaponReloadSpeed;
        float modifier = reloadSpeed * 0.1f;

        return Mathf.Max(0.5f, baseReloadTime / (1 + modifier));
    }
    public float CalculateXPMultiplier()
    {
        return 1f + xpMultiplier / 5f;
    }
    public float CalculateGoldMultiplier()
    {
        return 1f + goldMultiplier / 5f;
    }
    #endregion
}
