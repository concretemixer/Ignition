using UnityEngine;
using System.Collections;

public class MeshCombiner : MonoBehaviour {

	// Use this for initialization
	public void Go () {

        Quaternion q = transform.rotation;
        Vector3 p = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] c = new CombineInstance[filters.Length];



        for(int a=0;a<filters.Length;a++)
        {
            c[a] = new CombineInstance();
            c[a].subMeshIndex = 0;
            c[a].mesh = filters[a].sharedMesh;
            c[a].transform = filters[a].transform.localToWorldMatrix;
        }


        Mesh mesh = new Mesh();

        mesh.CombineMeshes(c);


        GetComponent<MeshFilter>().sharedMesh = mesh;

        transform.rotation = q;
        transform.position = p;
	}
}
