using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
	SphereCollider sc;

	private void Start()
	{
		sc = GetComponent<SphereCollider>();
	}

	private void Update()
	{
		if(Input.GetKey(KeyCode.V))
		{
			sc.enabled = true;
		}
		else
		{
			sc.enabled = false;
		}
	}

	public void OnTriggerStay (Collider other)
    {
		Enemy_AI eai = other.GetComponent<Enemy_AI>();

		if(eai != null)
		{
			eai.health = 0;
		}
	}
}
