using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject cameraPoint;
    public static GameObject currentRoom;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && currentRoom != cameraPoint)
        {
            mainCamera.transform.position = cameraPoint.transform.position;
            currentRoom = cameraPoint;
        }
    }
}
