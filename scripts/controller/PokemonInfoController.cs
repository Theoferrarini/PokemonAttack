using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonInfoController : MonoBehaviour
{
    [SerializeField] private Image _imgIcon;
    [SerializeField] private Text _txtName;
    [SerializeField] private Text _txtsize;
    [SerializeField] private Text _txtweight;
    [SerializeField] private Text _txtcaption;
    [SerializeField] private Text _txtStats;
    [SerializeField] private Text _txtType;
    [SerializeField] private Text _txtCategory;

    private DatabaseManager _databaseMgr;
    private int currentPokemonId;

    void Start()
    {
        _databaseMgr = DatabaseManager.GetInstance();
        ShowPokemon(currentPokemonId);
    }

    void ShowPokemon(int pokemonId)
    {
        PokemonData data = _databaseMgr.GetData(pokemonId);

        _imgIcon.sprite = data.sprite;
        _txtName.text = $"<b>N� {data.info.idnumber:0000} | {data.label} </b>";
        _txtsize.text = $"  Taille : {data.info.size.ToString("f1")} m";
        _txtweight.text = $"Poids : {data.info.weight.ToString("f1")} kg";
        _txtcaption.text = $"Description :\n {data.caption}";

        _txtStats.text = "Stats:\n" +
            $"HP: {data.statsBase.hp}\n" +
            $"Attaque: {data.statsBase.attaque}\n" +
            $"D�fense: {data.statsBase.defense}\n" +
            $"Attaque Sp�ciale: {data.statsBase.attaqueSpe}\n" +
            $"D�fense Sp�ciale: {data.statsBase.defenseSpe}\n" +
            $"Vitesse: {data.statsBase.vitesse}\n";
        _txtType.text = $"Type :{data.info.Type}";
        _txtCategory.text = $"Category :{data.info.category}";
    }

    public void NextPokemon()
    {
        currentPokemonId = (currentPokemonId + 1) % _databaseMgr.database.datas.Count;
        ShowPokemon(currentPokemonId);
    }

    public void PreviousPokemon()
    {
        currentPokemonId = (currentPokemonId - 1 + _databaseMgr.database.datas.Count) % _databaseMgr.database.datas.Count;
        ShowPokemon(currentPokemonId);
    }
}
