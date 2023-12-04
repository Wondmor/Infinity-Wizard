using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public Button targetButton1; 

    public Button targetButton2; 
        private Color HexToColor(string hex)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
    public void OnButtonClick1()
    {
        // 获取Button中的Image组件
        Image buttonImage1 = targetButton1.GetComponent<Image>();
        Image buttonImage2 = targetButton2.GetComponent<Image>();

        // 将Image组件的颜色设置为纯白

            buttonImage1.color = Color.white;
            PlayerPrefs.SetString("CharacterName", "1");
            if(buttonImage2.color  == Color.white)
            {
                buttonImage2.color=HexToColor("#606163");
            }
    }
        public void OnButtonClick2()
    {
        // 获取Button中的Image组件
        Image buttonImage1 = targetButton1.GetComponent<Image>();
        Image buttonImage2 = targetButton2.GetComponent<Image>();

        // 将Image组件的颜色设置为纯白
            PlayerPrefs.SetString("CharacterName", "2");
            buttonImage2.color = Color.white;
            if(buttonImage1.color  == Color.white)
            {
                buttonImage1.color=HexToColor("#606163");
            }
    }
}