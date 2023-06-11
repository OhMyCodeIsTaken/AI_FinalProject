using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/MagniteMine", order = 1)]
public class MagniteMine : MineralMine
{
    public override void InitMineralType()
    {
        _mineral = new Magnite();
    }
}
