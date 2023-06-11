using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/BismorMine", order = 1)]
public class BismorMine : MineralMine
{
    public override void InitMineralType()
    {
        _mineral = new Bismor();
    }
}
