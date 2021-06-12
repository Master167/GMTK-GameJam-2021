using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Boss;

    public Slider BossHealthSlider;
    public Slider BossAggroSlider;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        var bossScript = Boss.GetComponent<Boss>();

        BossHealthSlider.value = bossScript.Health;
        BossAggroSlider.value = bossScript.currentTargetAggro;
    }
}
