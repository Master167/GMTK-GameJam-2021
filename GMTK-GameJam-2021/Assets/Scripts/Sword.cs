using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.transform.parent.gameObject;
        Boss = GameObject.FindGameObjectWithTag(Tags.Boss);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        Invoke(nameof(EndSwing), 1f);
    }

    void EndSwing()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // It's not the boss, I don't care
        if (!collision.collider.CompareTag(Tags.Boss)) { return; }

        Debug.Log("Hit Boss");
        EndSwing();
    }
}
