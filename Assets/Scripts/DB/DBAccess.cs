using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour {

  
	void Start () {
 
        DBManager mDBM = new DBManager();
        List<DBObject> temp = mDBM.GetDB("player");

        Debug.Log("getPlayer");
        foreach (DBObject item in temp)
        {
            Debug.Log(item.Name + ": value - " + item.Value1);
        }

        List<DBObject> stemp = mDBM.GetDB("spirit");

        Debug.Log("spirit");
        foreach(DBObject item in stemp)
        {
            Debug.Log(item.Name + ": level - " + item.Value1 + ", cool - " + item.Value2);
        }
        Debug.Log(stemp.ToArray()[1].Name);

        mDBM.SetDB("player", "attack", 1, 9999);

        Debug.Log("re-getPlayer");
        foreach (DBObject item in temp)
        {
            Debug.Log(item.Name + ": value - " + item.Value1);
        }
    }
}
