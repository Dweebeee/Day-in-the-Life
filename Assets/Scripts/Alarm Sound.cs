using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    public GameObject alarm;
    public MusicManager musicManager;
    public AudioSource sound;
    private bool playing = true;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButton("Jump") && playing)
            {
                Debug.Log("Alarm off");
                sound.Stop();
                playing = false;
                musicManager.StartAmbientMusic();
                musicManager.StopCrackleMusic(); // Assumes the music is already running.
            }
        }
    }
}
