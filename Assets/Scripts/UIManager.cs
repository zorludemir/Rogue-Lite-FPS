using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI ammoIndicator;
    public TextMeshProUGUI timeIndicator;
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
}
