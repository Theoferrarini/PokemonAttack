using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonController : MonoBehaviour
{
    [SerializeField] private Text _txtLabel;
    [SerializeField] private Image _imgIcon;

    [Header("PV")]
    [SerializeField] private Image _imgPV;
    [SerializeField] private Text _txtPV;

    [SerializeField] private List<AttaqueSlotController> _atkSlots = new();

    public PokemonData _data { get; private set; }
    private int _currentLife;

    public void Init(PokemonData data)
    {
        _data = data ;
        _txtLabel.text = _data.label;
        _imgIcon.sprite = _data.sprite;

        _currentLife = data.statsBase.hp;

        foreach(AttaqueSlotController slot in _atkSlots)
        {
            var id = _atkSlots.IndexOf(slot);
            slot.Init(data.attacks[id].label);
        }

        RefreshUI();
    }

    private void RefreshUI()
    {
        _txtPV.text = $"{_data.statsBase.hp:00} / {_data.statsBase.hp:00}";
    }
}
