using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float fireRate;

    public float projectileDamage;
    public GameObject projectile;

    public GameObject bossTarget;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.initialPosition = transform.position;

        InvokeRepeating("DoDamage", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.initialPosition;
    }

    void DoDamage()
    {
        var newProjectile = Instantiate(this.projectile, transform.position, transform.rotation);

        var angle = Mathf.Atan2(bossTarget.transform.position.y - transform.position.y, bossTarget.transform.position.x - transform.position.x);
        newProjectile.transform.rotation = new Quaternion(0, 0, angle, 0);

        var projectileScript = newProjectile.GetComponent<Projectile>();
        projectileScript.damage = projectileDamage;
        projectileScript.Creator = this.gameObject;
        projectileScript.Target = bossTarget;
    }
}
