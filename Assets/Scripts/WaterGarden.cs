using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGarden : MonoBehaviour
{
    private bool interactable = false;
    public bool wateringCan;
    public Sprite bushWatered;
    public SpriteRenderer spriteRenderer;
    public PickUp pickUp; 
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
        if (interactable && Input.GetButtonDown("Jump") && wateringCan)
        {
            //Then pick up the item (watering can) 2 steps: remove watering can from ground. enable on player
            spriteRenderer.sprite = bushWatered;

            //Increment the water amount index to indicate that the watering can now holds 1 part less
            pickUp.waterAmountIndex++;
            // & then pass enable a boolean that tells the player they no hold the watering can
        }
    }
}
