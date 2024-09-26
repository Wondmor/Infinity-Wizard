//==============================================================
// Demo Buttons
//==============================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ClearSky
{
    public class Demo : MonoBehaviour
    {
   
        public void Revive()
        {
            
        }
        public void RestartGame() // 处理重新开始游戏的代码
        {
            SceneManager.LoadScene("Select_character"); // 加载主游戏场景
        }

        public void QuitGame() // 处理退出游戏的代码
        {
            Application.Quit(); // 关闭游戏
        }
    }
}
