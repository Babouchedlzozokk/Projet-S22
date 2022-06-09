using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

	bool isRewinding = false;

	public float recordTime = 5f;

	List<LastPosition> pointsInTime;

	Rigidbody rb;

	// Use this for initialization
	void Start()
	{
		pointsInTime = new List<LastPosition>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (PowerUpBackInTime.HaveBackInTime)
		{
			if (Input.GetKeyDown(INPUTS.Back_in_time))
			{
				SoundManagerScript.PlaySound("backintime");
				StartRewind();
			}
			if (Input.GetKeyUp(KeyCode.E))
			{
				SoundManagerScript.PlaySound("stop");
				StopRewind();
			}
		}
	}

	void FixedUpdate()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind()
	{
		if (pointsInTime.Count > 0)
		{
			LastPosition pointInTime = pointsInTime[0];
			transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		}
		else
		{
			StopRewind();
		}

	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new LastPosition(transform.position, transform.rotation));
	}

	public void StartRewind()
	{
		isRewinding = true;
		rb.isKinematic = true;
	}

	public void StopRewind()
	{
		isRewinding = false;
		rb.isKinematic = false;
	}
}