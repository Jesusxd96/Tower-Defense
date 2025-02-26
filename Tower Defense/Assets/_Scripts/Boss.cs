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
    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigosJefeDerrotados++;
    }
}
