using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using UnityEngine;

public class SpamLinh : MonoBehaviour
{
    public GameObject vitriban;
    Vector3 viTriBan;
    public GameObject linh;
    private float istime;

    private float time;
    public float isSpawm;
    private bool Spawm;
    private float timeSpawn;

   
    // Start is called before the first frame update
    void Start()
    {
        viTriBan = vitriban.transform.position;
        istime = 5;
        

        timeSpawn = 2;
        time = timeSpawn;
        isSpawm = 0;
        Spawm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Golem.isLife == false)
        {
            Destroy(gameObject);
           
        } 
        if (IsBoss.isBoss)
        {

            isSpawm -= LinhBoss.linhDie;
            LinhBoss.linhDie = 0;
            if (isSpawm < 10 )
            {
                Spawm = true;
            }
            istime -= Time.deltaTime;
            if (istime < 0)
            {
                if (Spawm)
                {
                    time -= Time.deltaTime;
                    if (time <= 0)
                    {
                        time = timeSpawn;
                        var bulletmp = Instantiate(linh, viTriBan, Quaternion.identity);
                        
                        isSpawm++;
                        if (isSpawm == 10) { Spawm = false; }

                    }
                }


            }    
        }
      
        
    }

    



}
