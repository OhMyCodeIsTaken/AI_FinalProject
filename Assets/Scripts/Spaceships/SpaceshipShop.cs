using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShop : MonoBehaviour
{
    [SerializeField] private MineralInventory _mineralInventory;

    [SerializeField] private GameObject _miningShipPrefab;
    [SerializeField] private GameObject _securityShipPrefab;

    [SerializeField] private List<Price> _miningShipPrices = new List<Price>();
    [SerializeField] private List<Price> _securityShipPrices = new List<Price>();

    [SerializeField] private Price _planetDetectionUpgradePrice;
    private bool _wasPlanetDetectionUpgradePurchased;
    [SerializeField] private Price _hospitalityUpgradePrice;
    private bool _wasHospitalityUpgradePurchased;

    private GameObject _prefabRef;
    private int _spaceshipTypeCount = -1;
    private List<Price> _pricesRef;
    private Price _priceRef;

    public void AttemptToBuyMiningSpaceship()
    {
        AttemptToBuySpaceship(SpaceshipType.MINER);
    }

    public void AttemptToBuySecuritySpaceship()
    {
        AttemptToBuySpaceship(SpaceshipType.SECURITY);
    }

    private void AttemptToBuySpaceship(SpaceshipType spaceshipType)
    {
        // Checks how many spaceships exist of said type
        _spaceshipTypeCount = GetSpaceshipCountBySpaceshipType(spaceshipType);

        // Which price list are we looking at?
        _pricesRef = GetPricesBySpaceshipType(spaceshipType);

        // player can only have a maximum of 10 Mining Spaceships and 10 Security Spaceships
        if (_spaceshipTypeCount >= _pricesRef.Count)
        {
            Debug.Log("You are at max capicity for this type of spaceship!");
            // Reset all refs (_prefabRef, _priceRef etc...) 
            ResetRefs();
            return;
        }


        // Get specific price by looking at price list accroding to how many spaceships of that type we have (price will increase as you get more spaceships)
        _priceRef = _pricesRef[_spaceshipTypeCount];


        if (DoesPlayerHaveEnoughResourcesToBuyItem(_priceRef))
        {
            _prefabRef = GetPrefabBySpaceshipType(spaceshipType);
            PayForItem(_priceRef);
            Instantiate(_prefabRef);
        }

        // Reset all refs (_prefabRef, _priceRef etc...) 
        ResetRefs();
    }

    private void PayForItem(Price price)
    {
        Mineral mineralInPlayerInventory;
        foreach (Mineral mineral in price.Minerals)
        {
            mineralInPlayerInventory = GameManager.Instance.HomePlanet.MineralInventory.Minerals[((int)mineral.MineralType) - 1];
            _mineralInventory.TransferMineralToInventory(mineralInPlayerInventory, mineral.Amount);
        }
        GameManager.Instance.UIManager.UpdateAllMineralUI();        
    }

    private bool DoesPlayerHaveEnoughResourcesToBuyItem(Price price)
    {
        Mineral mineralInPlayerInventory;
        foreach (Mineral mineral in price.Minerals)
        {
            mineralInPlayerInventory = GameManager.Instance.HomePlanet.MineralInventory.Minerals[((int)mineral.MineralType) - 1];
            
            if (mineral.Amount > mineralInPlayerInventory.Amount) // Cost is too high - player doesnt have enough resources
            {
                return false;
            }
        }

        return true;
    }

    private List<Price> GetPricesBySpaceshipType(SpaceshipType spaceshipType)
    {
        switch (spaceshipType)
        {
            case SpaceshipType.MINER:
                return _miningShipPrices;

            case SpaceshipType.SECURITY:
                return _securityShipPrices;
        }

        throw new Exception("Invalid Spaceship Type: can't get prices!");
    }

    private int GetSpaceshipCountBySpaceshipType(SpaceshipType spaceshipType)
    {
        switch (spaceshipType)
        {
            case SpaceshipType.MINER:
                return GameManager.Instance.MiningShipCount;

            case SpaceshipType.SECURITY:
                return GameManager.Instance.SecurityShipCount;
        }

        throw new Exception("Invalid Spaceship Type: can't count!");
    }

    private GameObject GetPrefabBySpaceshipType(SpaceshipType spaceshipType)
    {
        switch (spaceshipType)
        {
            case SpaceshipType.MINER:
                return _miningShipPrefab;

            case SpaceshipType.SECURITY:
                return _securityShipPrefab;
        }

        throw new Exception("Invalid Spaceship Type: can't get prefab!");
    }

    private void ResetRefs()
    {
        _spaceshipTypeCount = -1;
        _prefabRef = null;
        _pricesRef = null;
        _priceRef = null;
    }

    public void PresentMiningShipPrice()
    {
        // player can only have a maximum of 10 Mining Spaceships
        if (GameManager.Instance.MiningShipCount >= _miningShipPrices.Count)
        {
            Debug.Log("You are at max capicity for this type of spaceship!");
            return;
        }

        Price currentPrice = _miningShipPrices[GameManager.Instance.MiningShipCount];

        GameManager.Instance.UIManager.PresentPrice(currentPrice);
    }

    public void PresentSecurityShipPrice()
    {
        // player can only have a maximum of 10 Security Spaceships
        if (GameManager.Instance.SecurityShipCount >= _securityShipPrices.Count)
        {
            Debug.Log("You are at max capicity for this type of spaceship!");
            return;
        }

        Price currentPrice = _securityShipPrices[GameManager.Instance.SecurityShipCount];

        GameManager.Instance.UIManager.PresentPrice(currentPrice);
    }
    
    public void AttemptToBuyPlanetDetectionUpgrade()
    {
        if(!_wasPlanetDetectionUpgradePurchased && DoesPlayerHaveEnoughResourcesToBuyItem(_planetDetectionUpgradePrice))
        {
            PayForItem(_planetDetectionUpgradePrice);

            _wasPlanetDetectionUpgradePurchased = true;

            foreach (MineralPlanet planet in GameManager.Instance.MineralPlanets)
            {
                planet.SphereCollider.radius += 1;
            }
        }
    }

    public void PresentPlanetDetectionUpgradePrice()
    {
        if(!_wasPlanetDetectionUpgradePurchased)
        {
            GameManager.Instance.UIManager.PresentPrice(_planetDetectionUpgradePrice);
        }
    }

    public void AttemptToBuyHospitalityUpgrade()
    {
        // Hospitality heals spaceships that enter a planet (curerntly only subcribes to Homeworld)
        if (!_wasHospitalityUpgradePurchased && DoesPlayerHaveEnoughResourcesToBuyItem(_hospitalityUpgradePrice))
        {
            PayForItem(_hospitalityUpgradePrice);

            _wasHospitalityUpgradePurchased = true;

            GameManager.Instance.HomePlanet.OnEnteringPlanet += Hospitality;
        }
    }

    public void PresentHospitalityUpgradePrice()
    {
        if (!_wasPlanetDetectionUpgradePurchased)
        {
            GameManager.Instance.UIManager.PresentPrice(_hospitalityUpgradePrice);
        }
    }

    private void Hospitality(Spaceship spaceship)
    {
        spaceship.Damagable.Heal(5);
    }
}
