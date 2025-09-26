using UnityEngine;

public class CharcaterSlotFinalConfirmation : MonoBehaviour
{
    [SerializeField] private PlayerBattleModelSlot[] charcaterSlots = new PlayerBattleModelSlot[4];

    [SerializeField] private BattleUnitModel[] owner = new BattleUnitModel[4];
    /// <summary>
    /// Function set up for temporary testing
    /// </summary>
    public void B_OnSlotFinalConfirmation()
    {
        UpdateSlotData();

        OnSlotFinalConfirmation();
    }

    public void OnSlotFinalConfirmation()
    {
        int i = 0;
        foreach (PlayerBattleModelSlot slot in charcaterSlots)
        {
            try
            {
                slot.UpdateOnwer(owner[i++]);
                slot.SetUiInformation();
            }
            catch
            {
                Debug.Log("NULL Image");
            }
        }
    }

    private void UpdateSlotData()
    {
        owner = PlayerCharacterSlotManager.Instats.LoadAllSlotInitModelData();
    }
}
