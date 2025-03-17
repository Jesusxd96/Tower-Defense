using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAntena : TorreBase, IAtacante
{
    public float divisionesRayo = 10;
    public LineRenderer LRrayo;
    public List<Vector3> puntos;
    public int potenciaRayo;
    public void Start()
    {
        LRrayo = GetComponent<LineRenderer>();
    }
    public void FixedUpdate()
    {
        if(enemigo!= null)
        {
            Disparar();
            Danar(potenciaRayo);
        }
        else
        {
            LRrayo.positionCount = 0;
        }
    }
    public override void Disparar()
    {
        puntos = ObtenerPuntos();
        puntos.Insert(0, puntasCanon[0].transform.position);
        var posEnemigo = enemigo.transform.position;
        posEnemigo.y += 1;
        puntos.Add(posEnemigo);
        LRrayo.positionCount = puntos.Count;
        LRrayo.SetPositions(puntos.ToArray());
    }

    private List<Vector3> ObtenerPuntos()
    {
        List<Vector3> puntosTemporales = new List<Vector3>();
        float divisor = 1f / divisionesRayo;
        float linear = 0f;
        bool esPositivo = false;
        if(divisionesRayo == 0)
        {
            Debug.Log("No podemos dividir entre cero, por favor ingresa otro valor en el prefab");
            return null;
        }
        if (divisionesRayo == 1)
        {
            var punto = Vector3.Lerp(puntasCanon[0].transform.position, enemigo.transform.position, 0.5f);
            puntosTemporales.Add(punto);
            return puntosTemporales;
        }
        for(int i = 0; i < divisionesRayo; i++)
        {
            if (i == 0)
            {
                linear = divisor / 2;
            }
            else
            {
                linear += divisor;
            }
            var punto = Vector3.Lerp(puntasCanon[0].transform.position, enemigo.transform.position, linear);
            if (esPositivo)
            {
                punto.x += Random.value * 2;
                esPositivo = false;
            }
            else
            {
                punto.x -= Random.value * 2;
                esPositivo = true;
            }
            puntosTemporales.Add(punto);
        }
        return puntosTemporales;
    }
    public void Danar(int dano = 0)
    {
        enemigo.GetComponent<EnemigoBase>().RecibirDano(potenciaRayo);
    }
}
