using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float speed;

    public Slider aggroSlider;

    public GameObject CurrentTarget;
    public GameObject Player;

    private bool targetInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get Player
        Player = GameObject.FindGameObjectWithTag(Tags.Player);

        // Boxx moves as half speed of player
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

        Move(direction);

        UpdateAggro();
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    private void Move(Vector2 direction)
    {
        //Find the screen limits to the player's movement
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //Get the player's current position
        Vector2 pos = transform.position;
        //Calculate the proposed position
        pos += direction * speed * Time.deltaTime;
        //Ensure that the proposed position isn't outside of the limits
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Update the player's position
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(CurrentTarget))
        {
            Debug.Log("In Range");
            targetInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(CurrentTarget))
        {
            Debug.Log("out of Range");
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
}
