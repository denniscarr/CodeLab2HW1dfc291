using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    Vector3 originalPosition;
    Camera myCam;

    bool isShaking;
    [SerializeField] float shakeTime = 0.4f;
    float shakeTimer = 0f;
    [SerializeField] float shakeIntensity = 0.3f;
    [SerializeField] float maxShakeIntensity = 1f;
    float currentShakeIntensity;


    private void Start()
    {
        originalPosition = transform.position;
        myCam = GetComponent<Camera>();
    }


    private void Update()
    {
        if (isShaking)
        {
            transform.position = originalPosition + Random.insideUnitSphere * currentShakeIntensity;

            shakeTimer += Time.deltaTime;
            if (shakeTimer >= shakeTime)
            {
                transform.position = originalPosition;
                currentShakeIntensity = shakeIntensity;
                isShaking = false;
            }
        }
    }


    public void Shake()
    {
        isShaking = true;
        currentShakeIntensity = Mathf.Clamp(currentShakeIntensity + shakeIntensity, 0f, maxShakeIntensity);
        shakeTimer = 0;
    }
}
