using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralInventory : MonoBehaviour
{
    [SerializeField] private Bismor _bismor;
    [SerializeField] private Jadis _jadis;
    [SerializeField] private Enor _enor;
    [SerializeField] private Magnite _magnite;
    [SerializeField] private Croppa _croppa;
    [SerializeField] private Umanite _umanite;

    private List<BaseMineral> _minerals;

    public bool IsInventoryEmpty
    {
        get
        {
            foreach (BaseMineral mineral in Minerals)
            {
                if(mineral.Amount > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public List<BaseMineral> Minerals { get => _minerals; }

    // Start is called before the first frame update
    void Start()
    {
        _bismor = new Bismor();
        _jadis = new Jadis();
        _enor = new Enor();
        _magnite = new Magnite();
        _croppa = new Croppa();
        _umanite = new Umanite();
        _minerals = new List<BaseMineral>();

        Minerals.Add(_bismor);
        Minerals.Add(_jadis);
        Minerals.Add(_enor);
        Minerals.Add(_magnite);
        Minerals.Add(_croppa );
        Minerals.Add(_umanite);


        // Test
        //Bismor bismorToAdd = new Bismor();
        //bismorToAdd.Amount = 3;
        //AddMineralToInventory(bismorToAdd);

        //Jadis jadisToAdd = new Jadis();
        //jadisToAdd.Amount = 2;
        //AddMineralToInventory(jadisToAdd);
    }

    public void TransferMineralToInventory(BaseMineral mineralToTransferFrom, int amountToTransfer)
    {
        if(amountToTransfer > mineralToTransferFrom.Amount)
        {
            Debug.LogWarning("Attempted to transfer too much!");
            return;
        }

        BaseMineral tempMineral = (BaseMineral)Activator.CreateInstance(mineralToTransferFrom.GetType());
        tempMineral.Amount = amountToTransfer;
        if (AddMineralToInventory(tempMineral))
        {
            mineralToTransferFrom.Amount -= amountToTransfer; // Removes Minerals from origin
        }     
    }
    public bool AddMineralToInventory(BaseMineral mineralToAdd)
    {
        if(mineralToAdd.Amount <= 0)
        {
            Debug.LogWarning("Attempted to add non-positive amount of mienrals to inventory");
            return false;
        }

        foreach (BaseMineral mineral in Minerals)
        {
            if(mineralToAdd.GetType() == mineral.GetType())
            {
                mineral.Amount += mineralToAdd.Amount;
                return true; // found corresponding mineral type in inventory, successfully added
            }
        }

        Debug.LogWarning("No " + mineralToAdd.GetType().ToString() + " found in inventory: couldn't add!");
        return false; // didnt find corresponding mineral type in inventory, nothing added
    }

    
}
