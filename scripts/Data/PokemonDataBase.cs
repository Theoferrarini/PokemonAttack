using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonDatabase", menuName = "Database/Pokemon", order = 0)]

public class PokemonDataBase : ScriptableObject
{
    public List<PokemonData> datas = new();
    
    public void InitData()
    {
        datas.RemoveAll(data => data.info.idnumber < 0);
    }

    public void CreateData()
    {
        if (!datas.Exists(data => data.info.idnumber == 9))
        {
            if (datas.Count >= 8)
            {
                PokemonData.Infos info = new()
                {
                    idnumber = 9,
                    Type = Types.Eau,
                    size = 1.6f,
                    weight = 85.5f,
                    category = "Carapace",
                    IdPokeBase = datas[7].info.idnumber,
                };

                Sprite spritePoke = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/anim/Tortank.asset", typeof(Sprite));

                PokemonData.Stats stats = new PokemonData.Stats();
                stats.hp = 79;
                stats.attaque = 83;
                stats.defense = 100;
                stats.attaqueSpe = 85;
                stats.defenseSpe = 105;
                stats.vitesse = 78;

                PokemonData pokemonData = new (
                    label: "Tortank", 
                    sprite: spritePoke,
                    caption : "Il augmente d�lib�r�ment sa masse corporelle pour contrer le recul de ses puissants jets d�eau.",
                    info: info, 
                    statsBase: stats);

                pokemonData.statsBase = pokemonData.GetStatsByLvl(13, 3);

                datas.Add(pokemonData);
            }
            else
            {
                Debug.LogError("Not enough existing Pokemon data to reference for creating new Pokemon data.");
            }
        }
    }

}
