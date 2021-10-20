using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class KeyboardManager : MonoBehaviour
{
    public static KeyCode keyUp = KeyCode.W;
    public static KeyCode keyDown = KeyCode.S;
    public static KeyCode keyRight = KeyCode.D;
    public static KeyCode keyLeft = KeyCode.A;

    public static float volume = 1;

    public AudioMixer mixer;

    [SerializeField]
    TMP_Text textButtonKeyboard;

    private void Update()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
    }

    public void SwitchAzertyQuerty()
    {
        if (keyUp == KeyCode.W)
        {
            textButtonKeyboard.text = "AZERTY";
            keyUp = KeyCode.Z;
            keyLeft = KeyCode.Q;
        }
        else if (keyUp == KeyCode.Z)
        {
            textButtonKeyboard.text = "QWERTY";
            keyUp = KeyCode.W;
            keyLeft = KeyCode.A;
        }
    }
}
