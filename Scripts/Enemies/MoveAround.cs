using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
	[Tooltip("This is the object that the script's game object will rotate around")]
	public Transform startPoint;
	public Transform endPoint;
	[Tooltip("This is the speed at which the object rotates")]
	public float speed; // the speed of rotation

	bool moveToStart = true;
	bool moveToEnd = false;


	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (startPoint != null && endPoint != null)
		{
			if (moveToStart == true && (this.transform.position != startPoint.transform.position))
			{
				transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
			}
			else if (moveToStart == true && (this.transform.position == startPoint.transform.position))
			{
				moveToStart = false;
				moveToEnd = true;
			}
			else if (moveToEnd == true && (this.transform.position != endPoint.transform.position))
			{
				transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
			}
			else if (moveToEnd == true && (this.transform.position == endPoint.transform.position))
			{
				moveToStart = true;
				moveToEnd = false;
			}
		}



	}
}
