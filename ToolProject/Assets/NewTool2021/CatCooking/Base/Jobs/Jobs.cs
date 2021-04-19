using System;
using UnityEngine;

/// <summary>
/// 动画分形
/// </summary>
public class Jobs { }

public class Fractal : MonoBehaviour
{
    [SerializeField, Range(1, 8)]
    int depth = 4;
}
