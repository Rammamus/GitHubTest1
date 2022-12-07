using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScoreScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI deathScoreText;
    public ScoreScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindObjectOfType<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        deathScoreText.text = "Score: " + scoreScript.scoreInt;
    }
}
