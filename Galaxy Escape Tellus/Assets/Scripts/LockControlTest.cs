using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LockControlTest : MonoBehaviour
{

    //PadLockEmissionColor _pLockColor;
    //private bool _isActveEmission = false;

    private int currentRullerIndex;
    //private int _changeRuller = 0; // Declare and initialize _changeRuller

    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown1;
    private int numberShown2;
    private int numberShown3;
    private int numberShown4;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    private ArrayList arrows = new ArrayList();

    private ArrayList rullers = new ArrayList();
    // Start is called before the first frame update

    /*void Awake()
    {
        _pLockColor = FindObjectOfType<PadLockEmissionColor>();
    }*/

    void Start()
    {
        //_pLockColor = FindObjectOfType<PadLockEmissionColor>();

        numberShown1 = 5;
        numberShown2 = 5;
        numberShown3 = 5;
        numberShown4 = 5;
        foreach (Transform child in transform)
        {
            if (child.tag == "ruller"){
                rullers.Add(child.gameObject);
            }
        }
        arrows.Add(arrow1);
        arrows.Add(arrow2);
        arrows.Add(arrow3);
        arrows.Add(arrow4);

        arrow1.SetActive(true);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        bool buttonDowny = false;
        bool buttonDowna = false;
        //bool buttonDownc = false;
        if(TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.Y, out buttonDowny, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)) 
        {if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.A, out buttonDowna, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)){

        
            
            //Debug.Log("testi");
            if (buttonDowny){
                GameObject arrow = (GameObject)arrows[currentRullerIndex];
                arrow.SetActive(false);
                //siirry seuraavaan rulleriin
                if (currentRullerIndex < 3){
                    currentRullerIndex ++;
                }else if  (currentRullerIndex == 3){
                    currentRullerIndex = 0;
                }
                GameObject arrowx = (GameObject)arrows[currentRullerIndex];
                arrowx.SetActive(true);
            }
            if (buttonDowna){
                Debug.Log("testi2");
                GameObject arrow = (GameObject)arrows[currentRullerIndex];
                arrow.SetActive(false);
                //siirry seuraavaan rulleriin
                if (currentRullerIndex > 0){
                    currentRullerIndex --;
                }else if  (currentRullerIndex == 0){
                    currentRullerIndex = 3;
                }
                GameObject arrowx = (GameObject)arrows[currentRullerIndex];
                arrowx.SetActive(true);
            }
        
            bool buttonDownb = false;
            bool buttonDownx = false;
            //bool buttonDown2c = false;
            if(TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.B, out  buttonDownb, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)){

            
            if(TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.X, out  buttonDownx, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
                if (buttonDownb){
                    //rotate selected ruller
                    GameObject ruller = (GameObject)rullers[currentRullerIndex] ;
                    for (int i = 0; i <= 11; i++) {
                        ruller.transform.Rotate(-3f, 0f, 0f);
                    }
                    if(currentRullerIndex == 0){
                        numberShown1 += 1;

                        if (numberShown1 > 9) {
                            numberShown1 = 0;
                        }
                        Rotated(ruller.name, numberShown1);
                    }
                    if(currentRullerIndex == 1){
                        numberShown2 += 1;

                        if (numberShown2 > 9) {
                            numberShown2 = 0;
                        }
                        Rotated(ruller.name, numberShown2);
                    }
                    if(currentRullerIndex == 2){
                        numberShown3 += 1;

                        if (numberShown3 > 9) {
                            numberShown3 = 0;
                        }
                        Rotated(ruller.name, numberShown3);
                    }
                    if(currentRullerIndex == 3){
                        numberShown4 += 1;

                        if (numberShown4 > 9) {
                            numberShown4 = 0;
                        }
                        Rotated(ruller.name, numberShown4);
                    }


                    
                }
                if (buttonDownx){
                    //rotate selected ruller
                    GameObject ruller = (GameObject)rullers[currentRullerIndex] ;
                    for (int i = 0; i <= 11; i++) {
                        ruller.transform.Rotate(3f, 0f, 0f);
                    }
                    if(currentRullerIndex == 0){
                        numberShown1 -= 1;

                        if (numberShown1 < 0) {
                            numberShown1 = 9;
                        }
                        Rotated(ruller.name, numberShown1);
                    }
                    if(currentRullerIndex == 1){
                        numberShown2 -= 1;

                        if (numberShown2 < 0) {
                            numberShown2 = 9;
                        }
                        Rotated(ruller.name, numberShown2);
                    }
                    if(currentRullerIndex == 2){
                        numberShown3 -= 1;

                        if (numberShown3 <0) {
                            numberShown3 = 9;
                        }
                        Rotated(ruller.name, numberShown3);
                    }
                    if(currentRullerIndex == 3){
                        numberShown4 -= 1;

                        if (numberShown4 <0) {
                            numberShown4 = 9;
                        }
                        Rotated(ruller.name, numberShown4);
                    }


                    
                }
            }
            }
            }

            /*for (int i = 0; i <= rullers.Count; i++) 
            {
                if (_isActveEmission)
                {
                    if (_changeRuller == i)
                    {

                        PadLockEmissionColor emissionColorComponent = ((GameObject)rullers[i]).GetComponent<PadLockEmissionColor>();
                        if (emissionColorComponent != null)
                        {
                            emissionColorComponent._isSelect = true;
                            emissionColorComponent.BlinkingMaterial();
                        }
                        else
                        {
                            Debug.LogError("PadLockEmissionColor component is missing on GameObject: " + ((GameObject)rullers[i]).name);
                        }
                    }
                    else
                    {
                        PadLockEmissionColor emissionColorComponent = ((GameObject)rullers[i]).GetComponent<PadLockEmissionColor>();
                        if (emissionColorComponent != null)
                        {
                            emissionColorComponent._isSelect = false;
                            emissionColorComponent.BlinkingMaterial();
                        }
                        else
                        {
                            Debug.LogError("PadLockEmissionColor component is missing on GameObject: " + ((GameObject)rullers[i]).name);
                        }
                    }
                }
            }*/
        } 
    }

    

    
}
