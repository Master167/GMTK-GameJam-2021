using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var bossDirection = Vector3.up;// Just roll with it
    }

    void OnEnable()
    {
        Debug.Log("Swoard enabled");
        Utility.Move(Vector3.up, this.transform, 1);

        Invoke(nameof(EndSwing), 0.5f);
    }

    void EndSwing()
    {
        Debug.Log("EndSwing");
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // It's not the boss, I don't care
        if (!collision.collider.CompareTag(Tags.Boss)) { return; }


    }
}
