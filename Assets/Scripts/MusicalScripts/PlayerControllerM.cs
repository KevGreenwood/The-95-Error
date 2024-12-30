using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerControllerM : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public GameObject bullet;
    public SpriteRenderer sr;
    public SpriteRenderer sr_s;
    public SpriteRenderer cross;
    public Camera cam;
    public Transform boundaryCircleTR;
    public TMP_Text percentageText;
    float boundaryCircleRad = 4.25f; //Is used to assign the rad of the circle, lmao Unity u sucks
    public GameObject particles;
    public Renderer particles_s;
    public ParticleSystem ps;
    public ParticleSystem ps_s;
    int seed;
    ParticleSystem.MainModule main;
    float speed = 700f;
    public int percentage;
    GameObject obj;
    public GameObject menu;
    Vector3 pos;
    public bool hit;
    float timer;
    public AudioSource AS1;
    public AudioClip shootClip;
    public AudioClip hitClip;
    public AudioClip shatterClip;
    float pitchS;
    public float slowMTime = 0.5f;
    public float bulletTime = 0.3f;
    public Volume volume;       //PostFX
    private ChromaticAberration chromAberration;
    private Vignette vignette;
    private Bloom bloom;

    void Start()
    {
        //ColorControllerM.instance.AddSprite(sr_s);
        percentage = 100;
        PostFX();
    }
    void Update()
    {
        if (GameControllerM.instance.state != 3) return;

        if (InputControllerM.instance.playerInputEnabled) //Parametros de muerte
        {
            if (hit)
            {
                DisableFx();
                DeathPostFX();
                timer += Time.fixedDeltaTime;
                if (timer >= 1f)
                {
                    GameControllerM.instance.ResetGame();
                }
            }
            else
            {
                ManageInput();
            }
        }

        if (GameControllerM.instance.state == 4)
        {
            tr.position = Vector3.zero;
            tr.rotation = Quaternion.identity;
            rb.linearVelocity = Vector3.zero;
        }
    }
    public void PostFX()
    {
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromAberration);
        volume.profile.TryGet(out bloom);
        RecoverPostFX();
    }
    public void RecoverPostFX()
    {
        vignette.intensity.value = 0.3f;
        chromAberration.intensity.value = 0.15f;
        bloom.intensity.value = 0.5f;
    }
    public void BTPostFX()
    {
        vignette.intensity.value = 0.4f;
        chromAberration.intensity.value = 0.45f;
        bloom.intensity.value = 1f;
    }
    public void DeathPostFX()
    {
        vignette.intensity.value = 0.45f;
        chromAberration.intensity.value = 0.5f;
        bloom.intensity.value = 1.5f;
    }

    void ManageInput()
    {
        if (InputControllerM.instance.w) //Controlador arriba
        {
            rb.AddForce(tr.up * speed * Time.deltaTime);
        }
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, 4f);

        if (InputControllerM.instance.leftClick)
        {
            if (Random.Range(1, 101) <= percentage) //PORCENTAJES
            {
                obj = Instantiate(bullet);
                obj.transform.position = tr.position + (tr.up * 0.5f);
                obj.transform.rotation = tr.rotation;
                percentage--;
                percentageText.text = percentage + "";
                PlayShoot();
            }
            else if (!hit)
            {
                hit = true;
                timer = 0;

                particles.transform.position = tr.position;
                seed = Random.Range(0, 1000);
                ps.randomSeed = (uint)seed;
                ps_s.randomSeed = (uint)seed;
                main = ps_s.main;
                Color32 c = ColorControllerM.instance.currentColor;
                c.a = 255;
                main.startColor = new ParticleSystem.MinMaxGradient(c, c);
                particles.SetActive(true);

                sr.enabled = false;
                sr_s.enabled = false;

                PlayShatter();
                Time.timeScale = slowMTime;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }

        if (InputControllerM.instance.rightClick) //BulletTime
        {
            cross.color = Color.red;

            Time.timeScale = bulletTime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            BTPostFX();
        }
        if (Input.GetMouseButtonUp(1)) //End BulletTime
        {
            cross.color = new Color(0f, 0.4705883f, 0.8431373f, 1f);
            Time.timeScale = 1f;
            RecoverPostFX();
        }
        // turn
        pos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        pos.z = 0;
        tr.up = pos - tr.position;
    }
    public void RecoverPercentage()
    {
        percentage = 100;
        percentageText.text = percentage + "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hit)
        {
            hit = true;
            timer = 0;
            PlayHit();
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            DisableFx();
            DeathPostFX();
        }
    }

    public void DisableFx()
    {
        menu.SetActive(false);
    }
    public void EnableFx()
    {
        menu.SetActive(true);
    }

    void PlayShoot()
    {
        pitchS = 1f + (100 - percentage) / 50f;
        if (pitchS > 2) pitchS = 2;
        AS1.pitch = pitchS;
        AS1.PlayOneShot(shootClip);
    }
    void PlayHit()
    {
        AS1.pitch = Random.Range(0.9f, 1.1f);
        AS1.PlayOneShot(hitClip);
    }
    void PlayShatter()
    {
        AS1.pitch = Random.Range(0.9f, 1.1f);
        AS1.PlayOneShot(shatterClip);
    }
}