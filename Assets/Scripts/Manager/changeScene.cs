using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{

    public string select;
    // 在Unity中设置按钮的OnClick事件，将这个函数与按钮的OnClick关联
    public void OnButtonClick()
    {
        // 切换到Scene2
        SceneManager.LoadScene(select);
    }
    public void QuitGame()
    {
        // 在编辑器中，使用UnityEditor.EditorApplication.isPlaying = false退出游戏
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在游戏中，使用Application.Quit()退出游戏
        Application.Quit();
#endif
    }
}
