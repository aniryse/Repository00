using UnityEngine;
using System.Collections;

public class KillTarget : MonoBehaviour {
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public TextMesh scoreDisplay;
    public int points = 1;
    private int score;

    private const float XMIN = -20.0f;
    private const float XMAX = 20.0f;
    private const float ZMIN = -20.0f;
    private const float ZMAX = 20.0f;

    private float countDown;
	// initialize score, countdown and hitEffect
	void Start () {
        score = 0;
        scoreDisplay.text = score.ToString("D4");
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            // hitting target but it's still alive
                if(countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
                //print (countDown);
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
            }
            //else it's being hit and is ready to be killed
            else
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                countDown = timeToSelect;
                SetRandomPosition();
                updateScore();
                
            }
        }
        //else missing the target
        else
        {
            countDown = timeToSelect;
            hitEffect.enableEmission = false;
        }
	}

    void SetRandomPosition()
    {
        float newX = Random.Range(XMIN, XMAX);
        float newZ = Random.Range(ZMIN, ZMAX);
        target.transform.position = new Vector3(newX, 0.0f, newZ);
    }

     void updateScore()
    {
        int currentScore = int.Parse(scoreDisplay.text);
        scoreDisplay.text = (currentScore + points).ToString("D4");
    }
  
}
