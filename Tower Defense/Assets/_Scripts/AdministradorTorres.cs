using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorTorres : MonoBehaviour
{
    public AdministradorToques referenciaAdminToque;
    public enum TorreSeleccionada
    {
        Torre1, Torre2, Torre3, Torre4, Torre5
    }
    public TorreSeleccionada torreSeleccionada;
    public List<GameObject> prefabsTorres;

    private void OnEnable()
    {
        referenciaAdminToque.EnPlataformaTocada += CrearTorre;
    }

    private void OnDisable()
    {
        referenciaAdminToque.EnPlataformaTocada -= CrearTorre;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CrearTorre(GameObject plataforma)
    {
        if (plataforma.transform.childCount == 0)
        {
            Debug.Log("Creando torre");
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = plataforma.transform.position;
            posParaInstanciar.y += 0.5f;
            GameObject torreInstanciada = Instantiate<GameObject>(prefabsTorres[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstanciada.transform.SetParent(plataforma.transform);
        }
    }
    public void ConfigurarTorre(int torre)
    {
        if (Enum.IsDefined(typeof(TorreSeleccionada), torre))
        {
            torreSeleccionada = (TorreSeleccionada)torre;
        }
        else
        {
            Debug.Log("Esa torre no esta definida");
        }
    }

}