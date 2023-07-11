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

/*
Wake up
Turn alarm off
Minion: Good Morning my lord! We have brought the princess asd you requestied.
Lord: Good, ill see her at the earliest chance, i need to do some chores first though
Leave room

Entering greenhouse
Lord: Now where did i leave my watering can?

Entering storage shed
Lord: There�s my watering can! Now i can water my lovely flowers

Entering Dining room
Interact with minion
Minion: Good morning my lord! What can we do for you
Lord: Since you all made such quick work gathering the princess you deserve a big promotion!
Lord: You�ve been promoted to [SOMETHING] !
Minion: Yay thank you sire!

Entering princess bedroom
Lord: Good morning princess
Princess: Morning sir, thank you for inviting me stay at your castle while all this chaos happens
Lord: no problem do yo-
Crier: FUCKERS ARE AT THE GATES
Princess: Let me handle it, i caused all this mess anyway
Princess: Can I borrow some weapons?
Lord: Sure we don�t use them anyway, and you know i don�t like violence so try to keep it quiet
Go to fight

*/