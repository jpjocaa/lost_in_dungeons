using UnityEngine;

public class RewardMenu : MonoBehaviour
{
    [SerializeField] private GameObject rewardPanel;

    private bool MenuAberto;

    public void OpenMenu()
    {

        if(MenuAberto) return;

        MenuAberto = true;
        
        rewardPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        rewardPanel.SetActive(false);
        MenuAberto = false;
        Time.timeScale = 1f;
    }
}
