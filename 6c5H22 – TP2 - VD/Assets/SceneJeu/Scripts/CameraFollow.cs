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

	private Vector3 fixedPositionCamera = new Vector3(21, 6.5f, -53);
	private Quaternion fixedRotationCamera = new Quaternion(0.264611363f, -0.327401876f, 0.0960492343f, 0.901977539f);

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
		}
	}

	void FixedUpdate()
	{
		if (cameraSelected != 3)
		{
			targetPos = carTransform.TransformPoint(listofCameras[cameraSelected]);
			transform.position = targetPos;

			direction = initialCameraPosition = carTransform.position;
			rotation = Quaternion.LookRotation(direction, Vector3.up);
			transform.rotation = Quaternion.Lerp(carTransform.rotation, rotation, rotationSpeed * Time.deltaTime);
		}
		else 
		{
			transform.position = fixedPositionCamera;
			transform.rotation = fixedRotationCamera;
		}


	}

}
