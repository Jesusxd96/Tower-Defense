using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemigoBase
{
    private void Awake()
    {
        vida = 200;
        _dano = 40;
    }
}
