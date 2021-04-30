using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

	[SerializeField]
	public Transform target;

	public float smoothSpeed =12f;
	public Vector3 Offset;

	private void LateUpdate()
	{
		Vector3 WantedPosition = target.position + Offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position,WantedPosition,smoothSpeed * Time.deltaTime);
		transform.position = smoothPosition;

	}





}
