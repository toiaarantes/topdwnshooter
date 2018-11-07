using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

    private Vector2 target;
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float tempoVida;

    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Invoke("DestruirProjetil", tempoVida);
        
    }

    private void Update()
    {
        Move();
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,target, velocidade * Time.deltaTime);
    }

    void DestruirProjetil()
    {
        Destroy(gameObject);
    }
}
