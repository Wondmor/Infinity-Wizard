using System;
using UnityEngine.Events;
using UnityEngine;

public class AbilityUpPanel : MonoBehaviour
{
    public GameObject abilityUpPanel;
    public LevelUPStats levelUpStats;
    public Weapon weapon;
    private void OnEnable()
    {
        
        levelUpStats.onLevelUp.AddListener(AbilityUp);
    }

    private void AbilityUp()
    {
        abilityUpPanel.SetActive(true);
    }

    public void ProjectileNumberUp()
    {
        weapon.projectileNumber += 1;
        abilityUpPanel.SetActive(false);
    }
    
    public void ProjectileSpeedUp()
    {
        weapon.projectileSpeed += 1;
        abilityUpPanel.SetActive(false);
    }

    public void AttackSpeedUp()
    {
        weapon.attackSpeed += 0.5f;
        abilityUpPanel.SetActive(false);
    }
    
    public void AttackDamageUp()
    {
        weapon.attackDamage += 1;
        abilityUpPanel.SetActive(false);
    }
}
