using UnityEngine;
using System.Collections;

public class Spellcaster : MonoBehaviour {

	private SpellCreator spellCreator;
	public Transform m_Character;

	public float fireballSpeed = 30;

	void Start(){
		this.spellCreator = GetComponent<SpellCreator> ();
	}

	public void FireTo(Vector3 point){
		Vector3 fireDirection = point - m_Character.position;
		fireDirection.y = 0;
		fireDirection.Normalize ();
		castFireball (fireDirection);
	}

	private void castFireball(Vector3 direction){
		float height = m_Character.gameObject.GetComponentInChildren<CapsuleCollider> ().bounds.size.y;
		spellCreator.createFireball (m_Character.position + new Vector3(0,height/2.0f,0), direction, fireballSpeed);
	}
}
