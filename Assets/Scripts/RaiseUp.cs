using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseUp : MonoBehaviour
{
    public GameObject snake;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Head") {
            snake.GetComponent<SnakeController>().RaiseUp();
        }
    }
}
