using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MindWaveAdapterAndroid : MonoBehaviour
{
    //edit->project settings->player->other settings->API compability level: from .NET 4.x. to NET 2.0 
    ThinkGearController controller;
    //TGCConnectionController controller;
    public delegate void HandleInt(int value);

    public static event HandleInt OnAttenction;
    public static event HandleInt OnAttenctionEvent;
    public static event HandleInt OnPoorSignalEvent;
    public static event HandleInt OnMediationEvent;
    public static event HandleInt OnRawData;
    public static event HandleInt OnBlink;
    void Start()
    {
        controller = gameObject.GetComponent<ThinkGearController>();
        //controller = gameObject.GetComponent<TGCConnectionController>();      //uncomment when in editor
        controller.UpdateAttentionEvent += onUpdateAttenction;
        controller.UpdatePoorSignalEvent += onUpdatePoorSignalEvent;
        controller.UpdateAttentionEvent += onUpdateAttentionEvent;
        controller.UpdateMeditationEvent += onUpdateMeditationEvent;
        controller.UpdateRawdataEvent += onUpdateRawdataEvent;
        controller.UpdateBlinkEvent += onUpdateBlinkEvent;
    }
    public void connect()
    {
        UnityThinkGear.StartStream();
    }
    void onUpdateAttenction(int value) { OnAttenction?.Invoke(value); }//Debug.Log("onUpdateAttenction " + value); }
    void onUpdatePoorSignalEvent(int value) { OnAttenctionEvent?.Invoke(value); }//Debug.Log("onUpdatePoorSignalEvent " + value); }
    void onUpdateAttentionEvent(int value) { OnPoorSignalEvent?.Invoke(value); }//Debug.Log("onUpdateAttentionEvent " + value); }
    void onUpdateMeditationEvent(int value) { OnMediationEvent?.Invoke(value); }//Debug.Log("onUpdateMeditationEvent " + value); }
    void onUpdateRawdataEvent(int value) { OnRawData?.Invoke(value); }//Debug.Log("onUpdateRawdataEvent " + value); }
    void onUpdateBlinkEvent(int value) { OnBlink?.Invoke(value); }//Debug.Log("onUpdateBlinkEvent " + value);}
}                                                                      
