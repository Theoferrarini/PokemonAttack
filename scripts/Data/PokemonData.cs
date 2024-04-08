using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PokemonData : BaseData
{
    [Serializable]

    public struct Stats
    {
        public int hp;
        public int attaque;
        public int defense;
        public int attaqueSpe;
        public int defenseSpe;
        public int vitesse;

        
        

        public Stats (int hp, int attaque, int defense, int attaqueSpe, int defenseSpe, int vitesse)
        {
            this.hp = hp;
            this.attaque = attaque; 
            this.defense = defense;  
            this.attaqueSpe = attaqueSpe;
            this.defenseSpe = defenseSpe;
            this.vitesse = vitesse;
        }

        public Stats(Stats  statsBase,int coeff)
        {
            hp          = statsBase.hp * coeff;
            attaque     = statsBase.attaque * coeff;
            defense     = statsBase.defense * coeff;
            attaqueSpe  = statsBase.attaqueSpe * coeff;
            defenseSpe  = statsBase.defenseSpe * coeff;
            vitesse     = statsBase.vitesse * coeff;
        }

        
    }

    [Serializable]

    public struct Infos
    {
        public int idnumber;
        public Types Type;
        public string category;
        public float size;
        public float weight;
        public int IdPokeBase;


        public Infos(int idnumber, Types type, string category, float size, float weight, int idPokeBase)
        {
            this.idnumber = idnumber;
            this.Type = type;
            this.category = category;
            this.size = size;
            this.weight = weight;
            this.IdPokeBase = idPokeBase;
        }
    }

    [Serializable]
    public struct AttackWrapper
    {
        public string label;
        public int level;

        public AttackWrapper(string label, int level)
        {
            this.label = label;
            this.level = level;
        }
    }
    public Sprite sprite;

    public Infos info;
    public Stats statsBase;

    public List<AttackWrapper> attacks = new();

    public PokemonData(string label, Sprite sprite,string caption, Infos info,Stats statsBase) : base (label, caption)
    {
        this.info = info;
        this.sprite = sprite;
        this.statsBase = statsBase;
    }

    public Stats GetStatsByLvl(int lvl, int evolutionStep) => new(statsBase, (lvl * evolutionStep) / 10);

    public override void DisplayName()
    {
        base.DisplayName();
        Debug.Log("Pokemon : " + label);

    }

}

