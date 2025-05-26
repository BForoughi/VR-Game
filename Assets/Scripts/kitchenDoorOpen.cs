using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenDoorOpen : MonoBehaviour
{
    public AudioClip openSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            audioSource.playOnAwake = false;
        }
    
    // Update is called once per frame
   public void playDoorOpenSound()
    {
        audioSource.PlayOneShot(openSound); 
    }
}
