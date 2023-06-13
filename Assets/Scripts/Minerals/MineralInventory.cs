using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralInventory : MonoBehaviour
{
    [SerializeField] private List<Mineral> _newMinerals;

    public bool IsInventoryEmpty
    {
        get
        {
            foreach (Mineral mineral in NewMinerals)
            {
                if(mineral.Amount > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public List<Mineral> NewMinerals { get => _newMinerals; }

    // Start is called before the first frame update
    void Awake()
    {
        InitializeMineralList();
    }

    void InitializeMineralList()
    {
        string[] mineralTypeNames = Enum.GetNames(typeof(MineralType));
        int numberOfMineralTypes = mineralTypeNames.Length;

        for (int i = 1; i < numberOfMineralTypes; i++) // i starts at 1 because we want to skip 0 (MineralType.NONE)
        {   
            Mineral newMineral = new Mineral( (MineralType)i );

            NewMinerals.Add(newMineral);
        }
    }

    public bool AddMineralToInventory(Mineral mineralToAdd)
    {
        if (mineralToAdd.Amount <= 0)
        {
            Debug.LogWarning("Attempted to add non-positive amount of mienrals to inventory");
            return false;
        }

        foreach (Mineral mineral in NewMinerals)
        {
            if (mineralToAdd.MineralType == mineral.MineralType)
            {
                mineral.Amount += mineralToAdd.Amount;
                return true; // found corresponding mineral type in inventory, successfully added
            }
        }

        Debug.LogWarning("No " + mineralToAdd.MineralType.ToString() + " found in inventory: couldn't add!");
        return false; // didnt find corresponding mineral type in inventory, nothing added
    }

    public void TransferMineralToInventory(Mineral mineralToTransferFrom, int amountToTransfer)
    {
        if (amountToTransfer > mineralToTransferFrom.Amount)
        {
            Debug.LogWarning("Attempted to transfer too much!");
            return;
        }

        Mineral tempMineral = new Mineral(mineralToTransferFrom.MineralType);
        tempMineral.Amount = amountToTransfer;

        if (AddMineralToInventory(tempMineral))
        {
            mineralToTransferFrom.Amount -= amountToTransfer; // Removes Minerals from origin
        }
    }


}
