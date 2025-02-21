using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 100;
    [Tooltip("Valor utilizado para modificar el daño de los enemigos desde el editor.")]
    public int damage = 10;

    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Objetivo");
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim = GetComponent<Animator>();
        Anim.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void Danar()
    {
        objetivo?.GetComponent<Objetivo>().RecibirDano(damage);
    }
    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}
