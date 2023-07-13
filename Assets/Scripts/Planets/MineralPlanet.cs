using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MineralPlanet : Planet
{
    [SerializeField] private float _miningElapsedTime;
    [SerializeField] private float _miningCooldown;

    private Mineral _primaryMinedMineral;
    private Mineral _secondaryMinedMineral;


    [SerializeField] private MineralType _primaryMineralType;
    [SerializeField] private MineralType _secondaryMineralType;

    [SerializeField] private int _primaryMineralProduce;
    [SerializeField] private int _secondaryMineralProduce;

    public Mineral PrimaryMinedMineral { get => _primaryMinedMineral; }
    public Mineral SecondaryMinedMineral { get => _secondaryMinedMineral; }
    public MineralType PrimaryMineralType { get => _primaryMineralType; }
    public MineralType SecondaryMineralType { get => _secondaryMineralType; }

    private void Awake()
    {
        if (PrimaryMineralType == MineralType.NONE || SecondaryMineralType == MineralType.NONE)
        {
            return;
        }

        GameManager.Instance.MineralPlanets.Add(this);

        _primaryMinedMineral = new Mineral(PrimaryMineralType);
        _primaryMinedMineral.Amount = _primaryMineralProduce;

        _secondaryMinedMineral = new Mineral(SecondaryMineralType);
        _secondaryMinedMineral.Amount = _secondaryMineralProduce;
    }

    void Start()
    {

        if(PrimaryMineralType == MineralType.NONE || SecondaryMineralType == MineralType.NONE)
        {
            return;
        }

        StartCoroutine(MineMineral());
    }

    private IEnumerator MineMineral()
    {
        while (true)
        {
            if (_miningElapsedTime >= _miningCooldown)
            {
                MineralInventory.AddMineralToInventory(PrimaryMinedMineral);
                MineralInventory.AddMineralToInventory(SecondaryMinedMineral);

                // Reset 
                _miningElapsedTime = 0;
            }

            _miningElapsedTime += Time.deltaTime;
            yield return null;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Pirate"))
        {
            Debug.Log("PIRATE!");
            AttemptToSendDistressSignal(other);
        }
    }

    private void AttemptToSendDistressSignal(Collider other)
    {
        if (ReferenceEquals(this, other.GetComponent<PirateSpaceship>().TargetPlanet))
        {
            GameManager.Instance.HomePlanet.QuestManager.DistressedPlanets.Add(this);
        }
       
    }
}
