using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public int vida = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void RecibirDano(int dano = 20)
    {
        vida -= dano;
    }
}
