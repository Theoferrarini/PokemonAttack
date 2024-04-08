using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    public PokemonController pokemon;
    public PokemonController pokemonCPU;

    public static PokemonController Currentpokemon;

    void Start()
    {
        pokemon.Init(DatabaseManager.GetInstance().GetData(1));
        pokemonCPU.Init(DatabaseManager.GetInstance().GetData(3));

        Currentpokemon = pokemon;
    }

}