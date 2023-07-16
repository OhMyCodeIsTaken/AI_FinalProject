using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private TextMeshProUGUI _bismorAmountText;
    [SerializeField] private TextMeshProUGUI _croppaAmountText;
    [SerializeField] private TextMeshProUGUI _enorAmountText;
    [SerializeField] private TextMeshProUGUI _jadizAmountText;
    [SerializeField] private TextMeshProUGUI _magniteAmountText;
    [SerializeField] private TextMeshProUGUI _umaniteAmountText;

    [SerializeField] private GameObject _darkFilter;
    [SerializeField] private GameObject _buildMenu;



    List<TextMeshProUGUI> _mineralsTexts = new List<TextMeshProUGUI>();

    private void Awake()
    {
        InitMineralsTexts();
        GameManager.Instance.ScoreManager.OnScoreChange += UpdateScoreUI;
    }

    private void UpdateScoreUI(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }

    private void InitMineralsTexts()
    {
        _mineralsTexts.Add(_bismorAmountText);
        _mineralsTexts.Add(_croppaAmountText);
        _mineralsTexts.Add(_enorAmountText);
        _mineralsTexts.Add(_jadizAmountText);
        _mineralsTexts.Add(_magniteAmountText);
        _mineralsTexts.Add(_umaniteAmountText);
    }

    private TextMeshProUGUI GetTextByMineralType(MineralType type)
    {
        return _mineralsTexts[(int)type-1];
    }

    public void UpdateAllMineralUI()
    {
        Mineral playerMineralRef;
        MineralType mineralType;
        for (int i = 1; i <= 6; i++) // 1 - 6 because MineralType goes from 0 to 6, but we want to skip 0 (MineralType.NONE)
        {
            // gets reference to correct mineral from player inventory, using a cast from i
            playerMineralRef = GameManager.Instance.HomePlanet.MineralInventory.Minerals[i-1];
            mineralType = playerMineralRef.MineralType;
            GetTextByMineralType(mineralType).text = playerMineralRef.Amount.ToString();
        }
    }

    public void UpdateMineralText(MineralType mineral, int amount)
    {
        GetTextByMineralType(mineral).text = amount.ToString();
    }

    public void SetDarkFilterVisibility(bool state)
    {
        _darkFilter.SetActive(state);
    }

    public void SetBuildMenuVisibility(bool state)
    {
        _buildMenu.SetActive(state);
        SetDarkFilterVisibility(state);
    }
}
