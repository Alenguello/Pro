using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    Vector2 limitesPantalla;

    [SerializeField] private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Evitar salir e la pantalla
        limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (true)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de la IA
        transform.position = transform.position + (Vector3.right * Time.deltaTime * speed);

        if (transform.position.x <= -limitesPantalla.x -2 || transform.position.x > limitesPantalla.x +2) 
        {
            Destroy(gameObject);
        }
    }
}
