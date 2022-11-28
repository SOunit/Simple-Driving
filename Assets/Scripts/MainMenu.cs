using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highScoreText;

    [SerializeField]
    private TMP_Text energyText;

    [SerializeField]
    private int maxEnergy;

    [SerializeField]
    private int energyRechargeDuration;

    private int energy;

    private const string EnergyKey = "Energy";

    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        string highScore =
            PlayerPrefs.GetInt(ScoreSystem.HighScoreKey).ToString();
        highScoreText.text = $"High Score: {highScore}";

        // get energy
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if (energy == 0)
        {
            // get DateTime String
            string energyReadyString =
                PlayerPrefs.GetString(EnergyReadyKey, String.Empty);
            if (energyReadyString == string.Empty) return;

            // convert string to DateTime
            DateTime energyReady = DateTime.Parse(energyReadyString);

            // check if should recharge
            if (DateTime.Now > energyReady)
            {
                // recharge
                energy = maxEnergy;

                // save
                PlayerPrefs.SetInt (EnergyKey, energy);
            }
        }

        energyText.text = $"Play({energy})";
    }

    public void Play()
    {
        if (energy < 1) return;

        energy--;

        PlayerPrefs.SetInt (EnergyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady =
                DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
        }

        SceneManager.LoadScene(1);
    }
}
