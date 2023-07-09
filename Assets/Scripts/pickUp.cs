using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public SpriteRenderer srCanPlayer;
    public GameObject WateringCan;
    private bool interactable = false;
    public WaterGarden waterGarden1;
    public WaterGarden waterGarden2;
    public WaterGarden waterGarden3;

    public int waterAmountIndex;
    // Start is called before the first frame update
    void Start()
    {
          
    }
    // When the player enters the trigger box, let them interact with it
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactable = true;

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetButtonDown("Jump"))
        {
            //Then pick up the item (watering can) 2 steps: remove watering can from ground. enable on player
            WateringCan.SetActive(false);

            srCanPlayer.enabled = true;
            // & then pass enable a boolean that tells the player they no hold the watering can
            waterGarden1.wateringCan = true;
            waterGarden2.wateringCan = true;
            waterGarden3.wateringCan = true;
            Debug.Log("watering can in non existent hands");
        }



    }


}
