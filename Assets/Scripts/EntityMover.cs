using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class EntityMover : MonoBehaviour {
	public float maxForce = 10.0f;
	public float maxSpeed = 10.0f;
	public float mass = 1.0f;

	private CharacterController _charCon;
	private Vector3 _velocity = Vector3.zero;

	public Vector3 Velocity{
		get{
			return _velocity;
		}
	}

	void Awake(){
		_charCon = GetComponent<CharacterController> ();
	}

	void FixedUpdate(){
		EnforceMaxSpeed ();
		_charCon.Move (_velocity * Time.deltaTime);
		transform.LookAt (transform.position + _velocity);
	}

	void EnforceMaxSpeed () {
		KeepUnder (ref _velocity, maxSpeed);
	}
	
	public void AddForce(Vector3 newForce){
		newForce.y = 0;
		KeepUnder (ref newForce, maxForce);
		newForce *= Time.fixedDeltaTime;
		_velocity += newForce / mass;
	}

	void KeepUnder(ref Vector3 inVect, float max){
		if (inVect.magnitude > max) {
			inVect.Normalize();
			inVect *= max;
		}
	}
}
