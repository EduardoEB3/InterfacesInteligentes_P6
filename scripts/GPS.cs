using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public Text ubicacion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gps());
    }

    IEnumerator Gps() {
        if (!Input.location.isEnabledByUser) {
            yield break;
        }

        Input.location.Start();

        int tiempoMaxDeEspera = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && tiempoMaxDeEspera > 0) {
            yield return new WaitForSeconds(1);
            tiempoMaxDeEspera--;
        }

        if (tiempoMaxDeEspera < 1) {
            yield break;
        }
        
        if (Input.location.status == LocationServiceStatus.Failed) {
            yield break;
        } else {
            ubicacion.text = "Latitud: " + Input.location.lastData.latitude.ToString() + 
            "\nLongitud: " + Input.location.lastData.longitude.ToString() + "\nAltitud: " + Input.location.lastData.altitude.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}