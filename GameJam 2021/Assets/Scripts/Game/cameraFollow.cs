using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

	public static cameraFollow Instance;
	public bool isActive;
	[SerializeField]
	public Transform target;

	public float smoothSpeed =12f;
	public Vector3 Offset;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		isActive = true;
		Offset.z = -2;
	}

	private void LateUpdate()
	{
		if (isActive)
		{
			Vector3 WantedPosition = target.position + Offset;
            		Vector3 smoothPosition = Vector3.Lerp(transform.position,WantedPosition,smoothSpeed * Time.deltaTime);
            		transform.position = smoothPosition;
		}
		

	}





}
