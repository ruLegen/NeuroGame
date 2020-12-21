using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int attentionLevel = -1;
    public int attentionEvent = -1;
    public int blinkCount = 0;
    public int blinkEvent = -1;
    public int meditationLevel = -1;
    public int signalLevel = -1;
    public int rawData = -1;

    public Texture[] signalIcons;


    public RawImage signalIndicator;
    public Text blinkText;
    public Text signalText;
    public Text attentionText;
    public Text meditationText;
    public GameObject nextButton;
    public GameObject dummieButton;

    private bool isBlinkDone = false;
    private bool isSignalDone = false;
    private bool isMeditationDone = false;
    private bool isAttentionDone = false;

    public RawImage markSignal;
    public RawImage markBlink;
    public RawImage markAttention;
    public RawImage markMeditation;

    private int indexSignalIcons = 0;
    void Start()
    {
        MindWaveAdapter.OnAttenction += onAttention;
        MindWaveAdapter.OnAttenctionEvent += onAttentionEvent; ;
        MindWaveAdapter.OnBlink += onBlink;
        MindWaveAdapter.OnMediationEvent += onMeditation;
        MindWaveAdapter.OnPoorSignalEvent += onPoorSignal;
        MindWaveAdapter.OnRawData += onRawData;
        markSignal.enabled = false;
        markBlink.enabled = false;
        markAttention.enabled = false;
        markMeditation.enabled = false;
    }

    private void onRawData(int value)
    {
        rawData = value;
    }
    private void onPoorSignal(int value)
    {
        signalLevel = value;
        signalText.text = value.ToString();
        if (value < 25)
        {
            indexSignalIcons = 0;
        }
        else if (value >= 25 && value < 51)
        {
            indexSignalIcons = 4;
        }
        else if (value >= 51 && value < 78)
        {
            indexSignalIcons = 3;
        }
        else if (value >= 78 && value < 107)
        {
            indexSignalIcons = 2;
        }
        else if (value >= 107)
        {
            indexSignalIcons = 1;
        }

        if(value > 50)
        {
            isSignalDone = true;
            markSignal.enabled = true;
        }
        else
        {
            isSignalDone = false;
            markSignal.enabled = false;
        }
        signalIndicator.texture = signalIcons[indexSignalIcons];
    }
    private void onBlink(int value)
    {
        blinkCount += 1;
        blinkEvent = value;
        blinkText.text = blinkCount.ToString();
        if (blinkCount > 10)
        {
            isBlinkDone = true;
            markBlink.enabled = true;
        }
    }
    private void onAttentionEvent(int value)
    {
        attentionEvent = value;

    }
    private void onAttention(int value)
    {
        attentionLevel = value;
        attentionText.text = value.ToString();
        attentionText.color = Color.Lerp(Color.red, Color.white, 1f / value);
        if (attentionLevel > 55)
        {
            isAttentionDone = true;
            markAttention.enabled = true;
        }

    }
    private void onMeditation(int value)
    {
        meditationLevel = value;
        meditationText.text = value.ToString();
        meditationText.color = Color.Lerp(Color.blue, Color.white, 1f / value);
        if (meditationLevel > 55)
        {
            markMeditation.enabled = true;
            isMeditationDone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSignalDone && isMeditationDone && isBlinkDone && isAttentionDone)
        {
            dummieButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
            dummieButton.SetActive(true);
        }
    }

    private void OnDestroy()
    {

        MindWaveAdapter.OnAttenction -= onAttention;
        MindWaveAdapter.OnAttenctionEvent -= onAttentionEvent; ;
        MindWaveAdapter.OnBlink -= onBlink;
        MindWaveAdapter.OnMediationEvent -= onMeditation;
        MindWaveAdapter.OnPoorSignalEvent -= onPoorSignal;
        MindWaveAdapter.OnRawData -= onRawData;
    }
}
