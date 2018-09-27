using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += 10.0f * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition -= 10.0f * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.localPosition += 5.0f * Time.deltaTime * transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= 5.0f * Time.deltaTime * transform.up;
        }


    }
}
