using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : EnemigoBase
{
    private void Awake()
    {
        vida = 50;
        _dano = 10;
    }
}
