using UnityEngine;
using UnityEngine.UI;

public class SettingSystem : MonoBehaviour
{
    public static SettingSystem Instance;

    [SerializeField] private Toggle _damagePopupActivate;

    private bool isDamagePopup { get => _damagePopupActivate.isOn; }

    public GameObject settingObj;

    public GameObject[] selectSettingButtons;

    private GameObject curSelectButton = default;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        curSelectButton = selectSettingButtons[0];
    }


    //Number 1
    #region Battle Related features || Application settings
     
    public void OnAplicationSettings()
    {
        if (curSelectButton != null)
        {
            curSelectButton.SetActive(false);
        }

        selectSettingButtons[0].SetActive(true);
        curSelectButton = selectSettingButtons[0];
    }

    public void B_IsDamagePopupActiveate()
    {
        //do Why?
    }

    #endregion


    //Number 2
    #region Audio
    public void OnAudioSettings()
    {
        if (curSelectButton != null)
        {
            curSelectButton.SetActive(false);
        }

        selectSettingButtons[1].SetActive(true);

        curSelectButton = selectSettingButtons[1];
    }


    #endregion


    //Number 3
    #region Graphics
    public void OnGraphicsSettings()
    {
        if (curSelectButton != null)
        {
            curSelectButton.SetActive(false);
        }

        selectSettingButtons[2].SetActive(true);

        curSelectButton = selectSettingButtons[2];
    }


    #endregion

    #region Other

    public void B_CloseSettingUI()
    {
        //초기화 작업
        {
            curSelectButton.SetActive(false);

            curSelectButton = selectSettingButtons[0];

            curSelectButton.SetActive(true);
        }

        settingObj.SetActive(false);
    }

    public void OnSettingUI()
    {
        if(settingObj != null)
        {
            settingObj.SetActive(true);
        }
    }

    #endregion
}
