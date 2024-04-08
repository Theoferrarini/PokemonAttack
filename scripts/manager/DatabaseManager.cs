using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;

    public PokemonDataBase database;
    public AttackDataBase attackDataBase;

    public PokemonData GetData(int id) => database?.datas[id];


    public AttackData GetAttackData(string label)
    {
        return attackDataBase?.datas.Find(x => x.label.ToLower().Contains(label.ToLower()));
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;

            database.InitData();
            database.CreateData();        
    }

    public static DatabaseManager GetInstance()
    {
        if (instance == null)
            instance = new();

        return instance;
    }
}