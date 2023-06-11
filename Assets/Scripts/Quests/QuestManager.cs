using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<MiningQuest> _miningQuests = new List<MiningQuest>();

    public List<MiningQuest> MiningQuests { get => _miningQuests; }
}
