using RacePrototype;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuning_View : MonoBehaviour
{
    [SerializeField] private Text _textStearAngle;
    [SerializeField] private Text _textMassAvto;

    [SerializeField] private Tuning_Controller _tuningController;

    private void OnEnable()
    {
        _tuningController.OnValueChange += ChangeViewUIText;
    }

    private void OnDisable()
    {
        _tuningController.OnValueChange -= ChangeViewUIText;
    }

    private void ChangeViewUIText(int currentStearAngle, int currentMassAvto)
    {
        _textStearAngle.text = currentStearAngle.ToString();
        _textMassAvto.text = currentMassAvto.ToString();
    }
}
