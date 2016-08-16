using UnityEngine;
using System.Collections;

[RequireComponent (typeof(EntityBrain))]
public class SeekGoal : Goal {
	public Vector3 target;
	
	void FixedUpdate(){
		if (target == null) {
			return;
		}
		RequestVelocity (GetSeekVelocity (target));
	}
}
