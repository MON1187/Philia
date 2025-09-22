using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionSystem : MonoBehaviour
{
    [SerializeField] private GameObject slotDataUIAssets;

    [SerializeField] private GameObject characterModelSelectUI;

    [SerializeField] private Button characterModeButton;

    [SerializeField] private Transform creationLocation;

    private List<CharacterBattleModelSlotData> modedSlotData = new List<CharacterBattleModelSlotData>();

    private void Awake()
    {
        characterModeButton.onClick.RemoveAllListeners();

        characterModeButton.onClick.AddListener(() => OnCharacterModelSelectActivate(false));
    }

    public void UpdateSlotLevel()
    {
        
    }

    public void OnCharacterModelSelectActivate(bool isAcvive)
    {
        characterModelSelectUI.SetActive(isAcvive);
    }
}
