using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {
    public int enemyHealth;

    public GameObject deathEffect;

    public int pointsOnDeath;
	
	void Update () {
	    if(enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnDeath);
            Destroy(gameObject.transform.parent);
        }
	}

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }


}
