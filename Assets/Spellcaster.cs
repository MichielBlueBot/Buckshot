using UnityEngine;
using System.Collections;

public class Spellcaster : MonoBehaviour {

	public SpellCreator spellCreator;
	public Transform m_Character;

	public float fireballSpeed = 30;

	public void FireTo(Vector3 point){
		Vector3 fireDirection = point - m_Character.position;
		fireDirection.y = 0;
		fireDirection.Normalize ();
		castFireball (fireDirection);
	}

	private void castFireball(Vector3 direction){
		spellCreator.createFireball (m_Character.position, direction, fireballSpeed);
	}
}
