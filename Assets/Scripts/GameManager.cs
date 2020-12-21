using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
  
    // Start is called before the first frame update
    public Vector3 GameDirection = Vector3.forward;
    public PlayerControls player;
    public EndlessGenerator levelGenerator;
    public Animator playerAnimator;
    public Text timeText;
    public Text scoreText;
    public Slider attentionSlider;
    public Slider meditationSlider;

    public int waitTime = 3;

    private int time = 3;
    private Animator textAnimator;
    void Awake()
    {
        player.isManual = true;
        textAnimator = timeText.GetComponent<Animator>();
        time = 3;
    }

    private void Start()
    {
        MindWaveAdapter.OnMediationEvent += OnMeditation;
        MindWaveAdapter.OnAttenction += OnAttention;
    }

    private void OnAttention(int value)
    {
        attentionSlider.value = value;
    }

    private void OnMeditation(int value)
    {
        meditationSlider.value = value;
    }
    void Update()
    {
        scoreText.text = player.gameObject.transform.position.z.ToString("0");
    }

    public void TickTime()
    {
        time-=1;
        timeText.text = time.ToString();
        if (time < 0)
        {
            playerAnimator.SetTrigger("gameStarted");
            player.isManual = false;
            timeText.enabled = false;
        }
        else
        {
         textAnimator.SetTrigger("Tick");
        }

    }
}
