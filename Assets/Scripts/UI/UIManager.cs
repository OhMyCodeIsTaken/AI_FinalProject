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

    public void UpdateMineralText(MineralType mineral, int amount)
    {
        GetTextByMineralType(mineral).text = amount.ToString();
    }
}
