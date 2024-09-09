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
    }

    public void SelectPerk(Perk perk)
    {
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
        perkPanelObject.SetActive(false);
    }
}
