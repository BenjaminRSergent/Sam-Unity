using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupSpawner : MonoBehaviour {
	public float groupASpawnChance = 0.5f;
	public GroupMember groupAMemberPrefab;
	public GroupMember groupBMemberPrefab;

	public int numToSpawn = 1000;

	// Use this for initialization
	void Start () {
		SpawnAll ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnAll () {
		for (int index = 0; index < numToSpawn; index++) {
			GroupSpawnerMember (Random.value > groupASpawnChance ? groupAMemberPrefab : groupBMemberPrefab);
		}
	}

	void GroupSpawnerMember (GroupMember prefab) {
		GroupMember member = Instantiate(prefab);
		PlaceInArea(member.gameObject, member.groupDef.spawnArea);
		GroupManager.AddMember (member);
	}

	void PlaceInArea (GameObject member, Volume spawnArea) {
		Vector3 offset = new Vector3 (spawnArea.size.x * Random.value,
			                          spawnArea.size.y * Random.value,
			                          spawnArea.size.z * Random.value);
		
		member.transform.position = spawnArea.lowerBackLeft + offset;
	}

}
