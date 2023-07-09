using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool enabledAtStart = false;
    public void Awake()
    {
         this.enabled = enabledAtStart; 
    }

    public float bulletCooldown;

    // Boolean so that shooting is a toggle i.e. you can only shoot when there is no bullet in the air
    public bool bulletShot = false;
    // Gets the angle the player is looking at
    private Quaternion shootAngle;
    public void ShootingAngle(float angle)
    {
        shootAngle = Quaternion.Euler(0, 0, angle);

    }

    //Note serializefield enables us to edit the value of the variable in the editor but keeps it private
    [SerializeField] private Transform pfBullet;
    //Note we are not using this variable at the moment; why it = 0
    private float GPD = 0f; //GunPositionDifference i.e. where is the end of the barrel of the gun

    void Update()
    {
        // Shoot
        //if (Input.GetKeyDown(KeyCode.Mouse2))
        //{
        //    Debug.Log(bulletShot);
        //}

        if (Input.GetKeyDown(KeyCode.Mouse1) && bulletShot == false)
        {

            Vector3 gunPosition = transform.position + (transform.right * GPD);
            // Creates the bullet clone
            Transform bulletTransform = Instantiate(pfBullet, gunPosition, shootAngle);
            //Shoot direction?
            Vector3 shootDir = transform.up.normalized;
            // Gets the player bullet transform & then call s the subroutine within PlayerBullet Setup which sets up the bullet on its path
            bulletTransform.GetComponent<PlayerBullet>().Setup(shootDir);
            //Debug.Log(shootDir);
            bulletShot = true;
            StartCoroutine(BulletCooldown());
        }
    }



    // THis coroutine is used to reset the players shot ability after bullet cooldown amount of time
    IEnumerator BulletCooldown()
    {

        // wait bulletCooldown amount of seconds before allowing the player to shoot another bullet
        yield return new WaitForSeconds(bulletCooldown);
        // THen reset the shot so that the player can shoot again
        ResetShoot();
    }


    public void ResetShoot()
    {
        bulletShot = false;
    }
}