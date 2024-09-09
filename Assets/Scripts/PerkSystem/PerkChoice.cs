using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkChoice : MonoBehaviour
{
    public Perk perk;
    public Image Icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI levelText;
    public Button perkButton;

    private void Awake()
    {
        perkButton = GetComponent<Button>();
        perkButton.onClick.AddListener(OnPerkSelected);
    }

    public void Setup(int perkLevel)
    {
        Icon.sprite = perk.perkIcon;
        nameText.text = perk.perkName;
        descriptionText.text = perk.perkDescription;
        levelText.text = "Level " + perkLevel;
    }

    private void OnPerkSelected()
    {
        PerkManager.Instance.SelectPerk(perk);
    }

    private void OnDestroy()
    {
        perkButton.onClick.RemoveListener(OnPerkSelected);
    }
}
