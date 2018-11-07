using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float velocidade = 10;
    private Transform posJogador;
    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        posJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, posJogador.position, velocidade * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.vida--;
            Debug.Log(player.vida);
            Destroy(gameObject);
        }
        if(other.CompareTag("Projetil"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
