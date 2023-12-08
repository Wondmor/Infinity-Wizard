using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplayAndButtonActivation : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // �ı���ʾ���
    public Button displayButton; // ������ʾ��ť
    public string completeText; // �������ı�
    public float typingSpeed = 0.1f; // ÿ���ֳ��ֵļ��ʱ��

    private bool isTextFullyDisplayed = false;
    private int currentCharacterIndex = 0;
    private float timer = 0f;

    void Start()
    {
        displayButton.gameObject.SetActive(false); // ��ʼ��ʱ���ذ�ť
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
                    textComponent.text = completeText.Substring(0, currentCharacterIndex); // �����ʾ����
                }
                else
                {
                    isTextFullyDisplayed = true; // ��������ȫ��ʾ
                    displayButton.gameObject.SetActive(true); // ��ʾ��ť
                }
            }
        }
    }
}
