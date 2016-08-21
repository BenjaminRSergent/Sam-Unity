using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Perceptron : MonoBehaviour {
	private bool _initalized = false;
	List<GroupMember> _members;

	struct TrainingEntry {
		public float[] features;
		public int trueId;

		public GroupMember member;
	}

	TrainingEntry[] trainingSet;
	float[] weights;
	float skew = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RunLearningStep();
		}
	}



	void RunLearningStep () {
		if (!_initalized) {
			Initalize ();
		}
		for(int memberIndex = 0; memberIndex < _members.Count; memberIndex++) {
			TrainingEntry entry = trainingSet [memberIndex];
			int classification = classifyMember (entry);
			colorForClass (_members [memberIndex], classification);
			int diff = classification - getTrueClass (entry);

			if (diff == 0) {
				continue;
			}
			for (int index = 0; index < entry.features.Length; index++) {
				weights [index] += diff * entry.features [index];
			}

			skew += diff;
		}


	}

	void colorForClass (GroupMember groupMember, int classification) {
		groupMember.SetColor(classification == 1 ? Color.red : Color.blue);
	}

	int getTrueClass (TrainingEntry entry) {
		return entry.trueId == 1 ? -1 : 1;
	}

	int classifyMember (TrainingEntry entry) {
		float total = 0;

		for (int index = 0; index < entry.features.Length; index++) {
			total += entry.features[index] * weights [index];
		}
		total += skew;

		return total >= 0 ? -1 : 1;
	}

	void Initalize () {
		_initalized = true;
		skew = 0.0f;
		int NUM_FEATURES = 3;
		weights = new float[NUM_FEATURES];

		_members = GroupManager.getAllMembers ();
		trainingSet = new TrainingEntry[_members.Count];
		for(int memberIndex = 0; memberIndex < _members.Count; memberIndex++) {
			GroupMember member = _members [memberIndex];

			trainingSet [memberIndex].features = new float[NUM_FEATURES];
			trainingSet [memberIndex].features [0] = member.transform.position.x;
			trainingSet [memberIndex].features [1] = member.transform.position.y;
			trainingSet [memberIndex].features [2] = member.transform.position.z;
			trainingSet [memberIndex].trueId = member.groupDef.id;

			trainingSet [memberIndex].member = member;
		}

	}
}

