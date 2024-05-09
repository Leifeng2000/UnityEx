using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public float nextTime = 0;
    public GameObject prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButton("Fire1")&&Time.time>nextTime)
        {
            nextTime = Time.time+0.5f;
            Debug.Log(nextTime);
            Instantiate(prefabs,new Vector3(Random.RandomRange(0,100),0,0),Quaternion.identity);
        }*/
        /*if(Input.GetButton("Fire1"))
        {
            Debug.Log("Fire1");
        }
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Fire2");
        }
        if (Input.GetButton("Fire3"))
        {
            Debug.Log("Fire3");
        }*/

        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(1);
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log(2);
        }*/
        /*if(Input.GetButton("Fire1"))
        {
            Vector3 pos = Input.mousePosition;
            Debug.Log(pos.x + "+" + pos.y);
        }*/
        /*if(Input.GetKey(KeyCode.Escape)) 
        {
            //Debug.Log("Phim BackSpace duoc nhan");
        }

        Debug.LogWarning("Ok");*/
    }
}
