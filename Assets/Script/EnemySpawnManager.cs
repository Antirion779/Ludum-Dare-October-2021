using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;

    [SerializeField]
    GameObject enemy;

    public bool killEnemyObjectif;

    private GameObject[] enemyInGame;
    private GameObject[] bulletInGame;
    private GameObject[] enemyBulletInGame;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void SpawnEnemy()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        int x = 0;
        int y = 0;

        while (pos == new Vector3(GameManager.positionPlayerX, GameManager.positionPlayerY, 0) || PlateauManager.itemInPlateau[x, y] == true || pos == new Vector3(GameManager.positionPlayerX, y, 0) || pos == new Vector3(x, GameManager.positionPlayerY, 0))
        {
            x = Random.Range(0, GameManager.taillePlateau);
            y = Random.Range(0, GameManager.taillePlateau);
            pos = new Vector3(x, y, 0);
        }
        Instantiate(enemy, pos, Quaternion.identity);
    }

    public void EnemyIsObjectif()
    {
        if (killEnemyObjectif)
        {
            GameManager.instance.gameIsOn = false;
            GameManager.score++;
        }
    }

    public void ResetEnemy()
    {
        enemyInGame = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemyInGame)
        {
            Destroy(enemy);
        }
    }

    public void ResetBullet()
    {
        enemyBulletInGame = GameObject.FindGameObjectsWithTag("EnemyBall");
        foreach (GameObject enemyBullet in enemyBulletInGame)
        {
            Destroy(enemyBullet);
        }

        bulletInGame = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bulletInGame)
        {
            Destroy(bullet);
        }
    }
}
