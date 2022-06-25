using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
	// Start is called before the first frame update
	public Color color = Color.black;
    void Start()
    {
		Renderer r = GetComponent<Renderer>();
		if (r != null)
		{
			r.material.color = color;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
