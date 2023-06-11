using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/UmaniteMine", order = 1)]
public class UmaniteMine : MineralMine
{
    public override void InitMineralType()
    {
        _mineral = new Umanite();
    }
}
