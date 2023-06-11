using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/JadisMine", order = 1)]
public class JadisMine : MineralMine
{
    public override void InitMineralType()
    {
        _mineral = new Jadis();
    }
}
