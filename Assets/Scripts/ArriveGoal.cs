using UnityEngine;
using System.Collections;

public class ArriveGoal : Goal {
	public Vector3 arriveTarget;
	public float arriveThreshold = 5.0f;
	public bool quadratic = true;

	void FixedUpdate(){
		float distance = Vector3.Distance (transform.position, arriveTarget);
		Vector3 velocity = (GetSeekVelocity (arriveTarget));
		float scale = 1 - (arriveThreshold - distance) / arriveThreshold;

		if (quadratic) {
			scale *= scale;
		}

		if (scale > 1) {
			scale = 1;
		}
		RequestVelocity (scale * velocity);
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (0, 1, 0, 0.1f);
		Gizmos.DrawSphere (arriveTarget, arriveThreshold);
	}
}
