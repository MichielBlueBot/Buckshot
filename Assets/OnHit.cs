using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Collider otherCollider = contact.otherCollider;
			if(otherCollider.gameObject.layer == LayerMask.NameToLayer("Foundation") ||
			   otherCollider.gameObject.layer == LayerMask.NameToLayer("Obstacles")){
				// TODO: Cause explosion ...
				this.gameObject.SetActive(false);
			} else if(otherCollider.gameObject.layer == LayerMask.NameToLayer("Players")){
				// We hit a player
				// TODO: Cause explosion ...
				// TODO: Hit player ...
			}
		}		
	}
}
