using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheGamer : MonoBehaviour
{
    Vector3 dir;

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode left;
    [SerializeField] float playerSpeed;

    public SpriteRenderer spriteRenderer;
    public GameObject enemyBehav;
    public BulletSpawn bulletSpawn;
    public HealthBar healthBar;

    public float maxHP = 100;
    public float curHP = 0;
    public float curXP = 0;
    public float maxXP = 100;
    public float playDmg = 10;

    public int enemiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        bulletSpawn = GameObject.FindObjectOfType<BulletSpawn>();

    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(up) && transform.position.y <= 10.49f)
        {
            transform.position += new Vector3(0, playerSpeed, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(down) && transform.position.y >= -10.49f)
        {
            transform.position -= new Vector3(0, playerSpeed, 0) * Time.deltaTime;
        }
        
        if (Input.GetKey(right) && transform.position.x <= 10.49f)
        {
            transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(left) && transform.position.x >= -10.49f)
        {
            transform.position -= new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
            spriteRenderer.flipX = false;
        }

        //death
        if (curHP < 1)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //xp gain
        if (enemiesKilled > 0)
        {
            curXP += 10;
            enemiesKilled = 0;
        }
        //lvl up
        if (curXP >= maxXP)
        {
            curXP = 0;
            maxXP += 10;
            curHP += 5;
            playDmg *= 1.05f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHP -= enemyBehav.GetComponent<EnemyBehav>().enemyDmg;
            healthBar.SetHealth(curHP);
        }
    }
}
