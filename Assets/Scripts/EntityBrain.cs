using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(EntityMover))]
public class EntityBrain : MonoBehaviour {
	private EntityMover _mover;
	private List<Vector3> _reqForcesLowP = new List<Vector3>();
	private List<Vector3> _reqForcesMedP = new List<Vector3>();
	private List<Vector3> _reqForcesHighP = new List<Vector3>();

	void Awake(){
		_mover = GetComponent<EntityMover> ();
	}

	void FixedUpdate(){
		Vector3 totalForce = Vector3.zero;

		bool done = AddForces (_reqForcesHighP, ref totalForce);
		if (!done) {
			done = AddForces (_reqForcesMedP, ref totalForce);
		}
		if (!done) {
			AddForces (_reqForcesLowP, ref totalForce);
		}

		_mover.AddForce (totalForce);

		_reqForcesHighP.Clear ();
		_reqForcesMedP.Clear ();
		_reqForcesLowP.Clear ();
	}

	bool AddForces(List<Vector3> forces, ref Vector3 totalForce) {
		foreach(Vector3 force in forces) {
			totalForce += force;
			if(totalForce.magnitude > _mover.maxForce){
				return true;
			}
		}
		return false;
	}

	public void RequestForce(Vector3 reqForce, ForcePriority priority){

		switch(priority) {
		case ForcePriority.HIGH:
			_reqForcesHighP.Add(reqForce);
			break;
		case ForcePriority.MEDIUM:
			_reqForcesMedP.Add(reqForce);
			break;
		case ForcePriority.LOW:
			_reqForcesHighP.Add(reqForce);
			break;
		default:
			break;
		}
	}
}
