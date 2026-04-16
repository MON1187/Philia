using TMPro;
using UnityEngine;

public class CardValueDetail : MonoBehaviour
{
    public TextMeshProUGUI valueText;

    public void SetValue(int value)
    {
        valueText.text = value.ToString();
    }
}
