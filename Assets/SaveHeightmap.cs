using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveHeightmap : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Debug.Log("Here");
        Save();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Save()
    {
        Vector3 pos = Terrain.activeTerrain.GetPosition();
        float w = Terrain.activeTerrain.terrainData.heightmapWidth;

        Vector3 step = Terrain.activeTerrain.terrainData.size / 512.0f;
        Vector3 point = Vector3.zero;

        byte[] data = new byte[513 * 513];

        for (int xx = 0; xx <= 512; xx++)
        {
            for (int zz = 0; zz <= 512; zz++)
            {
                point = new Vector3(step.x * xx, 0, step.z * zz);
                point += pos;



                byte b = 255;
                float h = 0;
                RaycastHit hitInfo;

                Ray ray = new Ray(point + Terrain.activeTerrain.terrainData.size.y * Vector3.up, Vector3.down);
                if (Physics.Raycast(ray, out hitInfo))
                {
                    h = hitInfo.distance;
                    b = (byte)(255 * (1 - h / Terrain.activeTerrain.terrainData.size.y));
                }
                else {
                    ray = new Ray(point, Vector3.up);
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        h = hitInfo.distance;
                        b = (byte)(255 * (h / Terrain.activeTerrain.terrainData.size.y));
                    }
                }
                data[zz * 513 + xx] = b;
            }
        }

        File.WriteAllBytes(@"D:\src2\Ignition\terrain2.raw", data);
    }
}
