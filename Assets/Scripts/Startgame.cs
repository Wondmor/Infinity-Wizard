using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    // 在Unity中设置按钮的OnClick事件，将这个函数与按钮的OnClick关联
    public void OnStartGameButtonClick()
    {
        // 切换到Scene2
        SceneManager.LoadScene("Map_cyl");
    }
}
