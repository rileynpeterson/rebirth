using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    public GameObject textGameObject;
    private int score;
    private string sceneNameToLoad;

    void Start () 
    {
        score = 0;
        UpdateScore (); }

        public void AddScore (
        int newScoreValue) {
        score += newScoreValue; UpdateScore (); }

    void UpdateScore () 
    {
        Text scoreTextB = textGameObject.GetComponent<Text>();
        scoreTextB.text = "Gems: " + score;
        Debug.Log ("Gem touch!");
    }
}