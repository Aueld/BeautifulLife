using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScore : StatusManager
{
    public GameObject target;

    public ParticleSystem particle;
    public ParticleSystem boom;
    public ParticleSystem hit;
    public ParticleSystem attack;

    public Sprite[] HealthImgs;

    private Image Healthimg;

    private SFX sfx;

    private void Start()
    {
        //상태 String
        {
            HealthStr.Add("애기보다 못한 체력");
            HealthStr.Add("애기보다는 나은 체력");
            HealthStr.Add("보통의 체력");
            HealthStr.Add("체력이 또래보다 좋습니다.");
            HealthStr.Add("체력이 어른 수준입니다.");
            HealthStr.Add("운동선수 수준의 체력");
            HealthStr.Add("운동선수를 해보는 것도...");
            HealthStr.Add("복싱 풀 라운드도 가능!");
            HealthStr.Add("지치지 않는 체력!");
            HealthStr.Add("마라톤도 거뜬!");
            HealthStr.Add("마라톤도 거뜬!");

            IntellectStr.Add("금붕어!?");
            IntellectStr.Add("귀여운 강아지 수준");
            IntellectStr.Add("보통의 지력");
            IntellectStr.Add("똘망똘망한 눈동자");
            IntellectStr.Add("매우 똑똑합니다.");
            IntellectStr.Add("영재 수준의 지식입니다.");
            IntellectStr.Add("높은 수준의 논물을 볼 수 있습니다.");
            IntellectStr.Add("박사와 대등한 토론이 가능합니다.");
            IntellectStr.Add("세기의 천재입니다!");
            IntellectStr.Add("살아있는 지식의 보고!");
            IntellectStr.Add("살아있는 지식의 보고!");

            SensibilityStr.Add("감성이 없습니다.");
            SensibilityStr.Add("메마른 감성");
            SensibilityStr.Add("보통의 감수성");
            SensibilityStr.Add("또래보다 풍부한 감수성");
            SensibilityStr.Add("세상을 다르게 봅니다");
            SensibilityStr.Add("매우 민감합니다.");
            SensibilityStr.Add("세상 모든 것을 아름답게 느낍니다.");
            SensibilityStr.Add("처음 본 사람과도 공감합니다.");
            SensibilityStr.Add("누구와도 공감합니다.");
            SensibilityStr.Add("외계인도 이해할 감수성");
            SensibilityStr.Add("외계인도 이해할 감수성");

            CharmStr.Add("매력이 뭔가요?!");
            CharmStr.Add("매력은 먹는 거죠?!");
            CharmStr.Add("평범합니다.");
            CharmStr.Add("눈이 아름답군요");
            CharmStr.Add("묘한 매력이 넘쳐 눈이 갑니다.");
            CharmStr.Add("눈을 땔 수가 없습니다.");
            CharmStr.Add("뒤돌아 보게 만드는 매력");
            CharmStr.Add("세상이 주목하는 매력입니다.");
            CharmStr.Add("미는 내가 정의한다!");
            CharmStr.Add("살아있는 미의 화신!");
            CharmStr.Add("살아있는 미의 화신!");

        }

        //상태 String2
        {
            string[] set1 = { "의류에 관심이 많습니다.", "화장에 관심이 많습니다.", "이성에 흥미가 많습니다.", "포즈에 관심이 많습니다." };
            string[] set2 = { "음악에 관심이 많습니다.", "악기에 관심이 많습니다.", "공감을 얻는 것을 좋아합니다.", "춤을 추는 것을 좋아합니다." };
            string[] set3 = { "전자기기를 좋아합니다.", "컴퓨터를 좋아합니다.", "남을 가르치기 좋아합니다.", "독서를 좋아합니다." };
            string[] set4 = { "운동을 좋아합니다.", "경쟁심이 강합니다.", "군인이 되고 싶어합니다.", "제복을 좋아합니다." };

            fill.Add(set1);
            fill.Add(set2);
            fill.Add(set3);
            fill.Add(set4);
        }

        //오브젝트 로드
        {
            Healthimg = GameObject.Find("Health").GetComponent<Image>();

            Bar[0] = GameObject.Find("ChaScrollbar").GetComponent<Image>();
            statText[0] = GameObject.Find("ChaText").GetComponent<Text>();
            statFText[0] = GameObject.Find("ChaFText").GetComponent<Text>();

            Bar[1] = GameObject.Find("SenScrollbar").GetComponent<Image>();
            statText[1] = GameObject.Find("SenText").GetComponent<Text>();
            statFText[1] = GameObject.Find("SenFText").GetComponent<Text>();

            Bar[2] = GameObject.Find("IntScrollbar").GetComponent<Image>();
            statText[2] = GameObject.Find("IntText").GetComponent<Text>();
            statFText[2] = GameObject.Find("IntFText").GetComponent<Text>();

            Bar[3] = GameObject.Find("HeaScrollbar").GetComponent<Image>();
            statText[3] = GameObject.Find("HeaText").GetComponent<Text>();
            statFText[3] = GameObject.Find("HeaFText").GetComponent<Text>();

            pData = GetComponent<PlayerData>();
            statusText = GameObject.Find("ResultText").GetComponent<Text>();
            text = GameObject.FindGameObjectWithTag("StatusText").GetComponent<Text>();
            statUp = GameObject.FindGameObjectWithTag("stat").GetComponent<StatUp>();
        }

        sfx = GameObject.Find("SFX").GetComponent<SFX>();

        //string _Filestr = "Character.xml";
        //System.IO.FileInfo fi = new System.IO.FileInfo(_Filestr);
        //if (fi.Exists)
        //{
        //    strarr = pData.LoadXmlStatus().Split(',');
        //    for (int i = 0; i < 6; i++)
        //    {
        //        arr[i] = int.Parse(strarr[i]);
        //    }
        //    SetVelue(arr);
        //}


        if (pData.LoadXmlStatus() != null)
        {
            strarr = pData.LoadXmlStatus().Split(',');
            for (int i = 0; i < 6; i++)
            {
                arr[i] = int.Parse(strarr[i]);
            }
            SetVelue(arr);
        }

        SetText();

        for (int i = 0; i < 6; i++)
            token[i] = 0;
    }

    private void Update()
    {
        if (!check && MainManager.Instance.dontMov)
            FillJug();

        if (MainManager.Instance.gameOver)
        {
            MainManager.Instance.status = Health.ToString() + "," + Intellect.ToString() + "," + Sensibility.ToString() + "," + Charm.ToString()
                 + "," + Stress.ToString() + "," + HealthStatus.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!MainManager.Instance.dontMov)
        {
            if (!check)
                check = true;

            ItemTrigger(other, Intellect, Charm, "Item_Int", "지력", "매력", 0);
            ItemTrigger(other, Charm, Intellect, "item_cha", "매력", "지력", 1);
            ItemTrigger(other, Sensibility, Health, "item_sec", "감수", "체력", 2);
            ItemTrigger(other, Health, Sensibility, "item_hea", "체력", "감수", 3);

            if (other.tag == "block")
            {

                Destroy(other.gameObject);

                particle.transform.LookAt(target.transform);
                particle.Play();

                if (MainManager.Instance.playerJump)
                {
                    attack.transform.position = transform.position;
                    attack.Play();
                    
                    HealthStatus++;
                    
                    statUp.StatusUp("스트레스 + 1");
                    
                    Stress++;
                }
                if (MainManager.Instance.playerAttack)
                {                    
                    attack.transform.position = transform.position;
                    attack.Play();

                    HealthStatus++;
                }
                else if (!MainManager.Instance.playerAttack)
                {
                    attack.transform.position = transform.position;
                    attack.Play();

                    StartCoroutine(Stuck());

                    if(HealthStatus != 0)
                        HealthStatus--;

                    statUp.StatusUp("스트레스 + 1");

                    Stress++;

                    if (Stress > Health)
                        HealthStatus -= (Stress - Health);
                    else if(Health >= Stress)
                        HealthStatus += (Health - Stress);
                }

                sfx.SoundAttack();

            }

            SetText();
        }
    }

    private void SetText()
    {
        Bar[0].fillAmount = Charm / 100f;
        statText[0].text = Charm.ToString();

        Bar[1].fillAmount = Sensibility / 100f;
        statText[1].text = Sensibility.ToString();

        Bar[2].fillAmount = Intellect / 100f;
        statText[2].text = Intellect.ToString();

        Bar[3].fillAmount = Health / 100f;
        statText[3].text = Health.ToString();

        StatusStr();
        text.text = HealthJug();

        check = false;
    }

    private IEnumerator Stuck()
    {
        MainManager.Instance.playerHit = true;
        yield return new WaitForSeconds(0.5f);
        MainManager.Instance.playerHit = false;
    }

    private void UpStatus(string str)
    {
        if (str == "매력")
            Charm++;
        else if (str == "감수")
            Sensibility++;
        else if (str == "지력")
            Intellect++;
        else if (str == "체력")
            Health++;

        if (str == "매력" && MainManager.Instance.doubleUp == 0)
            Charm++;
        else if (str == "감수" && MainManager.Instance.doubleUp == 1)
            Sensibility++;
        else if (str == "지력" && MainManager.Instance.doubleUp == 2)
            Intellect++;
        else if (str == "체력" && MainManager.Instance.doubleUp == 3)
            Health++;
        
    }

    private void DownStatus(string str)
    {
        if (str == "매력")
            Charm--;
        else if (str == "감수")
            Sensibility--;
        else if (str == "지력")
            Intellect--;
        else if (str == "체력")
            Health--;
    }

    private string HealthJug()
    {
        string str = null;

        if (HealthStatus < 33)
        {
            str = "건강이 나쁩니다.";
            Healthimg.sprite = HealthImgs[0];
            MainManager.Instance.speedVal = 0.75f;
        }
        else if (HealthStatus >= 33 && HealthStatus < 66)
        {
            str = "건강합니다.";
            Healthimg.sprite = HealthImgs[1];
            MainManager.Instance.speedVal = 1f;
        }
        else if (HealthStatus >= 66)
        {
            str = "매우 건강합니다.";
            Healthimg.sprite = HealthImgs[2];
            MainManager.Instance.speedVal = 2f;
        }
        return str;
    }

    private void ItemTrigger(Collider other, int up, int down, string tag, string str, string dStr, int index)
    {
        if (other.tag == tag)
        {

            Destroy(other.gameObject);

            sfx.SoundEffect();

            particle.transform.LookAt(target.transform);
            particle.Play();


            boom.transform.position = transform.position;
            boom.Play();


            statUp.StatusUp(str + " + 1");

            if (up < 100)
                UpStatus(str);

            token[index]++;

            if (token[index] == 2)
            {
                token[index] = 0;
                if (down != 0)
                    DownStatus(dStr);
            }


        }
    }

    private void StatusStr()
    {
        statFText[0].text = CharmStr[Charm / 10];
        statFText[1].text = SensibilityStr[Sensibility / 10];
        statFText[2].text = IntellectStr[Intellect / 10];
        statFText[3].text = HealthStr[Health / 10];
    }

    private void FillJug()
    {
        check = true;

        int index = 0, temp;

        if (Charm > Sensibility && Charm > Intellect && Charm > Health)
        {
            index = 0;
            MainManager.Instance.doubleUp = 0;
            MainManager.Instance.HighStat = Charm;
        }
        if (Sensibility > Charm && Sensibility > Intellect && Sensibility > Health)
        {
            index = 1;
            MainManager.Instance.doubleUp = 1;
            MainManager.Instance.HighStat = Sensibility;
        }
        if (Intellect > Sensibility && Intellect > Sensibility && Intellect > Health)
        {
            index = 2;
            MainManager.Instance.doubleUp = 2;
            MainManager.Instance.HighStat = Intellect;
        }
        if (Health > Sensibility && Health > Intellect && Health > Charm)
        {
            index = 3;
            MainManager.Instance.doubleUp = 3;
            MainManager.Instance.HighStat = Health;
        }

        string[] str;

        str = fill[index];

        int rand = Random.Range(1, 100);
        temp = rand;
        {
            if (index == 0 && rand < 30)
            {
                statusText.text = str[0];
            }
            else if (index == 0 && rand >= 30 && rand < 50)
            {
                statusText.text = str[1];
            }
            else if (index == 0 && rand >= 50 && rand < 80)
            {
                statusText.text = str[2];
            }
            else if (index == 0 && rand >= 80 && rand < 100)
            {
                statusText.text = str[3];
            }

            if (index != 0)
            {
                statusText.text = str[rand / 25];
            }

            MainManager.Instance.endIndex = index;
            MainManager.Instance.endPoint = temp;
        }
    }
}
