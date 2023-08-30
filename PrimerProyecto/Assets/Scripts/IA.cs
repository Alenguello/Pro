using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    private int dir = 1;
    private float tam;
    Vector2 limitesPantalla;

    [SerializeField] private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Evitar salir e la pantalla
        limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x <= limitesPantalla.x/2)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }

        //Tamaño aleatorio
        float tamAleatorio = Random.Range(0.5f, 2.5f);
        tam = tamAleatorio;
        transform.localScale = new Vector3(tamAleatorio, tamAleatorio, tamAleatorio);
    }

    // Update is called once per frame
    private void Update()
    {
        //Movimiento de la IA
        transform.position = transform.position + (Vector3.right * dir * Time.deltaTime * speed);

        if (transform.position.x <= -limitesPantalla.x -2 || transform.position.x > limitesPantalla.x +2) 
        {
            Destroy(gameObject);
        }
    }

    //public float GetTam() 
    //{
    //    return tam;
    //}
}
