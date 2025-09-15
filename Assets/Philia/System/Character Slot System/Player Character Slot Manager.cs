using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Apple;

public class PlayerCharacterSlotManager : MonoBehaviour
{
    public static PlayerCharacterSlotManager Instats;

    public BattleUnitModel[] battleUnitModels = new BattleUnitModel[4];

    [SerializeField] private CharacterSelectionSystem characterSelectionSystem;

    private CharacterBattleModelSlotData[] characterBattleModelSlotDatas = new CharacterBattleModelSlotData[4];

    private int _location;

    private PlayerBattleModelSlot _curModelSlot;

    private void Awake()
    {
        if (Instats == null)
        {
            Instats = this;
            DontDestroyOnLoad(Instats);
        }
        else
        {
            Destroy(this);
        }
    }

    public void BattleUnitModelSaveSlotData(BattleUnitModel battleUnitModel, int location)
    {
        battleUnitModels[location] = battleUnitModel;
    }

    public BattleUnitModel LoadSlotUnitModelData(int loaction)
    {
        return battleUnitModels[loaction];
    }

#region Functions that are performed while selecting a character

    public void SelectCharacterFinalChoice(BattleUnitModel model)
    {
        _curModelSlot.UpdateSlot(model);

        BattleUnitModelSaveSlotData(model, _location);

        //UI OFF
        characterSelectionSystem.OnCharacterModelSelectActivate(false);

        //reset
        {
            _curModelSlot = null;

            _location = -1;
        }
    }

    public void SelectModelLoacation(PlayerBattleModelSlot slotData,int slotIndedx)
    {
        _curModelSlot = slotData;

        _location = slotIndedx;
    }

    #region Ui Functions

    #endregion

#endregion
}
