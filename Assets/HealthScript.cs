using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float standardBaseHealth = 100;
	public float maxHealth = 100;
	private float currentHealth;
	private bool alive;

	// Use this for initialization
	void Start () {
		currentHealth = standardBaseHealth;
		alive = (currentHealth > 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getCurrentHealth(){
		return currentHealth;
	}

	public bool isAlive(){
		return alive;
	}

	public void applyDamage(float amount){
		Debug.Log (this.tag+" took "+amount+" damage.");
		currentHealth -= amount;
		if(currentHealth<=0){
			alive = false;
		}
	}

	public void applyHeal(float amount){
		Debug.Log (this.tag+" healed for "+amount+".");
		currentHealth += amount;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}
}
