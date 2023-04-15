using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos + player.transform.position;
    }
}
