using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Brujula : MonoBehaviour
{
	public Image compass;
	private float gradosAlNorte;
  
  // Start is called before the first frame update
	void Start()
  {
    gradosAlNorte = 0;
    Input.compass.enabled = true;
  }

  // Update is called once per frame
  void Update()
  {

  }

	// Update is called once per frame
  void FixedUpdate () {
    Input.location.Start();           
    gradosAlNorte = Input.compass.trueHeading;
 
    if (Mathf.Abs(gradosAlNorte) > 3) {
      compass.transform.eulerAngles = new Vector3(0, 0, gradosAlNorte);
    }         
  }
}
