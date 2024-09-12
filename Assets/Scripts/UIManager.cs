using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI ammoIndicator;
    public TextMeshProUGUI timeIndicator;

    public Image xpIndicator;
    public Image healthIndicator;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateXPIndicator();
        UpdateHealthIndicator();
    }
    public void UpdateAmmoIndicator(bool isReloading)
    {
        if (isReloading) 
        {
            ammoIndicator.text = "Reloading...";
        }
        else 
        {
            ammoIndicator.text = PlayerShoot.Instance.currentAmmo.ToString();
        }
    }
    public void UpdateTimeIndicator(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timeIndicator.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void UpdateHealthIndicator()
    {
        healthIndicator.fillAmount = 
            Player.Instance.currentHealth / Player.Instance.CalculateMaxHealth();
    }
    public void UpdateXPIndicator()
    {
        float xp = Player.Instance.currentXP;
        float maxxp = Player.Instance.xpToLevelUp;

        xpIndicator.fillAmount = xp/maxxp;
    }
}
