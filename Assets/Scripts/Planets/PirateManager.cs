using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateManager : MonoBehaviour
{
    private System.Random rand = new System.Random();
    [SerializeField] private float _elapsedTime = 0;
    [SerializeField] private List<float> _timeUntilNextPirateSpawns = new List<float>();
    [SerializeField] private List<PiratePlanet> _piratePlanets = new List<PiratePlanet>();
    [SerializeField] private GameObject _pirateSpaceshipPrefab;

    public List<PiratePlanet> PiratePlanets { get => _piratePlanets; }

    public PiratePlanet GetRandomPiratePlanet()
    {
        int randomIndex = rand.Next(0, PiratePlanets.Count);
        return PiratePlanets[randomIndex];
    }

    public void SpawnPirate()
    {
        Instantiate(_pirateSpaceshipPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if( GameManager.Instance.PirateShipCount <_timeUntilNextPirateSpawns.Count &&
            _elapsedTime >= _timeUntilNextPirateSpawns[GameManager.Instance.PirateShipCount] )
        {
            _elapsedTime = 0;
            SpawnPirate();
        }

        if(GameManager.Instance.PirateShipCount < _timeUntilNextPirateSpawns.Count)
        {
            GameManager.Instance.UIManager.SetPirateBarFillValue(_elapsedTime / _timeUntilNextPirateSpawns[GameManager.Instance.PirateShipCount]);
            GameManager.Instance.UIManager.SetPirateBarCounter(GameManager.Instance.PirateShipCount);
        }
    }
}
