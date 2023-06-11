using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/EnorMine", order = 1)]
public class EnorMine : MineralMine
{
    public override void InitMineralType()
    {
        _mineral = new Enor();
    }
}
