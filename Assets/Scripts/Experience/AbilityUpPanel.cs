using System;
using UnityEngine.Events;
using UnityEngine;

public class AbilityUpPanel : MonoBehaviour
{
    public GameObject abilityUpPanel;
    public LevelUPStats levelUpStats;
    public Weapon weapon;
    private bool isGamePaused = false;
    private void OnEnable()
    {
        levelUpStats.onLevelUp.AddListener(AbilityUp);
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        levelUpStats = player.GetComponent<LevelUPStats>();
        weapon = player.GetComponent<Weapon>();

        // 检测暂停/恢复游戏的输入
        if (Input.GetKeyDown(KeyCode.I))
        {
            TogglePauseGame();
        }
    }
    void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        // 切换游戏暂停状态
        if (isGamePaused)
        {
            // 暂停游戏
            Time.timeScale = 0f;
        }
        else
        {
            // 恢复游戏
            Time.timeScale = 1f;
        }
    }
    private void AbilityUp()
    {
        Time.timeScale = 0f;
        abilityUpPanel.SetActive(true);
    }

    public void ProjectileNumberUp()
    {

        weapon.projectileNumber += 1;
        abilityUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void ProjectileSpeedUp()
    {

        weapon.projectileSpeed += 1;
        abilityUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AttackSpeedUp()
    {

        weapon.attackSpeed += 0.5f;
        abilityUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void AttackDamageUp()
    {
      
        weapon.attackDamage += 1;
        abilityUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
