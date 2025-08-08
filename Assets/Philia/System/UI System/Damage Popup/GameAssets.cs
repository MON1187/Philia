using Unity.VisualScripting;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets _i;

    private void Awake()
    {
        _i = this;
    }

    public Transform pfDamagePopup;
}
