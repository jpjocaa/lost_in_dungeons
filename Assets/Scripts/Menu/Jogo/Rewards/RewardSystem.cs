using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    
    [SerializeField] private PlayerBaseStats playerStats;
    [SerializeField] private RewardMenu menu;
    [SerializeField] private Health health;

    public void UpgradeDamage()
    {
        playerStats.BaseDamage += 5f;
        Debug.Log("Buff no danoooooo!");
        menu.CloseMenu();
    }

    public void UpgradeSpeed()
    {
        playerStats.MoveSpeed += 0.5f;
        Debug.Log("BUFF NA VELOCIDADE!");
        menu.CloseMenu();
    }

    public void UpgradeMaxHealth()
    {
        playerStats.MaxHealth += 10;
        Debug.Log("BUFF NA VIDAAA!");
        health.Heal(10);
        menu.CloseMenu();
    }

}
