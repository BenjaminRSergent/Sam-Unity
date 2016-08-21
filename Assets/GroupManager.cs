using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupManager : MonoBehaviour {

	private static List<GroupMember> _members = new List<GroupMember>();

	public static void AddMember(GroupMember member) {
		_members.Add(member);
	}

	public static void RemoveMember(GroupMember member) {
		_members.Remove(member);
	}

	public static List<GroupMember> getAllMembers() {
		return _members;
	}
}
