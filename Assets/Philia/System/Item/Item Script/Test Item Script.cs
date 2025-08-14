using UnityEngine;

public class TestItemScript : ItemDataAbilityBase
{
    protected override void ItemBufferAblilty()
    {
        owner.ApplyStateBouns(new BounsState
        {
            str = 2
        });
    }
}
