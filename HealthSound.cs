using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSound : MonoBehaviour
{

    public AudioSource mySource;
        public AudioClip myClip;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mySource.PlayOneShot(myClip);
        }
    }

}
