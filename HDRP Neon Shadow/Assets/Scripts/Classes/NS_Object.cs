﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

/// <summary>
/// This is our base object. It is an extension of Unity's base object, combined with the Saveable interface
/// </summary>
public class NS_Object : MonoBehaviour, Saveable
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void Saveable.save(string file)
	{

	}

	void Saveable.load(string file)
	{

	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		// sample code from MSDN, might need later

		// Use the AddValue method to specify serialized values.
		//info.AddValue("props", myProperty_value, typeof(string));
	}

	// The special constructor is used to deserialize values.
	void MyItemType(SerializationInfo info, StreamingContext context)
	{
		// sample code from MSDN, might need later

		// Reset the property value using the GetValue method.
		//myProperty_value = (string)info.GetValue("props", typeof(string));
	}
}
