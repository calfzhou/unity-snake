using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject snake;
    public int freq = 3;
    public int activeFreq = 2;

    private float timer;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active && timer > snake.GetComponent<SnakeController>().threshold * freq) {
            transform.GetChild(0).gameObject.SetActive(true);
            active = true;
            timer = 0f;
        } else if (active && timer > snake.GetComponent<SnakeController>().threshold * activeFreq) {
            transform.GetChild(0).gameObject.SetActive(false);
            active = false;
            timer = 0f;
        } else {
            timer += Time.deltaTime;
        }
    }
}
