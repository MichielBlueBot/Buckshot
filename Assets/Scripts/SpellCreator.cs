using UnityEngine;
using System.Collections;

public class SpellCreator : MonoBehaviour {

	public Rigidbody fireballPrefab;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void createFireball (Vector3 origin, Vector3 direction, float fireballSpeed)
	{
		//Debug.Log ("Spawning fireball @" + origin + " in direction " + direction + " with speed " + fireballSpeed);
		Rigidbody fireball = (Rigidbody) Instantiate(fireballPrefab, origin + direction*1.5f, Quaternion.identity);
		fireball.velocity = direction*fireballSpeed;
	}
}
