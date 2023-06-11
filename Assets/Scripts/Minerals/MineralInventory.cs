using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralInventory : MonoBehaviour
{
    [SerializeField] private Bismor _bismor;

    private List<BaseMineral> _minerals;
    // Start is called before the first frame update
    void Start()
    {
        _bismor = new Bismor();
        _minerals = new List<BaseMineral>();

        _minerals.Add(_bismor);


        // Test
        Bismor bismorToAdd = new Bismor();
        bismorToAdd.Amount = 3;
        AddMineralToInventory(bismorToAdd);

        Jadis jadisToAdd = new Jadis();
        jadisToAdd.Amount = 2;
        AddMineralToInventory(jadisToAdd);
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
                mineralToAdd.Amount = 0; // Removes Minerals from origin
                return true; // found corresponding mineral type in inventory, successfully added
            }
        }

        Debug.LogWarning("No " + mineralToAdd.GetType().ToString() + " found in inventory: couldn't add!");
        return false; // didnt find corresponding mineral type in inventory, nothing added
    }

    
}
