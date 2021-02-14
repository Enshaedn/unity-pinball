using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private Renderer bumperRender;
    private GameManager gameManager;
    [SerializeField] private Material bumperColor;
    [SerializeField] private Material bumperHighlight;

    public int pointValue; // Set point value in Unity
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bumperRender = GetComponent<Renderer>();
    }

    IEnumerator RevertMaterial() {
        yield return new WaitForSeconds(1);
        bumperRender.material = bumperColor;
    }

    void OnCollisionEnter(Collision collision) {
        // Update score with the hit bumpers point value
        gameManager.UpdateScore(pointValue);
        bumperRender.material = bumperHighlight;
        StartCoroutine(RevertMaterial());
    }
}
