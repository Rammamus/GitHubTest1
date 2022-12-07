using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public BulletScript ProjectilePreFab;
    public Transform LaunchOffset;
    [SerializeField] KeyCode fire;

    public float fireRate = 0.00001f;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(fire) && timer > fireRate)
        {
            Instantiate(ProjectilePreFab, LaunchOffset.position, transform.rotation);
            timer = 0;
        }
    }

    /* why doesn't it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
    */
}
