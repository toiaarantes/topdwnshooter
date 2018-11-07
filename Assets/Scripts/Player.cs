using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float velocidade;
    private Vector2 direcao;
    public GameObject projetil;
    private float tmpEntreTiros;
    public float inicialTmpEntreTiros;
    public float offset;
    public int vida=10;
    public float maxAltura=15;
    public float minAltura=-15;
    public float maxLargura=27;
    public float minLargura=-27;



    // Use this for initialization
    void Start()
    {
        direcao = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        
      
        ReceberDirecao();
        Move();
        Atirar();
        if (vida<=0)
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Move()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    private void ReceberDirecao()
    {
        direcao = Vector2.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && transform.position.y < maxAltura)
        {
            direcao += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position.y > minAltura)
        {
            direcao += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxLargura)
        {
            direcao += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > minLargura)
        {
            direcao += Vector2.left;
        }
    }

   

    private void Atirar()
    {
        if (tmpEntreTiros <= 0)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projetil, transform.position, Quaternion.identity);
                tmpEntreTiros = inicialTmpEntreTiros;
            }
        } else
        {
            tmpEntreTiros -= Time.deltaTime;
        }

    }
}
