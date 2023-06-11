using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/MineralMine", order = 1)]
abstract public class MineralMine : ScriptableObject
{
    protected BaseMineral _mineral;

    public BaseMineral Mineral
    {
        get
        {
            if(_mineral == null)
            {
                InitMineralType();
            }
            return _mineral;
        }
    }

    public abstract void InitMineralType();
}
