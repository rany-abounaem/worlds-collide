using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(ParticleSystem))]
public class ExperienceParticles : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _particleSpeedCurve;
    [SerializeField]
    private float _curveMultiplier;

    private ParticleSystem _ps;
    private Transform _playerTransform;

    public void Setup(Transform playerTransform)
    {
        _ps = GetComponent<ParticleSystem>();
        _playerTransform = playerTransform;
        _ps.simulationSpace = ParticleSystemSimulationSpace.World;
        _ps.Play();
    }

    private void Update()
    {
        if (_ps != null && _ps.isPlaying)
        {
            ParticleSystem.Particle[] __particles = new ParticleSystem.Particle[40];
            var __particleCount = _ps.GetParticles(__particles);
            for (var __i = 0; __i < __particleCount; __i++) 
            {
                var __playerPosition = _playerTransform.position;
                var __particlePosition = __particles[__i].position;
                var __distance = Vector2.Distance(__playerPosition, __particlePosition);
                var __direction = (__playerPosition - __particlePosition).normalized;
                var __currentTime = _ps.time / _ps.duration;
                var __evaluatedValue = _particleSpeedCurve.Evaluate(__currentTime);
               __particles[__i].velocity = new Vector3(__direction.x * __evaluatedValue * _curveMultiplier * __distance, __direction.y * __evaluatedValue * _curveMultiplier * __distance, 0);
            }
            _ps.SetParticles(__particles);
        }
    }
}
