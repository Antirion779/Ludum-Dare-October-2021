using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallGameManager : MonoBehaviour
{
    public static FallGameManager instance;

    [SerializeField] 
    private GameObject cross;
    [SerializeField]
    private GameObject player;

    private float chrono;
    private float memoryChrono;
    private bool nextSecond;
    private int diviseur = 100;
    private bool isDie;
    private bool boum;

    public bool isVictory;

    public AudioSource audioSource;

    private GameObject[] crossCase;

    public CameraShake CameraShakes;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    private void FixedUpdate()
    {
        if (nextSecond && chrono > 0)
        {
            //Debug.Log("patate");
            StartCoroutine(WaitForTimer());
        }

        if(chrono <= 0)
        {
            crossCase = GameObject.FindGameObjectsWithTag("Cross");
            foreach (GameObject cross in crossCase)
            {
                if(player != null)
                {
                    if(cross.transform.position == player.transform.position)
                    {
                        Destroy(player);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        isDie = true;
                    }

                    Destroy(cross);
                }
                else
                {
                    isDie = true;
                }
            }

            if (boum)
            {
                boum = false;
                audioSource.Play();
                StartCoroutine(CameraShakes.Shake(0.3f, 1.0f));
            }

            if (isVictory && !isDie)
                GameManager.instance.gameIsOn = false;
        }
    }

    public void SpawnGoodCase()
    {
        int spawn = Random.Range(4, 7);
        for (int i = 0; i < spawn; i++)
        {
            int x = Random.Range(0, GameManager.taillePlateau);
            int y = Random.Range(0, GameManager.taillePlateau);

            Vector3 pos = new Vector3(x, y, 0);

            if (PlateauManager.itemInPlateau[x, y] == false && pos != cross.transform.position)
            {
                PlateauManager.itemInPlateau[x, y] = true;
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < GameManager.taillePlateau; i++)
        {
            for (int j = 0; j < GameManager.taillePlateau; j++)
            {
                if(PlateauManager.itemInPlateau[i, j] == false)
                {
                    Instantiate(cross, new Vector3(i, j, 0), Quaternion.identity);
                }
            }
        }

        chrono = GameManager.fallSpeed;
        memoryChrono = chrono / diviseur;
        nextSecond = true;
        boum = true;
    }

    private IEnumerator WaitForTimer()
    {
        if (chrono > 0)
        {
            nextSecond = false;
            yield return new WaitForSeconds(memoryChrono);
            chrono -= memoryChrono;

            crossCase = GameObject.FindGameObjectsWithTag("Cross");
            foreach (GameObject cross in crossCase)
            {
                cross.transform.localScale = new Vector3(cross.transform.localScale.x + 0.8f/ diviseur, cross.transform.localScale.y + 0.8f / diviseur, cross.transform.localScale.z + 0.8f / diviseur);
            }
            nextSecond = true;
        }
    }

    public void ResetExplosion()
    {
        crossCase = GameObject.FindGameObjectsWithTag("Cross");
        foreach (GameObject cross in crossCase)
        {
            Destroy(cross);
        }
    }
}
