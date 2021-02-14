using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision) {
        // If the ball leaves the pinball machine it will be destroyed once it hits the plane
        if(collision.gameObject.CompareTag("Finish")) {
            gameManager.isBallActive = false;
            Destroy(gameObject);
        }
    }
}
