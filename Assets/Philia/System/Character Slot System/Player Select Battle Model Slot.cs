using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleModelSlot : MonoBehaviour
{
    [SerializeField] private CharacterSelectionSystem characterSelectionSystem;

    [SerializeField] private Image characterSpritePlace;

    private BattleUnitModel owner;

    [SerializeField] private int index = 0;

    [SerializeField] private bool isSlotLastCheckFunction = false;

    private void Start()
    {
        Button btn = GetComponent<Button>();

        if (!isSlotLastCheckFunction)
        {
            btn.onClick.RemoveAllListeners();

            btn.onClick.AddListener(() => B_SelectCharacter(index));
        }
        else
        {
            SetUiInformation();
        }
    }

    /// <summary>
    /// First of all, it is a bundle of functions that allow you to edit characters anywhere.
    /// </summary>
    /// <param name="location"></param>
    #region Character Slot Function

    public void B_SelectCharacter(int location)
    {
        //First, a code that tells you which cell you selected
        PlayerCharacterSlotManager.Instats.SelectModelLoacation(this ,location);

        //Activates the interface to allow character selection.
        characterSelectionSystem.OnCharacterModelSelectActivate(true);
    }

    public void UpdateSlot(BattleUnitModel _owner)
    {
        owner = _owner;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (owner != null)
        {
            characterSpritePlace.sprite = owner.GetAtmosphericSprite();
        }
    }

    #endregion

    /// <summary>
    /// Perform functions to check the character one last time before battle
    /// </summary>
    #region Last check before fight

    public void SetUiInformation()
    {
        UpdateUiData();
    }

    private void UpdateUiData()
    {
        characterSpritePlace.sprite = owner.GetReadyBattleSprite();
    }

    #endregion
}
