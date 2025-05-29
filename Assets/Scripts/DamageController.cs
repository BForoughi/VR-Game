using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public PlayerHealthController playerHealth;
    public bool damageable = true;

    public float IFrameLength = 2;
    private float lastDamageTime = -Mathf.Infinity;

    public AudioClip playerHit;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GetComponent<PlayerHealthController>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealthController is missing!");
        }

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if (damageable && other.gameObject.CompareTag("Damage"))
        //{
        //    Debug.Log("hite by " + other);
        //    damageable = false;
        //    playerHealth.TakeDamage();
        //    StartCoroutine(IFrames());
        //}

        if (Time.time - lastDamageTime > IFrameLength && other.gameObject.CompareTag("Damage"))
        {
            lastDamageTime = Time.time;
            playHitSound();
            Debug.Log("hite by " + other);
            //damageable = false;
            playerHealth.TakeDamage();

        }
    }

        void playHitSound()
        {
            audioSource.PlayOneShot(playerHit);
            Debug.Log("hit sound");
        }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Damage"))
    //    {
    //        damageable = true;
    //        Debug.Log("you can now be hit again");

    //    }

    //}

    //IEnumerator IFrames()
    //{
    //    Debug.Log("starting IFrame after" + IFrameLength);
    //    Debug.Log("player is not damageable");
    //    yield return new WaitForSeconds(IFrameLength);
    //    damageable = true;
    //    Debug.Log("player is damage");
    //}

}
