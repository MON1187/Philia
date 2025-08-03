using UnityEngine;

public class StoreSystem : MonoBehaviour
{
    public int maxSellSlot;

    public float lowProbability;       //3급 아이템 등장 확률 : 기본 0.72%(1%중)

    public float middleProbability;     //2급 아이템 등장 확률 : 기본 0.25%(1%중)

    public float advancedProbability;       //1급 아이템 등장 확률 : 기본 0.03%(1%중);

    public ItemDataAbilityBase[] sellItemSlolt;


    public void ResetItemDisplaySlot()
    {
        ResetItemSlot();
    }

    private void ResetItemSlot()
    {
        sellItemSlolt = new ItemDataAbilityBase[maxSellSlot];

        for(int i = 0; i < maxSellSlot; i++)
        {
            //아이템 슬롯 랜덤 저장 하는 코드 작성
            //sellItemSlolt[i] = 
        }
    }

    
}
