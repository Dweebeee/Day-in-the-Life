using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerBullet : MonoBehaviour
{
    int timeBulletAlive = 0;
    private Vector3 shootDir;
    public PlayerShoot playerShoot;
    bool bulletHome = false;
    int num = 0;
    //private int bulletLife = 3;


    // Remove later
    private float angle;

    public void Awake()
    {
        //playerShoot = GameObject.FindObjectOfType<PlayerShoot>();
    }

    public void Setup(Vector3 ShootDir)
    {
        this.shootDir = ShootDir;
        //NOTE THE BULLET ONLY HAS A LIFE OF 10 SECONDS but when it is finally destroyed you can't fire it again
        Destroy(gameObject, 10);
    }

    [SerializeField] float moveSpeed = 10f;
    private void Update()
    {
        //sets the bullet on a path in the direction shot
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collidor)
    {
        
        //if (collidor.gameObject.tag == "Player" || collidor.gameObject.tag == "Other" || collidor.gameObject.tag == "PlayerAttack" || collidor.gameObject.tag == "EnemyAttack")
        //{
        //    //bullet hit player/viewcone; THEREFOR DON'T DESTROY
        //}
        //else
        //{
        //    //if the bullet hits anything else DESTORY it!!!
        //    DestroyBullet();
        //}
        if (collidor.gameObject.tag == "Enemy" || collidor.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }
        
    }
     
    public void DestroyBullet()
    {
        Debug.Log("Destroy Bullet");
        Destroy(this.gameObject);
    }
}
