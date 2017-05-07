using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthManagement : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth;

    public RectTransform healthBar;

	// Use this for initialization
	void Start () {
        
        if(currentHealth == 0)
        {
            Debug.Log("current health on start : " + currentHealth);
            currentHealth = maxHealth;
            OnChangeHealth(currentHealth);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(currentHealth);
	}

    public void OnPlayerConnected(NetworkPlayer player)
    {
        Debug.Log("on player connect");
        if(!isLocalPlayer)
        {
            
        }
        
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        Debug.Log("current health take damage : " + currentHealth);
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            RpcRespawn();
            Debug.Log("Dead!!!");
        }

    }

    public void OnChangeHealth(int health)
    {
        Debug.Log("Change health bar, health : "+ health);
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }
}
