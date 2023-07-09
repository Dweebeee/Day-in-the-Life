using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float angle;
    public PlayerShoot playerShoot;
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RotatePlayerToMouse();
    }

    // Player movement now in fixed update because PHYSICS
    private void FixedUpdate()
    {
        // sets the player velocity to 0 so that when a velocity is applied from anything else the scene it does not continue to effect the player
        //Movment
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //Debug.Log(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized);
            rb.position += new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        }
    }
    public void RotatePlayerToMouse()
    {
        // Code to rotate the player so that they always face the camera
        // finds the mouses position relative to 0, 0 world position
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // converts the x & y coordinates from the the previous step to an angle (first in radians & then converted to degrees)
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // finally it rotates the players sprite so that it corresponds with this angle(direction)
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        // Calls a script to update the angle text on screen
        //gameplayManager.UpdateAngle(((int)angle));
        //Debug.Log(angle);
        playerShoot.ShootingAngle(angle);
    }
}
