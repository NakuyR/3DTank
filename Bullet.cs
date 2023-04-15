using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power = 500;
    public AudioClip sound;
    public GameObject exp;
    //public GameObject score;
    //public Score = score.GetComponent<Score>();
    //public GameObject Score;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void OnTriggerEnter(Collider col)
    {
        //if(col.gameObject.tag !="bullet"){
            AudioSource.PlayClipAtPoint(sound, transform.position);
            //GameObject copy_exp = Instantiate(exp) as GameObject;
            if(col.gameObject.tag =="WALL")
            {
                //copy_exp.transform.position = col.transform.position;
                Destroy(col.gameObject);
                Debug.Log("WALL");
            }

            else if(col.gameObject.tag =="Enemy")
            {
                Debug.Log("Enemy");
                Score.Counter++;
                if(Score.Counter > 5)
                {
                    //탱크 사라지기
                    //승리화면 
                }
            }
            else if(col.gameObject.tag =="Target")
            {
                Score.Hit++;
                if(Score.Hit>5)
                {
                    //내 탱크 사라짐
                    //패배화면전환
                }
            }
            //copy_exp.transform.position = this.transform.position;
            Destroy(this.gameObject); 
            Debug.Log("Destroy");
        //}   
    }
}   
