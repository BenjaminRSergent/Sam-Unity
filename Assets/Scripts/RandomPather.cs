using UnityEngine;
using System.Collections;

public class RandomPather : MonoBehaviour {
	public float range = 50;
	public float closeEnough = 1.0f;
	public GameObject goalMarkerPrefab;

	private SeekGoal _seekGoal;
	private Vector3 _nextGoal;
	private GameObject _goalMarker;


	void Awake(){
		_seekGoal = gameObject.AddComponent<SeekGoal> ();
		_nextGoal = ChooseGoal ();
		_goalMarker = Instantiate(goalMarkerPrefab) as GameObject;
	}

	void OnEnable(){
		_seekGoal.enabled = true;
	}

	void OnDisable(){
		_seekGoal.enabled = false;
	}

	void OnDestroy(){
		Destroy (_seekGoal);
	}

	void Update(){
		float distance = Vector3.Distance (transform.position, _nextGoal);
		if (distance < closeEnough) {
			_nextGoal = ChooseGoal();
		}

		_seekGoal.target = _nextGoal;
		_goalMarker.transform.position = _nextGoal;
	}

	Vector3 ChooseGoal(){
		return new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
	}
}
