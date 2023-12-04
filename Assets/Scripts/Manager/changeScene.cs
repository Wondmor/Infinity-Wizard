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
}
