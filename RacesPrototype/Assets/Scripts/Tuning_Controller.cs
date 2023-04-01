using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;


namespace RacePrototype
{
    public class Tuning_Controller : Base_Controller
    {
        [SerializeField] private TuningSO_Model tuningSO;
        [SerializeField] private Slider _sliderStearAngle;
        [SerializeField] private Slider _sliderMassAvto;
        [SerializeField] private Button _driveButton;
        public Action<int,int> OnValueChange;

        private void OnEnable()
        {
            _sliderStearAngle.value = (float)tuningSO.MaxSteerAngle / 100;
            _sliderMassAvto.value = (float)tuningSO.MassAvto / 1000;
            _driveButton.onClick.AddListener(delegate { LoadScene(SceneExample.Drive); });
        }

        private void OnDisable()
        {
            _driveButton.onClick.RemoveListener(delegate { LoadScene(SceneExample.Drive); });
        }


        private void Update()
        {
            tuningSO.MaxSteerAngle = (int)(_sliderStearAngle.value * 100);
            if (tuningSO.MaxSteerAngle < 10) tuningSO.MaxSteerAngle = 10;
            if (tuningSO.MaxSteerAngle > 60) tuningSO.MaxSteerAngle = 60;
            tuningSO.MassAvto = (int)(_sliderMassAvto.value * 1000); //дописать логику (желательно вызов не в каждом кадре)
            OnValueChange?.Invoke(tuningSO.MaxSteerAngle, tuningSO.MassAvto);
        }      
    }
}