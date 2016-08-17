using UnityEngine;
using System.Collections;

public class RandomPather : MonoBehaviour {
	public float range = 50;
	public float closeEnough = 1.0f;
	public GameObject goalMarkerPrefab;

	private ArriveGoal _arriveGoal;
	private Vector3 _nextGoal;
	private GameObject _goalMarker;


	void Awake(){
		_arriveGoal = gameObject.AddComponent<ArriveGoal> ();
		_arriveGoal.arriveThreshold = 20;
		_nextGoal = ChooseGoal ();
		_goalMarker = Instantiate(goalMarkerPrefab) as GameObject;
	}

	void OnEnable(){
		_arriveGoal.enabled = true;
	}

	void OnDisable(){
		_arriveGoal.enabled = false;
	}

	void OnDestroy(){
		Destroy (_arriveGoal);
	}

	void Update(){
		float distance = Vector3.Distance (transform.position, _nextGoal);
		if (distance < closeEnough) {
			_nextGoal = ChooseGoal();
		}

		_arriveGoal.arriveTarget = _nextGoal;
		_goalMarker.transform.position = _nextGoal + _goalMarker.transform.lossyScale/2;
	}

	Vector3 ChooseGoal(){
		return new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
	}
}
