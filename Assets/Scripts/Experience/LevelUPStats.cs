using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LevelUPStats : MonoBehaviour
{
    // 等级 经验 显示等级 显示经验
    public int leve1 = 1;
    public float Experience { get; private set; }
    public Text lv1Text;
    public Image expBarImage;
    private SimplePlayerController playerController;

    public GameObject levelUpPanel;

    private Weapon weapon;

    void Start()
    {
        playerController = GetComponent<SimplePlayerController>();
        weapon = GetComponent<Weapon>();
        levelUpPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetExperience(5);
        }
    }


    public static int ExpNeedToLv1UP(int currentLeve1)
    {
        // 如果等于0的经验值等于0 并且增加现在的经验需要的经验
        if (currentLeve1 == 0)
            return 0;
        return (currentLeve1 * currentLeve1 + currentLeve1) * 5;
    }

    public void SetExperience(float exp)
    {
        // 获得经验增加经验 等级经验 
        Experience += exp;
        float expNeeded = ExpNeedToLv1UP(leve1);
        float previousExperience = ExpNeedToLv1UP(leve1 - 1);

        if (Experience >= expNeeded)
        {
            // 经验超过现在经验 升级 重置现在的经验和上一次获得的经验
            Leve1Up();
            expNeeded = ExpNeedToLv1UP(leve1);
            previousExperience = ExpNeedToLv1UP(leve1 - 1);
        }

        // 用以前的经验减去现在获得的经验
        expBarImage.fillAmount = (Experience - previousExperience) / (expNeeded - previousExperience);
        // 当经验满了以后重新开始
        if (expBarImage.fillAmount == 1)
        {
            expBarImage.fillAmount = 0;
        }
    }

    public UnityEvent onLevelUp;

    public void Leve1Up()
    {
        // 等级升级 数字提升
        leve1++;
        lv1Text.text = leve1.ToString("");
        Health.maxHealth += 5;
        Health.currentHealth = Health.maxHealth;

        onLevelUp.Invoke();

        StartCoroutine(ShowLevelUpPanel());
    }

    IEnumerator ShowLevelUpPanel()
    {
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true); // 激活升级面板
        yield return null;
    }
}