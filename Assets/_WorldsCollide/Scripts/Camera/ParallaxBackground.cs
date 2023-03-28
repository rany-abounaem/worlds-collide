using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private float _parallaxFactor;
    private Transform _cameraTransform;
    private Vector3 _lastCameraPos;
    private float textureUnits;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraPos = _cameraTransform.position;
        var __spriteRenderer = GetComponent<SpriteRenderer>();
        var __sprite = __spriteRenderer.sprite;
        textureUnits = (__sprite.texture.width / __sprite.pixelsPerUnit) * transform.localScale.x;
    }

    private void LateUpdate()
    {
        var __deltaMovement = _cameraTransform.position - _lastCameraPos;
        var __parallaxEffect = __deltaMovement.x * _parallaxFactor;
        transform.position = new Vector3(transform.position.x + __parallaxEffect, _cameraTransform.position.y);
        _lastCameraPos = _cameraTransform.position;

        
        if (Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= textureUnits)
        {
            var __offset = (_cameraTransform.position.x - transform.position.x) % textureUnits;
            transform.position = new Vector3(_cameraTransform.position.x + __offset, transform.position.y);
        }
    }
}
