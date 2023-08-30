using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoObjeto : MonoBehaviour
{
    float velocidad = 3;
    private float tam;
    private int objetosComidos = 0;

    // Start is called before the first frame update
    void Start()
    {
        tam = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float inputVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;

        transform.position = transform.position + new Vector3(inputHorizontal, inputVertical, 0);

        //Evitar salir e la pantalla
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitesPantalla.x * -1, limitesPantalla.x),
            Mathf.Clamp(transform.position.y, limitesPantalla.y * -1, limitesPantalla.y),
            0
            );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circulo")) 
        {
            IA AI = collision.gameObject.GetComponent<IA>();
            //if (tam >= AI.GetTam()) 
            //{
            //    
            //}
            //else
            //{
            //    Debug.Log("Game Over");
            //    Destroy(gameObject);
            //}
            objetosComidos++;
            Destroy(collision.gameObject);
        }
    }
}
