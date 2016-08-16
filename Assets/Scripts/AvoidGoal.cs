using UnityEngine;
using System.Collections;

public class AvoidGoal : Goal {
	public Transform[] avoidTargets;
	public float maxAvoidDistance = 3.0f;

	void FixedUpdate(){
		if (avoidTargets == null) {
			return;
		}
		Vector3 sumForces = Vector3.zero;
		foreach (Transform avoidTarget in avoidTargets) {
			sumForces += GetAvoidForce(avoidTarget.position, maxAvoidDistance);
		}

		_entBrain.RequestForce (sumForces, priority);
	}
}
