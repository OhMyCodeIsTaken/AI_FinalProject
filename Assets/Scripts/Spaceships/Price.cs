using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Price
{
    [SerializeField] private List<Mineral> _minerals = new List<Mineral>();

    public List<Mineral> Minerals { get => _minerals; }
}
