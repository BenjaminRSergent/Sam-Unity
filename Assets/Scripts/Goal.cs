using UnityEngine;
using System.Collections;

[RequireComponent (typeof(EntityBrain))]
public class Goal : MonoBehaviour {
	public ForcePriority priority = ForcePriority.MEDIUM;

	protected EntityBrain _entBrain;
	protected EntityMover _entMover;

	void Awake(){
		_entBrain = GetComponent<EntityBrain> ();
		_entMover = GetComponent<EntityMover> ();
	}

	protected Vector3 GetAvoidForce(Vector3 avoidTarget, float maxAvoidDistance ){
		float distance = Vector3.Distance (transform.position, avoidTarget);
		if (distance > maxAvoidDistance) {
			return Vector3.zero;
		}
		Vector3 velocity = (-GetSeekVelocity (avoidTarget));
		Vector3 force = GetForceForDesired (velocity);
		float scale = (maxAvoidDistance - distance) / maxAvoidDistance;
		scale *= scale;
		return scale * force;
	}

	protected Vector3 GetSeekVelocity (Vector3 target){
		Vector3 toTarget = target - transform.position;
		Vector3 desiredVelo = toTarget.normalized * _entMover.maxSpeed;
		return desiredVelo;
	}

	protected void RequestVelocity(Vector3 desiredVelo){
		_entBrain.RequestForce (GetForceForDesired(desiredVelo), priority);
	}

	protected Vector3 GetForceForDesired(Vector3 desiredVelo){
		return desiredVelo - _entMover.Velocity;
		
	}
}
