    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    //public GameObject target;
    public GameObject bullet;
    public GameObject spPoint;
    //public AudioClip snd;

    private NavMeshAgent nvAgent;
    private Transform target;
    private int rotAngle;
    private float  amtToRot;
    private int power;
    private float distance;
    private Vector3 direction;
    private float moveSpeed;
    private float fTime;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        moveSpeed = 1.0f;
        power = 800;
        fTime = 0.0f;
        rotAngle = 15;
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.transform.position - this.transform.position;
        distance = Vector3.Distance(target.transform.position, this.transform.position);
        fTime += Time.deltaTime;

        if(distance < 15.0f)
        {
            nvAgent.destination = target.position;
            //적 탱크 따라오기 구현
            //transform.LookAt(target.transform.position);
            // amtToRot = rotAngle * Time.deltaTime;
            // transform.RotateAround(Vector3.zero, Vector3.up, amtToRot);
            // this.transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed/2);
            if (fTime > 0.5f)
            {
                //총알 생성
                GameObject obj = Instantiate(bullet) as GameObject;
                obj.transform.position = spPoint.transform.position;
                obj.transform.rotation = spPoint.transform.rotation;
                obj.GetComponent<Rigidbody>().AddForce(direction*power);
                //사운드 처리
                fTime = 0.0f;
            }
        }
    }
}
