/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica del sensor acelerómetro. Ello permite la lectura de
//   este sensor, y la movilización del objeto acorde al vector marcado por el mismo.  Awake() obtiene
//   el algoritmo del patrón estrategia, Update(), ejecutándose una vez cada fotograma establece la
//   dirección de un vector direcos a los valores dados por el acalerómetro, y FixedUpdate(), que se 
//   ejecuta un número fijo de veces por segundo, aplica la velocidad acorde al vector y a un factor de 
//   sensibilidad.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AccelerometerHandler : MonoBehaviour
{
    private IAccelerometerHandler _defaultAccelerometer;
    [SerializeField]
    private Rigidbody2D _rb;
    private float _sensibility=50000.0f;
    private Vector2 _direction=Vector2.zero;

    private void Awake()
    {
        _defaultAccelerometer=GetComponent<DefaultAccelerometer>();
    }

    private void Update()
    {
        _direction=_defaultAccelerometer.SetDirection(_rb, _direction);
    }

    private void FixedUpdate()
    {
        _defaultAccelerometer.SetVelocity(_rb, _direction, _sensibility);

    }
}
