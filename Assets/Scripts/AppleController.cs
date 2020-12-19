using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    public GameObject snake;
    public Material[] materials;

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
            snake.GetComponent<SnakeController>().GetApple();
            int x = Random.Range(0, 19);
            int z = Random.Range(0, 19);
            int y = Random.Range(0, 2);
            transform.position = new Vector3(x + 0.5f, y, z + 0.5f);
            transform.GetComponent<MeshRenderer>().material = materials[y];
        } else if (coll.name == "Body(Clone)" || coll.tag == "Trap") {
            int x = Random.Range(0, 19);
            int z = Random.Range(0, 19);
            int y = Random.Range(0, 2);
            transform.position = new Vector3(x + 0.5f, y, z + 0.5f);
            transform.GetComponent<MeshRenderer>().material = materials[y];
        }
    }
}
