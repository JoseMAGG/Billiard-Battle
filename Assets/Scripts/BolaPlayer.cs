using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BolaPlayer : Bola
{
    public Transform apuntador;
    public FixedJoystick joystick;
    public Button shootButton;
    public Slider forceSlider;
    
    public float sensX;
    public Camera cam;
    private float _rotation;
    private float _fuerza = fuerzaMin;
    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        _coroutine = StartCoroutine(Fuerza());
        StopCoroutine(_coroutine);
        
        forceSlider.minValue = fuerzaMin;
        forceSlider.maxValue = fuerzaMax;
    }

    private void FixedUpdate()
    {
        //Get mouse input
        float mouseX = /*Input.GetAxisRaw("Mouse X")*/
            joystick.Horizontal * Time.deltaTime * sensX;

        _rotation += mouseX;
            
        //Rotate cam and orientation
        cam.transform.rotation = Quaternion.Euler(0, _rotation, 0);
        transform.rotation = Quaternion.Euler(0, _rotation, 0);
    }
    void Update()
    {
        if (rb.velocity.magnitude <= 5)
        {
            shootButton.interactable = true;
            if (Input.GetKeyDown(KeyCode.Space) )
                        ShootDown();
            if(Input.GetKeyUp(KeyCode.Space))
                        ShootUp();
        }else shootButton.interactable = false;

    }

    public void ShootDown()
    {
        if(!shootButton.interactable) return;
        Debug.Log("Down");
        _coroutine = StartCoroutine(Fuerza());
    }

    public void ShootUp()
    {
        if(!shootButton.interactable) return;
        Debug.Log("Up");
        StopCoroutine(_coroutine);
        Vector3 dir = Vector3.Normalize(apuntador.position - transform.position);
        rb.AddForce(dir * _fuerza);
        _fuerza = fuerzaMin;
        forceSlider.value = _fuerza;
    }

    private IEnumerator Fuerza()
    {
        int sign = 1;
        float time = 0;
        float valor = (fuerzaMax - fuerzaMin) / 35;
        while (time <= 5)
        {
            _fuerza += valor * sign;
            forceSlider.value = _fuerza;
            sign = _fuerza >= fuerzaMax || _fuerza <= fuerzaMin
                ? -sign : sign;
            Debug.Log(_fuerza);
            yield return new WaitForSeconds(0.01f);
            time += 0.01f;
        }
    }
}
