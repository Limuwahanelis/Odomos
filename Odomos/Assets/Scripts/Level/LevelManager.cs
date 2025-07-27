using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PauseSetter _pauseSetter;
    [SerializeField] GameEventSO _startLevelEvent;
    [SerializeField] LevelInfoSO _levelInfoSO;
    [SerializeField] GameObject _upgradesMenu;
    [SerializeField] GameObject _completeLevelPanel;
    [SerializeField] TMP_Text _remainingMoneyTextField;
    [SerializeField] TMP_Text _levelCompleteMoneyTextField;
    [SerializeField] TMP_Text _quaterBonusMoneyTextField;
    [SerializeField] TMP_Text _totalMoneyTextField;
    [SerializeField] TMP_Text _timeBonusMoneyTextField;
    [SerializeField] Image _timerImg;
    [SerializeField] GameObject _clock;
    [SerializeField] GameObject _upgradesPanel;
    [SerializeField] GameObject _shoppingListPanel;
    [SerializeField] GameObject _playerInfoPanel;
    private float _time;
    private bool _countTime = true;
    private void Awake()
    {
        PlayerStats.currentMoney = 1f;
        _pauseSetter.SetForcedPause(true);
        _countTime = false;
        _timerImg.fillAmount = 0;
    }
    public void StartLevel()
    {
        _pauseSetter.SetForcedPause(false);
        _upgradesPanel.SetActive(false);
        _timerImg.gameObject.SetActive(true);
        _shoppingListPanel.SetActive(true);
        _playerInfoPanel.SetActive(true);
        _clock.SetActive(true);
        _countTime = true;
        _startLevelEvent?.Raise();
    }
    public void CompleteLevel()
    {
        _pauseSetter.SetForcedPause(true);
        _countTime = false;
        _completeLevelPanel.SetActive(true);
        _remainingMoneyTextField.text = PlayerStats.currentMoney.ToString();
        _levelCompleteMoneyTextField.text = _levelInfoSO.FlatLevelBonus.ToString();
        int quater = (int)(_time / 15);
        _quaterBonusMoneyTextField.text = _levelInfoSO.QuaterBonuses[quater].ToString();

        float moneyEarned = PlayerStats.currentMoney + _levelInfoSO.FlatLevelBonus + _levelInfoSO.QuaterBonuses[quater];
        PlayerStats.savedMoney +=moneyEarned;
    }
    private void Update()
    {
        if (_countTime)
        {
            _time += Time.deltaTime;
            _timerImg.fillAmount = _time / 60;
        }
    }

}
