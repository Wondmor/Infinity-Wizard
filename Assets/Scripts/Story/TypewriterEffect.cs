using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplayAndButtonActivation : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // 文本显示组件
    public Button displayButton; // 文字显示按钮
    public string completeText; // 完整的文本
    public float typingSpeed = 0.1f; // 每个字出现的间隔时间

    private bool isTextFullyDisplayed = false;
    private int currentCharacterIndex = 0;
    private float timer = 0f;

    void Start()
    {
        displayButton.gameObject.SetActive(false); // 初始化时隐藏按钮
    }

    void Update()
    {
        if (!isTextFullyDisplayed)
        {
            timer += Time.deltaTime;

            if (timer >= typingSpeed)
            {
                timer -= typingSpeed;
                currentCharacterIndex++;

                if (currentCharacterIndex <= completeText.Length)
                {
                    textComponent.text = completeText.Substring(0, currentCharacterIndex); // 逐个显示文字
                }
                else
                {
                    isTextFullyDisplayed = true; // 文字已完全显示
                    displayButton.gameObject.SetActive(true); // 显示按钮
                }
            }
        }
    }
}
