using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatWaveManager : MonoBehaviour
{
    public List<EnemyAI> knightsAI;
    int wavesPassed = 0;
    public List<int> waveEnemies;
    int enemiesKilled = 0;

    public void enemyKilled()
    {
        enemiesKilled++;
        Debug.Log("Enemy kill registered, " + Convert.ToString(enemiesKilled) + " enemies killed");
        if (enemiesKilled >= waveEnemies[wavesPassed])
        {
            incrementWave();
        }
    }

    public void incrementWave()
    {
        wavesPassed++;
        enemiesKilled = 0;
        Debug.Log("Starting next wave");
        startNextWave();
    }

    private void startNextWave()
    {
        for (int i = 0; i < waveEnemies[wavesPassed]; i++)
        {
            Debug.Log("Wave " + Convert.ToString(wavesPassed) + " knight " + Convert.ToString(i) + " Spawned");
            knightsAI[i].combat = true;
        }
    }
}
