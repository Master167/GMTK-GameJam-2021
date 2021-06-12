using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float speed;

    public float health;

    public Slider aggroSlider;// Maybe put this on the game manager?

    public GameObject CurrentTarget;
    public GameObject Player;

    private bool targetInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        // Box moves as half speed of player
        var playerScript = Player.GetComponent<Player>();
        speed = playerScript.speed / 2;

        // Set target as player.
        CurrentTarget = Player;

        aggroSlider.value = aggroSlider.maxValue / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets a vector that points from the player's position to the target's.
        var heading = CurrentTarget.transform.position - transform.position;

        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        Utility.Move(direction, transform, speed);

        UpdateAggro();
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(CurrentTarget))
        {
            targetInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(CurrentTarget))
        {
            targetInRange = false;
        }
    }

    private void UpdateAggro()
    {
        if (targetInRange)
        {
            aggroSlider.value += .01f;
        }
        else
        {
            aggroSlider.value -= .01f;
        }
    }

    public void RecieveDamage(GameObject Source, float damageAmount)
    {
        // Update this later
        CurrentTarget = Source;
        health -= damageAmount;
    }
}
