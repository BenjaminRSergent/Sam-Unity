using UnityEngine;
using System.Collections;

public class ChaseGoal : Goal {
	public Transform chaseTarget;

	void FixedUpdate(){
		RequestVelocity(GetSeekVelocity (chaseTarget.position));
	}

}
