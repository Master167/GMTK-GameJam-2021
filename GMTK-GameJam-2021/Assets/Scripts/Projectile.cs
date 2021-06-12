using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;

    public float TimeAlive;

    public GameObject Creator;
    public GameObject Target;

    private Transform TargetLocation;

    // Start is called before the first frame update
    void Start()
    {
        if (TimeAlive <= 0)
        {
            TimeAlive = 5;
        }

        Invoke("Die", TimeAlive);

        TargetLocation = Target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var heading = TargetLocation.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        Utility.Move(direction, transform, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider as BoxCollider2D;
        if (collider == null)
        {
            return;
        }

        if (collider.gameObject.Equals(Creator))
        {
            return;
        }

        if (collider.gameObject.CompareTag(Tags.Boss))
        {
            var bossScript = collider.gameObject.GetComponent<Boss>();
            bossScript.RecieveDamage(Creator, damage);
        }

        Destroy(this.gameObject);
    }
}
