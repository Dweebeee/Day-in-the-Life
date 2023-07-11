using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatWaveManager : MonoBehaviour
{
    //public List<EnemyAI> knightsAI; // TODO remove this.
    int wavesPassed = 0; // Current number of waves completed. Incremented when the last enemy in a wave is killed.
    int enemiesKilled = 0; // Number of enemies killed in the current wave. Reset to 0 when new wave is started.
    public List<int> waveEnemies; // List of the number of enemies to spawn in each wave.
    public List<Vector3> enemySpawns; // List of possible places for the enemies to spawn.
    public List<GameObject> currentEnemies; // All the current enemies that have been created in the current wave.
    public GameObject knightPrefab; // The prefab of the knight to create.

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
        // Change wave numbers.
        wavesPassed++;
        enemiesKilled = 0;

        // Delete any remaining objects in the currentEnemies list if they haven't already been destroyed.
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            Destroy(currentEnemies[i]);
        }

        // If we are not at the last wave listed, move on to the next wave.
        if (wavesPassed <= waveEnemies.Count)
        {
            Debug.Log("Starting next wave");
            SpawnWaveEnemies();
        }
    }

    private void SpawnWaveEnemies()
    {
        // Set up a random class to all random knight spawn.
        System.Random rnd = new System.Random();

        for (int i = 0; i < waveEnemies[wavesPassed]; i++)
        {
            Debug.Log("Wave " + Convert.ToString(wavesPassed) + " knight " + Convert.ToString(i) + " spawned");
            //Debug.Log($"Wave {wavesPassed} knight {i} spawned.");

            //knightsAI[i].combat = true;

            // Get a spawn location.
            int randomSpawnIndex = rnd.Next(0, 23);

            // Create a new enemy.
            currentEnemies.Add(Instantiate(knightPrefab, enemySpawns[randomSpawnIndex], Quaternion.Euler(0, 0, 0)));

            // Need to enable AI? If so:
            //currentEnemies[i].combat = true;

        }
    }
}
