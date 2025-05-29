using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public PlayerHealthController playerHealth;
    public bool damageable = true;

    public float IFrameLength = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GetComponent<PlayerHealthController>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealthController is missing!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (damageable && other.gameObject.CompareTag("Damage"))
        {
            Debug.Log("hite by " + other);
            playerHealth.TakeDamage();
            damageable = false;
            //StartCoroutine(IFrames());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            damageable = true;
            Debug.Log("you can now be hit again");

        }

    }

    //IEnumerator IFrames()
    //{
    //    Debug.Log("starting IFrame after" + IFrameLength);
    //    Debug.Log("player is not damageable");
    //    yield return new WaitForSeconds(IFrameLength);
    //    damageable = true;
    //    Debug.Log("player is damage");
    //}
}
