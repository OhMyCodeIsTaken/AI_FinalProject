using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMines/CroppaMine", order = 1)]
public class CroppaMine : MineralMine
{
    public override void InitMineralType()
    {
        _mineral = new Croppa();
    }
}
