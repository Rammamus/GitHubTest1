using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    Vector3 dir;
    public ScoreScript scoreScript;
    public TheGamer theGamer;

    public SpriteRenderer spriteRenderer;
    public GameObject player;
    public EnemySpawner enemySpawner;

    public float speed;
    private float distance;

    public float enemyHP = 8;
    public float enemyDmg = 15;
    float pwrUpTimer;


    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindObjectOfType<ScoreScript>();
        theGamer = GameObject.FindObjectOfType<TheGamer>();
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (enemyHP < 1)
        {
            theGamer.curHP += 10;
            theGamer.enemiesKilled++;
            Destroy(this.gameObject);
            scoreScript.scoreInt += 5;
        }

        //power up
        pwrUpTimer += Time.deltaTime;

        if (pwrUpTimer > 50)
        {
            enemyDmg *= 1.1f;
            enemyHP *= 1.1f;
            enemySpawner.maxEnemy++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyHP -= theGamer.playDmg;
            Destroy(collision.gameObject);
        }
    }
}
