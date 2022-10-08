using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor : MonoBehaviour
{
    public ContactFilter2D filtro;
    private BoxCollider2D caixaDeColisao;
    private Collider2D[] hits = new Collider2D[10];

    
    protected virtual void Start()
    {
        caixaDeColisao = GetComponent<BoxCollider2D>();
    }


    protected virtual void Update ()
    {
        caixaDeColisao.OverlapCollider(filtro, hits);
        for (int i = 0; i < hits.Lenght; i++)
        {
            if (hits[i == null);
            continue;

            Debug.Log(hits[i].name);

            hits[i] = null;



        }
    }
   
}
