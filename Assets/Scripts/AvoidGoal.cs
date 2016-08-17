using UnityEngine;
using System.Collections;

public class AvoidGoal : Goal {
	public Transform[] avoidTargets;
	public float maxAvoidDistance = 3.0f;
	public bool quadratic = false;
	void FixedUpdate(){
		if (avoidTargets == null) {
			return;
		}
		Vector3 sumForces = Vector3.zero;
		foreach (Transform avoidTarget in avoidTargets) {
			sumForces += GetAvoidForce(avoidTarget.position, maxAvoidDistance, quadratic, 0, 2);
		}

		_entBrain.RequestForce (sumForces, priority);
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, 0.1f);
		foreach (Transform avoidTarget in avoidTargets) {
			Gizmos.DrawSphere (avoidTarget.position, maxAvoidDistance);
		}
	}
}
