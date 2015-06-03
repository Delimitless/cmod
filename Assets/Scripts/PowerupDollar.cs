using UnityEngine;
using System.Collections;

public class PowerupDollar : MonoBehaviour {

    public float cashAmount = 100.0f;
    public AudioClip clip = null;

    private AudioSource sfx = null;

    void Start() {
//        GameObject soundsObject = GameObject.FindGameObjectWithTag("sounds");
//
//        if (soundsObject == null) {
//            return;
//        }
//
//        sfx = soundsObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("player")) {
            return;
        }

        if (sfx) {
            sfx.PlayOneShot(clip, 1.0f);
        }

        gameObject.SetActive(false);

//        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
//
//        if (pc) {
//            pc.Cash += cashAmount;
//        }
    }
}
