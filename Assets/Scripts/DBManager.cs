using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBObject
{
    public string Name;
    public int Value1;
    public int Value2;
    public int Value3;
    /*
     * player : name, value
     * skill : name, level
     * spirit : name, level, cooltime
     */
}

public class DBManager {

    private string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDB.db";
    private IDbConnection dbConn;
    private IDbCommand dbCmd;
    private IDataReader reader;

    public List<DBObject> GetDB(string tableName) {
        List<DBObject> ret = new List<DBObject>();
        using (dbConn = (IDbConnection)new SqliteConnection(conn)) {
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = "SELECT * FROM " + tableName;
            reader = dbCmd.ExecuteReader();

            while (reader.Read()) {
                DBObject dBObject = new DBObject();
                dBObject.Name = reader.GetString(0);
                dBObject.Value1 = reader.GetInt32(1);
                dBObject.Value2 = reader.GetInt32(2);
                dBObject.Value3 = reader.GetInt32(3);
                ret.Add(dBObject);
            }
        }
        return ret;
    }

    public void SetDB(string tableName, string name, int valPos, int val) {
        string updateCmd = "UPDATE " + tableName + " SET value" + valPos + " = " + val + " WHERE name = '" + name + "'";

        using (dbConn = (IDbConnection)new SqliteConnection(conn)) {
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = updateCmd;
            dbCmd.ExecuteNonQuery();
        }
    }

    /*
     * 데이타를 리턴 받을 것인지 혹은 어떤 데이타를 리턴 받을 것인지에 따라 다른 SqlCommand 메서드를 호출
     * 
     * ExecuteNonQuery
     *      ExecuteNonQuery 메서드는 INSERT, UPDATE, DELETE 등의 DML 문장을 실행할 때 사용
     * 
     * ExecuteReader 
     *      데이타를 서버에서 가져오기 위해서는 ExecuteReader()를 사용
     *      Connection-based 접근 방식으로 데이타베이스 Connection이 계속 연결된 상태를 유지
     * 
     * ExecuteScalar
     *      데이타가 단 하나 Single Value인 경우
     * 
     */
}