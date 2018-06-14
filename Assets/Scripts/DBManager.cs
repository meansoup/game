using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBManager {

    private string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDB.db";
    private IDbConnection dbConn;
    private IDbCommand dbCmd;
    private IDataReader reader;

    public int[] GetPlayer() {
        int attack = 0, speed = 0, criticalPercent = 0, criticalDamage = 0;
        using (dbConn = (IDbConnection)new SqliteConnection(conn)) {
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = "SELECT * FROM player";
            reader = dbCmd.ExecuteReader();

            while (reader.Read()) {
                attack = reader.GetInt32(0);
                speed = reader.GetInt32(1);
                criticalPercent = reader.GetInt32(2);
                criticalDamage = reader.GetInt32(3);
            }
        }

        return new int[]{ attack, speed, criticalPercent, criticalDamage};
    }

    public List<Spirit> GetSpirits() {
        List<Spirit> ret = new List<Spirit>();
        using (dbConn = (IDbConnection)new SqliteConnection(conn))
        {
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = "SELECT * FROM spirit";
            reader = dbCmd.ExecuteReader();

            while (reader.Read()) {
                Spirit spiritTemp = new Spirit();
                spiritTemp.Name = reader.GetString(0);
                spiritTemp.Level = reader.GetInt32(1);
                spiritTemp.CoolTime = reader.GetInt32(2);
                ret.Add(spiritTemp);
            }
        }

        return ret;
    }
    
    //public void setPlayer(int attack, int spped, int criticalP, int ciriticalD) {
    //    using (dbConn = (IDbConnection)new SqliteConnection(conn))
    //    {
    //        dbConn.Open();
    //        dbCmd = dbConn.CreateCommand();
    //        dbCmd.CommandText = "SELECT * FROM Player";
    //        reader = dbCmd.ExecuteReader();

    //    }
    //}
}

public class Spirit {
    public string Name;
    public int Level;
    public int CoolTime;
}