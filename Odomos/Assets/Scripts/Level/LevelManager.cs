using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject _upgradesMenu;

    public void CompleteLevel()
    {
        PlayerStats.savedMoney = 1f;
        _upgradesMenu.SetActive(true);
    }

}
