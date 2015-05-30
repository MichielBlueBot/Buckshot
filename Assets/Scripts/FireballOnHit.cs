using UnityEngine;
using System.Collections;

public class FireballOnHit: MonoBehaviour {

	public GameObject fireExplosion;
	public float fireballDamage = 20;
	public float fireballExplosionDamage = 10;
	private bool alreadyCollided = false; // Make sure the fireball only collides with 1 object.

	void OnCollisionEnter(Collision collision) {
		if (!alreadyCollided) {
			alreadyCollided = true;
			ContactPoint contact = collision.contacts [0];
			Collider otherCollider = contact.otherCollider;
			if (otherCollider.gameObject.layer == LayerMask.NameToLayer ("Foundation") ||
				otherCollider.gameObject.layer == LayerMask.NameToLayer ("Obstacles")) {
				createFireExplosion (transform.position);
				this.gameObject.SetActive (false);
			} else if (otherCollider.gameObject.layer == LayerMask.NameToLayer ("Players")) {
				// We hit a player
				createFireExplosion (transform.position);
				HealthScript otherHealth = otherCollider.gameObject.GetComponent<HealthScript> ();
				if (otherHealth != null) {
					otherHealth.applyDamage (fireballDamage);
				}
			}
		}
	}

	private void createFireExplosion(Vector3 origin, float size = 1){
		GameObject explosion = (GameObject) Instantiate (fireExplosion, origin, Quaternion.identity);
		explosion.transform.localScale *= size;
		applyFireExplosionForce (origin);
	}
	
	private void applyFireExplosionForce(Vector3 origin, float radius = 100, float power = 10){
		Collider[] colliders = Physics.OverlapSphere(origin, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			//Debug.Log (hit+" was hit by explosion.");
			if (rb != null){
				//Debug.Log (rb+" has a rigidbody.");
				rb.AddExplosionForce(power, origin, radius, 3.0F);
				HealthScript otherHealth = rb.gameObject.GetComponentInParent<HealthScript>();
				if(otherHealth!=null){
					//Debug.Log (rb+" has a healthscript!");
					otherHealth.applyDamage(fireballExplosionDamage);
				}
			}
		}
	}
}
