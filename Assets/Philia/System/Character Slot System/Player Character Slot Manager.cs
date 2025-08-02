using UnityEngine;

public class PlayerCharacterSlotManager : MonoBehaviour
{
    public BattleUnitModel[] battleUnitModels = new BattleUnitModel[4];

    public void BattleUnitModelSaveSlotData(BattleUnitModel battleUnitModel, int location)
    {
        battleUnitModels[location] = battleUnitModel;
    }

    public BattleUnitModel LoadSlotUnitModelData(int loaction)
    {
        return battleUnitModels[loaction];
    }
}
