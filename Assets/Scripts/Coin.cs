using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Coin : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            //Debug.Log("Score:" + PlayerManager.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
