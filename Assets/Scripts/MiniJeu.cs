using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScorePanneau;
    [SerializeField] GameObject panneauRecord;
    public TMP_InputField inputNom;

    void Start()
    {
        // Supprimer après test
        // PlayerPrefs.DeleteAll();
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }

    public void TraiterDefaite()
    {
        Debug.Log("Defaite");

        float recordActuel = PlayerPrefs.GetFloat("meilleurScore", 0f);

        if (pointageTemps >= recordActuel)
        {
            Invoke("ApparaitreAfficheNom", 3f);
        }
        
    }

    void ApparaitreAfficheNom()
    {
        panneauRecord.SetActive(true);
        textScorePanneau.text = textScore.text;
    }

    public void EnregistrerNomRecord()
    {
        string nom = inputNom.text;
        PlayerPrefs.SetString("nom", nom);

        // Redemarrer la scene actuel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
