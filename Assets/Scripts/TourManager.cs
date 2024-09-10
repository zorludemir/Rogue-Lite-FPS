using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourManager : MonoBehaviour
{
    public static TourManager Instance;
    public float gameTime;

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
        StartCoroutine(IncreaseTime());
    }
    private IEnumerator IncreaseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameTime++;
            UIManager.Instance.UpdateTimeIndicator(gameTime);
        }
    }
}
