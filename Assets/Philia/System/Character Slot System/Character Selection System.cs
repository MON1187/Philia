using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionSystem : MonoBehaviour
{
    [SerializeField] private GameObject slotDataUIAssets;

    [SerializeField] private GameObject charactermodelSelectUI;

    [SerializeField] private Transform creationLocation;

    private List<CharacterBattleModelSlotData> modedSlotData = new List<CharacterBattleModelSlotData>();

    public void UpdateSlotLevel()
    {
        
    }

    public void OnCharacterModelSelectActivate(bool isAcvive)
    {
        charactermodelSelectUI.SetActive(isAcvive);
    }
}
