using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Controller : MonoBehaviour
{
    public enum tankStatus {shoot,coup,move,finish};
    public tankStatus currentStatus;

    [SerializeField]
    Transform tankObje;
    public Animator anim;

    [Header("Move")]
    public float moveSpeed;
    public Transform leftTarget, rightTarget;
    bool rightMove;

    [Header("Shot")]
    public GameObject bullet;
    public Transform bulletCenter;
    public float bulletTime;
    float bulletCounter;

    [Header("Coup")]
    public float coupTime;
    float coupCounter;

    public GameObject tankBox;

    public GameObject mineObje;
    public Transform mineCenter;
    public float mineTime;
    float mineCoup;

    [Header("HealthStatus")]
    public int healthStatus = 5;
    public GameObject tankDestroyEf;
    bool gameOver;

    public float bulletTimeUp, mineTimeUp;

    private void Start()
    {
        currentStatus = tankStatus.shoot;
        rightMove = false;
    }

    private void Update()
    {
        switch(currentStatus)
        {
            case tankStatus.shoot:

                bulletCounter -= Time.deltaTime;

                if (bulletCounter <- 0)
                {
                    bulletCounter = bulletTime;

                   var newBullet = Instantiate(bullet, bulletCenter.position, bulletCenter.rotation);
                    newBullet.transform.localScale = tankObje.localScale;
                    
                }
                
                break;

            case tankStatus.coup:
                if (coupCounter>0)
                {
                    coupCounter -= Time.deltaTime;

                    if (coupCounter<=0)
                    {
                        currentStatus = tankStatus.move;
                        mineCoup = 0;

                        if (gameOver)
                        {
                            tankObje.gameObject.SetActive(false);
                            Instantiate(tankDestroyEf, transform.position, transform.rotation);

                            currentStatus = tankStatus.finish;
                            Sound_Controller.instance.SoundEffectUp(0);
                        }
                    }
                }
                break;

                

            case tankStatus.move:
                
                if (rightMove)
                {
                    tankObje.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    
                    if (tankObje.position.x > rightTarget.position.x)
                    {
                        tankObje.localScale = Vector3.one;
                        
                        rightMove = false;

                        StopMoveFNC();


                    }
                }else
                {
                    tankObje.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    
                    if (tankObje.position.x < leftTarget.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);

                        rightMove = true;

                        StopMoveFNC();
                    }
                }

                mineCoup -= Time.deltaTime;

                if (mineCoup <= 0)
                {
                    mineCoup = mineTime;

                    Instantiate(mineObje, mineCenter.position, mineCenter.rotation);
                }
                
                break;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CoupFNC();
        }
    }

    public void CoupFNC()
    {
        
        currentStatus = tankStatus.coup;
        coupCounter = coupTime;

        anim.SetTrigger("Hit");

        Mine_Controller[] mines = FindObjectsOfType<Mine_Controller>();

        if (mines.Length > 0)
        {
            foreach (Mine_Controller mineTake in mines)
            {
                mineTake.DestroyFNC();
            }
        }
        healthStatus--;

        if (healthStatus<-0)
        {
            gameOver = true;
        }
        else
        {
            bulletTime /= bulletTimeUp;
            mineTime /= mineTimeUp;
        }
    }

    void StopMoveFNC()
    {
        tankBox.SetActive(true);
        currentStatus = tankStatus.shoot;
        bulletCounter = bulletTime;

        anim.SetTrigger("StopMove");
    }
}
