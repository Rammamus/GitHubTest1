using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject target;
    [SerializeField] public float speed;
    public Rigidbody2D rb;


    float distance;
    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        target = GameObject.FindWithTag("Enemy");

        float v = Vector2.Distance(transform.position, target.transform.position);
        distance = v;
        Vector2 direction = target.transform.position - transform.position;

        Vector3 offset = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, offset);


        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        */
        rb.velocity = -transform.right * speed;

        if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
