using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenSystem : MonoBehaviour
{
    [SerializeField] private string loadFirstGameScene;

    public void B_StartGame()
    {
        //When you need to create a loading screen later, modify it to an asynchronous scene and work on it.
        SceneManager.LoadScene(loadFirstGameScene);
    }

    public void B_Setting()
    {
        SettingSystem.Instance.OnSettingUI();
    }

    public void B_ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
