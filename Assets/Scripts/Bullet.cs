using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime;
    public GameObject particle;

    public float speed;
    public Rigidbody2D rb;
    public LayerMask whatCanBeShot;
    public float distance;
    public float damage;
    private SpriteRenderer sr;

    private void Start()
    {
        System.Func<AudioManager> Audi = GetComponent<AudioManager>;
        Invoke("Destroyprojectile", destroyTime);
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatCanBeShot);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
               
                Destroyprojectile();
                hitInfo.collider.GetComponent<TakeDamage>().Takedamage(damage);
                Instantiate(particle, transform.position, Quaternion.identity);
                CameraShake.Shake(0.3f, 0.1f);
                hitInfo.collider.GetComponent<Rigidbody2D>().AddForce(new Vector3(hitInfo.collider.transform.position.x * 80, hitInfo.collider.transform.position.y * -75, hitInfo.collider.transform.position.z));

            }
            else if (hitInfo.collider.CompareTag("Ground"))
            {
                    Destroyprojectile();
                    Instantiate(particle, transform.position, Quaternion.identity);
                    CameraShake.Shake(0.3f, 0.07f);

            }
            Destroyprojectile();

        }
            rb.velocity = transform.right * speed;
    }

        void Destroyprojectile()
        {
            Destroy(gameObject);
        }

}
