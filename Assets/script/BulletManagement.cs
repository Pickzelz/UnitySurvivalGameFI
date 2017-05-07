using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagement : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colltion masuk");
        GameObject hit = collision.gameObject;
        HealthManagement Health = hit.GetComponent<HealthManagement>();

        if(Health != null)
        {
            Debug.Log("current health : " + Health.currentHealth);
            Health.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
