using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject pinballPrefab;
    private GameManager gameManager;
    private int[] zSpawns = {-4, 4};

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.isGameActive && !gameManager.isBallActive && Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(pinballPrefab, RandomPosition(), pinballPrefab.transform.rotation);
            gameManager.isBallActive = true;
            gameManager.UpdateBallCount(-1);
        }
    }

    Vector3 RandomPosition() {
        int randomInt = Random.Range(0, 2);
        return new Vector3(pinballPrefab.transform.position.x, pinballPrefab.transform.position.y, zSpawns[randomInt]);

    }
}
