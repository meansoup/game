using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour {

  
	void Start () {
 
        DBManager mDBM = new DBManager();
        int[] temp = mDBM.GetPlayer();

        Debug.Log("getPlayer");
        Debug.Log(temp[0]);
        Debug.Log(temp[1]);
        Debug.Log(temp[2]);
        Debug.Log(temp[3]);

        List<Spirit> stemp = mDBM.GetSpirits();

        Debug.Log("size : " + stemp.Count);
        foreach(Spirit item in stemp)
        {
            Debug.Log(item.Name + ": level - " + item.Level + ", cool - " + item.CoolTime);
        }
        Debug.Log(stemp.ToArray()[1].Name);
    }
}
