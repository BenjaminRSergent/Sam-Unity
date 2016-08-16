using UnityEngine;
using System.Collections;

public class FleeGoal : Goal {
	public Transform fleeTarget;
	
	void FixedUpdate(){
		if (fleeTarget == null) {
			return;
		}
		RequestVelocity (-GetSeekVelocity (fleeTarget.position));
	}
}

