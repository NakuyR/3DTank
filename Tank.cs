using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{   
    #region 변수 선언
    public int moveSpeed;
    public float move;
    public float moveVertical;
    public int rotSpeed;
    public float rotate;
    public float rotHorizon;
    public float rotTurret;
    public GameObject turret;
    public GameObject gun;
    public int power;
    public GameObject bulletPrefab;
    public Transform spPoint;
    public float DestroyTime = 2.0f;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
        rotSpeed = 120;
    }

    // Update is called once per frame
    void Update()
    {
        move = moveSpeed * Time.deltaTime;
        rotate = rotSpeed * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical");
        rotHorizon = Input.GetAxis("Horizontal");
        rotTurret = Input.GetAxis("Window Shake X");
        transform.Translate(Vector3.forward * move * moveVertical);
        transform.Rotate(new Vector3(0.0f, rotate * rotHorizon, 0.0f));
        turret.transform.Rotate(Vector3.up * rotTurret * rotate);

        float keyGun = Input.GetAxis("Mouse ScrollWheel");
        gun.transform.Rotate(Vector3.right * keyGun * 4);

        Vector3 ang = gun.transform.eulerAngles;
        if (ang.x > 180)
            ang.x -=360;
        ang.x  =Mathf.Clamp(ang.x,-15,5);
        gun.transform.eulerAngles = ang;
        
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, spPoint.position,spPoint.rotation) as GameObject;
            //Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
            //bulletAddforce.AddForce(turret.transform.forward * power);
            //Destroy(bullet,DestroyTime);    
        }
    }


}
