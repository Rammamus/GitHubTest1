using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int scoreInt;
    public TMPro.TextMeshProUGUI scoreText;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        scoreText.text = scoreInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        scoreText.text = scoreInt.ToString();
    }
}