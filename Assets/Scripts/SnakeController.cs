using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour
{
    public GameObject bodyPrefab;
    public GameObject head;
    public GameObject canvas;
    public float threshold;

    private int length;
    private int score;
    private Vector3 up = new Vector3(0, 0, 1);
    private Vector3 down = new Vector3(0, 0, -1);
    private Vector3 left = new Vector3(-1, 0, 0);
    private Vector3 right = new Vector3(1, 0, 0);
    private Vector3 direction;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        length = 3;
        score = 0;
        direction = up;
        timer = 0;
        for (int i = 0; i < length; i++) {
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(
                head.transform.position.x,
                head.transform.position.y,
                head.transform.position.z - i - 1);
            if (i > 0) {
                body.GetComponent<GameOver>().canvas = canvas.gameObject;
            }
        }
        canvas.transform.GetChild(1).GetComponent<Text>().text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.transform.GetChild(0).gameObject.activeSelf) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) && transform.GetChild(0).position.z <= head.transform.position.z) {
            direction = up;
            head.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (Input.GetKeyDown(KeyCode.S) && transform.GetChild(0).position.z >= head.transform.position.z) {
            direction = down;
            head.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        } else if (Input.GetKeyDown(KeyCode.A) && transform.GetChild(0).position.x >= head.transform.position.x) {
            direction = left;
            head.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        } else if (Input.GetKeyDown(KeyCode.D) && transform.GetChild(0).position.x <= head.transform.position.x) {
            direction = right;
            head.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        if (timer > threshold) {
            for (int i = length - 1; i > 0; i--) {
                transform.GetChild(i).transform.position = transform.GetChild(i - 1).transform.position;
            }
            transform.GetChild(0).transform.position = head.transform.position;
            head.transform.position += direction;
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public void GetApple()
    {
        GameObject body = Instantiate(bodyPrefab, transform);
        body.transform.position = transform.GetChild(length - 1).transform.position;
        body.GetComponent<GameOver>().canvas = canvas.gameObject;
        length += 1;
        if (threshold > 0.1f) {
            threshold -= 0.05f;
        }
        ++score;
        canvas.transform.GetChild(1).GetComponent<Text>().text = "Score: " + score;
    }
}
