using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBase : MonoBehaviour, IAtacante, IAtacable
{
    public GameObject objetivo;
    public int vida = 100;
    public int _dano = 5;
    [Tooltip("Variable utilizada para modificar la velocidad del enemigo.")]
    public float speed = 2f;
    public int recursosGanados = 200;

    public AdminJuego referenciaAdminJuego;
    public SpawnerEnemigos referenciaSpawner;
    public Animator Anim;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
        referenciaAdminJuego = GameObject.Find("AdminJuego").GetComponent<AdminJuego>();
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido += Detener;
    }

    private void OnDisable()
    {
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido -= Detener;
    }
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Objetivo");
        referenciaSpawner = GameObject.FindGameObjectWithTag("SpawnerEnemigos").GetComponent<SpawnerEnemigos>();
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        GetComponent<NavMeshAgent>().speed = speed;
        Anim = GetComponent<Animator>();
        Anim.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(vida<= 0)
        {
            Anim.SetTrigger("OnDeath");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(gameObject, 3);
        }
    }
    public virtual void OnDestroy()
    {
        referenciaAdminJuego.ModificarRecursos(recursosGanados);
        referenciaSpawner.EnemigosGenerados.Remove(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            Anim.SetBool("isMoving", false);
            Anim.SetTrigger("OnObjectiveReached");
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void Detener()
    {
        Anim.SetTrigger("OnObjectiveDestroyed");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }
    public void Danar(int dano)
    {
        if (dano == 0) dano = _dano;
        objetivo?.GetComponent<Objetivo>().RecibirDano(40);
    }
    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}
