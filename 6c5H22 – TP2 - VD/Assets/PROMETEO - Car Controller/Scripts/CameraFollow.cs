using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform carTransform;
	[Range(1, 10)]
	public float translateSpeed = 2;
	[Range(1, 10)]
	public float rotationSpeed = 5;
	public Vector3 initialCameraPosition;
	public List<Vector3> listofCameras;

	private int cameraSelected = 0;

	private Vector3 targetPos;

	private Vector3 direction;
	private Quaternion rotation;

	void Start(){
		initialCameraPosition = gameObject.transform.position;
	}

	void Update()
	{
		if (Input.GetKeyDown("c"))
		{
			if (cameraSelected == listofCameras.Count - 1)
			{
				cameraSelected = 0;
			} else {
				cameraSelected++;
			}
			Debug.Log(cameraSelected);
		}
	}

	void FixedUpdate()
	{
		targetPos = carTransform.TransformPoint(listofCameras[cameraSelected]);
		transform.position = Vector3.Lerp(transform.position, targetPos, translateSpeed * Time.deltaTime);

		direction = initialCameraPosition = carTransform.position;
		rotation = Quaternion.LookRotation(direction, Vector3.up);
		transform.rotation = Quaternion.Lerp(carTransform.rotation, rotation, rotationSpeed * Time.deltaTime);

	}

}
