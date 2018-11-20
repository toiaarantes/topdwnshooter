using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float velocidade = 10;
    private Transform posJogador;
    private Player player;
    public GameObject efeitoTiro;
    public GameObject efeitoInimigo;
    private ScreenShake shake;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        posJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shake = GameObject.FindGameObjectWithTag("ScnSke").GetComponent<ScreenShake>();



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
            GameObject ef = Instantiate(efeitoInimigo, transform.position, Quaternion.identity);
            shake.CamShake();
            Destroy(ef, 2f);
            Destroy(gameObject);
        }
        if(other.CompareTag("Projetil"))
        {
            GameObject ef = Instantiate(efeitoInimigo, transform.position, Quaternion.identity);
            GameObject efT = Instantiate(efeitoTiro, transform.position, Quaternion.identity);
            shake.CamShake();
            Destroy(ef, 2f);
            Destroy(efT, 2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
