using UnityEngine;
using System.Collections;

public class caar : MonoBehaviour {

    public GameObject wheelLF;
    public GameObject wheelRF;
    public GameObject wheelLR;
    public GameObject wheelRR;

    private float wheelRadius = 0.5f;
    private float suspensionExtend = 1;

    GameObject[] wheels;

	// Use this for initialization
	void Start () {
        wheels = new GameObject[] { wheelLF, wheelRF, wheelRR, wheelLR };
        Snap();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += 15 * transform.TransformDirection(Vector3.forward) * Time.fixedDeltaTime;
            Snap();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= 10 * transform.TransformDirection(Vector3.forward) * Time.fixedDeltaTime;
            Snap();
        }
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0, -Time.fixedDeltaTime*50,0);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0, Time.fixedDeltaTime*50,0);




	}

    void Snap() {
        float[] dist = new float[wheels.Length];
        Vector3[] points = new Vector3[wheels.Length];
        float min = float.MaxValue;

        for (int a = 0; a < dist.Length; a++)
        {
            Ray ray = new Ray(wheels[a].transform.position, transform.TransformDirection(-Vector3.up));
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            dist[a] = hit.distance;
            if (min > dist[a])
                min = dist[a];

            points[a] = hit.point;
        }

        for (int a = 0; a < dist.Length; a++)
        {
            dist[a] -= min + wheelRadius;
        }

        float distAvg = 0;
        for (int a = 0; a < dist.Length; a++)
        {
            distAvg += dist[a];
        }

        distAvg/=(float)dist.Length;

        transform.position -= Vector3.up* (distAvg+min);

        Vector3 fwd = ((points[0] - points[3]) + (points[1] - points[2]));


        Vector3 side = (points[1] - points[0]) + (points[2] - points[3]);


        Vector3 up = Vector3.Cross(fwd, side);

        transform.rotation = Quaternion.LookRotation(fwd,up);

    }
}
