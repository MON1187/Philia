using UnityEngine;

public class StoreSystem : MonoBehaviour
{
    public int maxSellSlot;

    public float lowProbability;       //3�� ������ ���� Ȯ�� : �⺻ 0.72%(1%��)

    public float middleProbability;     //2�� ������ ���� Ȯ�� : �⺻ 0.25%(1%��)

    public float advancedProbability;       //1�� ������ ���� Ȯ�� : �⺻ 0.03%(1%��);

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
            //������ ���� ���� ���� �ϴ� �ڵ� �ۼ�
            //sellItemSlolt[i] = 
        }
    }

    
}
