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

        _minerals.Add(_bismor);
        _minerals.Add(_jadis);
        _minerals.Add(_enor);
        _minerals.Add(_magnite);
        _minerals.Add(_croppa );
        _minerals.Add(_umanite);


        // Test
        //Bismor bismorToAdd = new Bismor();
        //bismorToAdd.Amount = 3;
        //AddMineralToInventory(bismorToAdd);

        //Jadis jadisToAdd = new Jadis();
        //jadisToAdd.Amount = 2;
        //AddMineralToInventory(jadisToAdd);
    }

    public void TransferMineralToInventory(BaseMineral mineralToTransfer)
    {
        if(AddMineralToInventory(mineralToTransfer))
        {
            mineralToTransfer.Amount = 0; // Removes Minerals from origin
        }     
    }
    public bool AddMineralToInventory(BaseMineral mineralToAdd)
    {
        if(mineralToAdd.Amount <= 0)
        {
            Debug.LogWarning("Attempted to add non-positive amount of mienrals to inventory");
            return false;
        }

        foreach (BaseMineral mineral in _minerals)
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
