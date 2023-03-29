using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacePrototype
{
    [RequireComponent(typeof(WheelsComponent), typeof(BaseInputController), typeof(Rigidbody))]
    public class CarComponent : MonoBehaviour
    {
        private WheelsComponent _wheels;
        private BaseInputController _input;
        private Rigidbody _rigidbody;

        [SerializeField, Range(5f, 60f)]
        private float _maxSteerAngle = 25f;
        [SerializeField]
        private float _torque = 2500f;
        [SerializeField]
        private float _handBrakeTorque = float.MaxValue;

        private void FixedUpdate()
        {
            _wheels.UpdateVisual(_input.Rotate * _maxSteerAngle);
            var torque = _input.Acceleration * _torque / 2f;
            foreach (var wheel in _wheels.GetFrontWheels)
                wheel.motorTorque = torque;
        }

        private void OnHandBrake(bool value)
        {
            if (value)
            {
                foreach (var wheel in _wheels.GetRearWheels)
                {
                    wheel.brakeTorque = _handBrakeTorque;
                    wheel.motorTorque = 0f;
                }
            }
            else
            {
                foreach(var wheel in _wheels.GetRearWheels)
                    wheel.brakeTorque = 0f;
            }
        }


        private void Start()
        {
            _wheels = GetComponent<WheelsComponent>();
            _input = GetComponent<BaseInputController>();
            _rigidbody = GetComponent<Rigidbody>();

            _input.OnHandBrakeEvent += OnHandBrake;
        }

        private void OnDestroy()
        {
            _input.OnHandBrakeEvent -= OnHandBrake;
        }
    }
}
