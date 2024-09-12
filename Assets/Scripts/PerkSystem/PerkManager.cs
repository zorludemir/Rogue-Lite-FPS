using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkManager : MonoBehaviour
{
    public static PerkManager Instance;
    [SerializeField] private List<Perk> perkDatabase;
    [SerializeField] private Dictionary<Perk, int> activePerks = new Dictionary<Perk, int>();
    [SerializeField] private GameObject perkPanelObject;
    [SerializeField] private GameObject perkObject;
    [SerializeField] private Transform perkContainer;

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
        perkPanelObject.SetActive(false);
    }

    public void ShowPerk()
    {
        perkPanelObject.SetActive(true);

        foreach (Transform child in perkContainer)
        {
            Destroy(child.gameObject);
        }

        List<Perk> availablePerks = perkDatabase.FindAll(p => !activePerks.ContainsKey(p) || (activePerks.ContainsKey(p) && activePerks[p] < 5));
        for (int i = 0; i < 3 && availablePerks.Count > 0; i++)
        {
            Perk randomPerk = availablePerks[Random.Range(0, availablePerks.Count)];
            availablePerks.Remove(randomPerk);

            GameObject newPerk = Instantiate(perkObject, perkContainer);
            PerkChoice perkChoice = newPerk.GetComponent<PerkChoice>();
            perkChoice.perk = randomPerk;
            perkChoice.Setup(activePerks.ContainsKey(randomPerk) ? activePerks[randomPerk] : 0);
        }
        CameraLook.ChangeCursorLockState(false);
        Time.timeScale = 0;
    }

    public void SelectPerk(Perk perk)
    {
        CameraLook.ChangeCursorLockState(true);
        Time.timeScale = 1;

        if (activePerks.ContainsKey(perk))
        {
            if (activePerks[perk] < 5)
            {
                activePerks[perk]++;
            }
        }
        else
        {
            activePerks[perk] = 1;
        }

        ApplyPerkEffect(perk);

        perkPanelObject.SetActive(false);
    }

    private void ApplyPerkEffect(Perk perk)
    {
        switch (perk.perkID)
        {
            case 0:
                Player.Instance.bulletSpeed++;
                break;
            case 1:
                Player.Instance.damage++;
                break;
            case 2:
                Player.Instance.fireRate++;
                break;
            case 3:
                Player.Instance.goldMultiplier++;
                break;
            case 4:
                Player.Instance.healthRegeneration++;
                break;
            case 5:
                Player.Instance.maxHealth++;
                break;
            case 6:
                Player.Instance.movementSpeed++;
                break;
            case 7:
                Player.Instance.reloadSpeed++;
                break;
            case 8:
                Player.Instance.ammoCapacity++;
                break;
            case 9:
                Player.Instance.xpMultiplier++;
                break;
            case 10:
                Player.Instance.lifeSteal++;
                break;
            case 11:
                Player.Instance.ignite++;
                break;
            default:
                Debug.LogWarning("Unknown perk: " + perk.perkName);
                break;
        }
    }
}
