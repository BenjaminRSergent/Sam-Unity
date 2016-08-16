using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ForcePriority{
	LOW,
	MEDIUM,
	HIGH
}

public struct ForceRequest{
	public Vector3 movement;
	public ForcePriority priority;
}

