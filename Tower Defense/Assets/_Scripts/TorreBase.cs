using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreBase : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject prefabBala;
    public List<GameObject> puntasCanon;
    public void Update()
    {
        if(enemigo != null)
        {
            Apuntar();
        }
    }
    public void Apuntar()
    {
        transform.LookAt(enemigo.transform);//Metodo para virar automaticamente a ver a algo mas
    }
    public virtual void Disparar()
    {
        foreach(GameObject punta in puntasCanon)
        {
            var tempBal = Instantiate<GameObject>(prefabBala, punta.transform.position, Quaternion.identity);
            tempBal.GetComponent<Bala>().destino = enemigo.transform.position;
        }
    }
}
