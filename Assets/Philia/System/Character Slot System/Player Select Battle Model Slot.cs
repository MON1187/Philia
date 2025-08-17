using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleModelSlot : MonoBehaviour
{
    [SerializeField] private CharacterSelectionSystem characterSelectionSystem;

    [SerializeField] private Image characterSpritePlace;

    private BattleUnitModel owner;

    [SerializeField] private int index = 0;

    private void Start()
    {
        Button btn = GetComponent<Button>();

        btn.onClick.RemoveAllListeners();

        btn.onClick.AddListener(() => B_SelectCharacter(index));
    }

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
}
