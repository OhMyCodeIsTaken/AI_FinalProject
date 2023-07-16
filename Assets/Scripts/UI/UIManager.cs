using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

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
    [SerializeField] private GameObject _upgradeMenu;

    [SerializeField] private TextMeshProUGUI _bismorPriceText;
    [SerializeField] private TextMeshProUGUI _croppaPriceText;
    [SerializeField] private TextMeshProUGUI _enorPriceText;
    [SerializeField] private TextMeshProUGUI _jadizPriceText;
    [SerializeField] private TextMeshProUGUI _magnitePriceText;
    [SerializeField] private TextMeshProUGUI _umanitePriceText;

    List<TextMeshProUGUI> _mineralsTexts = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> _mineralsPriceTexts = new List<TextMeshProUGUI>();

    [SerializeField] private TextMeshProUGUI _speedButtonText;
    [SerializeField] private TextMeshProUGUI _pirateCounterText;
    [SerializeField] private Image _depletingPirateBar;

    private void Awake()
    {
        InitMineralsTexts();
        GameManager.Instance.ScoreManager.OnScoreChange += UpdateScoreUI;
    }

    internal void SetPirateBarCounter(int pirateShipCount)
    {
        _pirateCounterText.text = "x" + pirateShipCount.ToString();
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

        _mineralsPriceTexts.Add(_bismorPriceText);
        _mineralsPriceTexts.Add(_croppaPriceText);
        _mineralsPriceTexts.Add(_enorPriceText);
        _mineralsPriceTexts.Add(_jadizPriceText);
        _mineralsPriceTexts.Add(_magnitePriceText);
        _mineralsPriceTexts.Add(_umanitePriceText);

        DisablePriceVisibility();
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

    public void PresentPrice(Price price)
    {
        TextMeshProUGUI uguiRef;
        foreach (Mineral mineral in price.Minerals)
        {
            uguiRef = _mineralsPriceTexts[(int)mineral.MineralType - 1];
            uguiRef.text = "-" + mineral.Amount.ToString();
            uguiRef.gameObject.SetActive(true);
        }
    }

    public void DisablePriceVisibility()
    {      
        foreach (TextMeshProUGUI priceText in _mineralsPriceTexts)
        {
            priceText.gameObject.SetActive(false);
        }
    }

    public void EnablePriceVisibility()
    {
        foreach (TextMeshProUGUI priceText in _mineralsPriceTexts)
        {
            priceText.gameObject.SetActive(true);
        }
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

    public void SetUpgradeMenuVisibility(bool state)
    {
        _upgradeMenu.SetActive(state);
        SetDarkFilterVisibility(state);
    }

    public void SetSpeedButtonText(string input)
    {
        _speedButtonText.text = input;
    }

    public void SetPirateBarFillValue(float input)
    {
        _depletingPirateBar.fillAmount = input;
    }
}
