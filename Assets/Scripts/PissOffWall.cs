using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissOffWall : MonoBehaviour
{
    bool interactable = false;
    public GameObject wall;

    // Update is called once per frame
    void Update()
    {
        if (interactable == true && Input.GetButtonDown("Jump"))
        {
            wall.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
}
