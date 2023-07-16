using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private HomePlanet _homePlanet;
    [SerializeField] private List<MineralPlanet> _mineralPlanets = new List<MineralPlanet>();
    [SerializeField] private List<PiratePlanet> _piratePlanets = new List<PiratePlanet>();
    private System.Random rand = new System.Random();
    private int randomIndex;

    private bool _isGameSpeedSpedUp = false;
    [SerializeField] private float _gameSpeedMultiplier = 3;

   public HomePlanet HomePlanet { get => _homePlanet;}

    [SerializeField] private int _miningShipCount;
    [SerializeField] private int _pirateShipCount;
    [SerializeField] private int _securityShipCount;

    public List<MineralPlanet> MineralPlanets { get => _mineralPlanets; }
    public List<PiratePlanet> PiratePlanets { get => _piratePlanets; set => _piratePlanets = value; }
    public Camera MainCamera { get => _mainCamera;}
    public ScoreManager ScoreManager { get => _scoreManager; }
    public UIManager UIManager { get => _uiManager; }
    public int MiningShipCount { get => _miningShipCount; set => _miningShipCount = value; }
    public int SecurityShipCount { get => _securityShipCount; set => _securityShipCount = value; }

    public PiratePlanet GetRandomPiratePlanet()
    {
        randomIndex = rand.Next(0, PiratePlanets.Count);
        return PiratePlanets[randomIndex];
    }

    private MineralPlanet GetRandomMineralPlanet()
    {
        randomIndex = rand.Next(0, MineralPlanets.Count);
        return MineralPlanets[randomIndex];
    }

    public void ChangeSpaceshipCountByType(SpaceshipType spaceshipType, int amountToAdd)
    {
        switch (spaceshipType)
        {
            case SpaceshipType.MINER:
                _miningShipCount += amountToAdd;
                break;

            case SpaceshipType.SECURITY:
                _securityShipCount += amountToAdd;
                break;

            case SpaceshipType.PIRATE:
                _pirateShipCount += amountToAdd;
                break;
        }
    }


    public void ToggleSpeedUp()
    {
        if(!_isGameSpeedSpedUp)
        {
            Time.timeScale = _gameSpeedMultiplier;
        }
        else
        {
            Time.timeScale = 1;
        }

        _isGameSpeedSpedUp = !_isGameSpeedSpedUp;
    }
}
