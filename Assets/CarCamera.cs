using UnityEngine;
using System.Collections;

public class CarCamera : MonoBehaviour {

    public GameObject Target;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Target.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Target.transform.rotation, Time.deltaTime);
	}
}
