using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    public GameObject alarm;
    public AudioSource sound;
    private bool playing = true;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // Need to add a UI text that comes up above the alarm saying " interact 'e' "


            if (Input.GetButton("Jump") && playing)
            {
                Debug.Log("Alarm off");
                sound.Stop();
                playing= false;
            }
        }
    }
}
