using UnityEngine;
using System.Collections;

public class ArriveGoal : Goal {
	public Vector3 arriveTarget;
	public float arriveThreshold = 5.0f;

	void FixedUpdate(){
		if (arriveTarget == null) {
			return;
		}
		float distance = Vector3.Distance (transform.position, arriveTarget);
		Vector3 velocity = (GetSeekVelocity (arriveTarget));
		float scale = 1 - (arriveThreshold - distance) / arriveThreshold;
		scale *= scale;

		if (scale > 1) {
			scale = 1;
		}
		RequestVelocity (scale * velocity);
	}
}
