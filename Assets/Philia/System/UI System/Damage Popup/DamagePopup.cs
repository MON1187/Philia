using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    //Create a Damage Popup UI
    public static DamagePopup Create(Vector3 postion, int damageAmount, bool isCriticalHit)
    {
        Transform transform = Instantiate(GameAssets._i.pfDamagePopup, postion, Quaternion.identity);

        DamagePopup damagePopup = transform.GetComponent<DamagePopup>();

        Debug.Log(damagePopup.gameObject);

        damagePopup.Setup(damageAmount, isCriticalHit);
        return damagePopup;
    }

    private TextMeshPro textMesh;

    private float disapperTimer = .5f;

    private Color textColor;

    private float moveYSpeed = 5f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int amount, bool isCriticalHit)
    {
        textMesh.SetText(amount.ToString());
        if (!isCriticalHit) //Normal Hit
        {
            textMesh.fontSize = 5;
        }
        else //Critial Hit
        {
            textMesh.fontSize = 8;
        }

        textColor = textMesh.color;
        disapperTimer = 1f;
    }

    private void Update()
    {
        transform.position += new Vector3(0, moveYSpeed, 0) * Time.deltaTime;

        disapperTimer -= Time.deltaTime;
        if(disapperTimer < 0)
        {
            //Start disappearing

            float disappearSpeed = 3f;

            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
