using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositState : CoroutineState
{
    [SerializeField] private MiningSpaceship _miningSpaceship;

    [SerializeField] private float _depositElapsedTime;
    [SerializeField] private float _depositCooldown;
    [SerializeField] private int _depositAmount;


    public override bool IsLegal()
    {
        if(handler.Spaceship.OccupyingPlanet == GameManager.Instance.HomePlanet && 
            !_miningSpaceship.MineralInventory.IsInventoryEmpty )
        {
            return true;
        }

        return false;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {
     
    }

    public override IEnumerator RunState()
    {
        while (!_miningSpaceship.MineralInventory.IsInventoryEmpty)
        {
            if(_depositElapsedTime >= _depositCooldown)
            {
                _depositElapsedTime = 0;
                foreach (Mineral spaceshipMineral in _miningSpaceship.MineralInventory.Minerals)
                {
                    if (spaceshipMineral.Amount > 0)
                    {
                        int amountToDeposit;
                        if(spaceshipMineral.Amount >= _depositAmount)
                        {
                            amountToDeposit = _depositAmount;
                        }
                        else
                        {
                            amountToDeposit = spaceshipMineral.Amount;
                        }
                        GameManager.Instance.HomePlanet.MineralInventory.TransferMineralToInventory(spaceshipMineral, amountToDeposit);

                        int amountOfMineralInInventory = GameManager.Instance.HomePlanet.MineralInventory.Minerals[(int)spaceshipMineral.MineralType].Amount;
                        GameManager.Instance.UIManager.UpdateMineralText(spaceshipMineral.MineralType, amountOfMineralInInventory);
                        GameManager.Instance.ScoreManager.UpdateScore(amountToDeposit);
                    }
                }   
            }

            _depositElapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }
}
