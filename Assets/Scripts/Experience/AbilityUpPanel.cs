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
        // 检测暂停/恢复游戏的输入
        if (Input.GetKeyDown(KeyCode.P))
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
        TogglePauseGame();
        abilityUpPanel.SetActive(true);
    }

    public void ProjectileNumberUp()
    {
        weapon.projectileNumber += 1;
        abilityUpPanel.SetActive(false);
        TogglePauseGame();
    }
    
    public void ProjectileSpeedUp()
    {
        weapon.projectileSpeed += 1;
        abilityUpPanel.SetActive(false);
        TogglePauseGame();
    }

    public void AttackSpeedUp()
    {
        weapon.attackSpeed += 0.5f;
        abilityUpPanel.SetActive(false);
        TogglePauseGame();
    }
    
    public void AttackDamageUp()
    {
        weapon.attackDamage += 1;
        abilityUpPanel.SetActive(false);
        TogglePauseGame();
    }
}
