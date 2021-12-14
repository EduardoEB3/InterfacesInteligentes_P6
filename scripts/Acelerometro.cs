using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acelerometro : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    private int golesporteria1;
    private int golesporteria2;
    public Text marcador;
    private Vector3 centro;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 10;
        golesporteria1 = 0;
        golesporteria2 = 0;
        centro = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Update() 
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 inclinacion = Input.acceleration;
        inclinacion = Quaternion.Euler(90,0,0) * inclinacion;
        rb.AddForce(inclinacion * velocidad);
    }

    void Mensaje(int golesporteria1, int golesporteria2)
    {
        marcador.text = "Frenahaybache " + golesporteria1 + "-" + golesporteria2 + " Calce Team";
    }

    void OnCollisionEnter(Collision objetoColision)
    {
        if (objetoColision.gameObject.name == "Porteria") {
            golesporteria1++;
            Mensaje(golesporteria1, golesporteria2);
            transform.position = centro;
        } else if (objetoColision.gameObject.name == "Porteria2") {
            golesporteria2++;
            Mensaje(golesporteria1, golesporteria2);
            transform.position = centro;
        }
    }
}
