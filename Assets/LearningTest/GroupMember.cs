using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Renderer))]
public class GroupMember : MonoBehaviour {
	public GroupDefinition groupDef;
	private Renderer _renderer;
	public void SetColor(Color color) {
		if (_renderer == null) {
			_renderer = GetComponent<Renderer> ();
		}

		_renderer.material.color = color;
	}
}