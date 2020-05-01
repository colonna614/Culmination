using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverReset : MonoBehaviour
{
    public GameObject MainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Return)&& MainCharacter.activeSelf == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                EnemyRandomSpawn.enemySpawnInit = 10;
                EnemyBehavior.killcount = 0;
                TheShop.currency = 0;
            Time.timeScale = 1;
            MoveAndShootMouse.purchasedShotgun = false;
        }

    }
}
