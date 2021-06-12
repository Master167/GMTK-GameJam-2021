using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;

    public float Angle;
    public Vector3 Position1;
    public Vector3 Position2;
    public Vector3 Position3;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.transform.parent.gameObject;
        Boss = GameObject.FindGameObjectWithTag(Tags.Boss);
    }

    // Update is called once per frame
    float count = 0.0f;
    void Update()
    {
        if (count < 1.0f)
        {
            count += 1.0f * Time.deltaTime;

            Vector3 m1 = Vector3.Lerp(Position1, Position2, count);
            Vector3 m2 = Vector3.Lerp(Position2, Position3, count);
            var direction = Vector3.Lerp(m1, m2, count);
            Utility.Move(direction, transform, 10, true);
        }
    }

    void OnEnable()
    {
        Invoke(nameof(EndSwing), 1f);

        var heading = Boss.transform.position - Player.transform.position;
        var distance = heading.magnitude;

        Position2 = heading / distance;

        var y = new Vector3(
            (Position2.magnitude * Mathf.Cos(Angle) * Position2.x),
            (Position2.magnitude * Mathf.Sin(Angle) * Position2.y)
            );


        Position1 = y;

        var z = new Vector3(
            (Position2.magnitude * Mathf.Cos(-Angle) * Position2.x),
            (Position2.magnitude * Mathf.Sin(-Angle) * Position2.y)
            );

        transform.localPosition = y;


        Position3 = z;

    }

    void EndSwing()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // It's not the boss, I don't care
        if (!collision.collider.CompareTag(Tags.Boss)) { return; }


    }
}
