using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource track01_Menu; // Trigger on awake
    public AudioSource track02_DarkLord; // Trigger on alarm off
    public AudioSource track03_KnightFight; // Trigger on dialogue finish in battle
    public AudioSource crackle; // Trigger on scene change to castle

    // 1 = Menu, 2 = Castle, 3 = Battle
    public int sceneIndex;

    public void StartMenuMusic()
    {
       track01_Menu.Play(0);
       Debug.Log("Playing Track 1: Menu");
    }

    public void StopMenuMusic()
    {
        track01_Menu.Stop();
        Debug.Log("Stopping Menu Music");
    }

    public void StartAmbientMusic()
    {
       track02_DarkLord.Play(0);
       Debug.Log("Playing Track 2: Dark Load");
    }

    public void StopAmbientMusic()
    {
        track02_DarkLord.Pause();
        Debug.Log("Pausing Ambient Music");
    }

    public void StartBattleMusic()
    {
        track03_KnightFight.Play(0);
        Debug.Log("Playing Track 3: Knight Fight");
    }
    
    public void StopBattleMusic()
    {
        track03_KnightFight.Pause();
        Debug.Log("Pausing Battle Music");
    }

    public void StartCrackleMusic()
    {
        crackle.Play(0);
        Debug.Log("Playing crackle");
    }
    
    public void StopCrackleMusic()
    {
        crackle.Stop();
        Debug.Log("Stopping crackle");
    }

    private void Awake()
    {
        if (sceneIndex == 1)
        {
            StartMenuMusic();
        }
        else if (sceneIndex == 2)
        {
            StartCrackleMusic();
        }
    }
}