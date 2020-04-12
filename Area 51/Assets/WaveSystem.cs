using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    Text Waves;
    public int waveNum = 1;
    public GameObject waveComplete;
    // Start is called before the first frame update
    void Start()
    {
        Waves = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Waves.text = "Wave: " + waveNum.ToString();
        if (EnemyBehavior.killcount == EnemyRandomSpawn.enemySpawnInit)
        {
            waveComplete.SetActive(true);
            EnemyRandomSpawn.enemySpawnInit += 3;
            EnemyBehavior.killcount = 0;
            waveNum += 1;
            Time.timeScale = 0;
            inventoryMenu.canOpenInv = false;
        }
        Debug.Log(EnemyRandomSpawn.enemySpawnInit + " en spawn init");
    }
}
