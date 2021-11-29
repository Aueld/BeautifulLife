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
        //���� String
        {
            HealthStr.Add("�ֱ⺸�� ���� ü��");
            HealthStr.Add("�ֱ⺸�ٴ� ���� ü��");
            HealthStr.Add("������ ü��");
            HealthStr.Add("ü���� �Ƿ����� �����ϴ�.");
            HealthStr.Add("ü���� � �����Դϴ�.");
            HealthStr.Add("����� ������ ü��");
            HealthStr.Add("������� �غ��� �͵�...");
            HealthStr.Add("���� Ǯ ���嵵 ����!");
            HealthStr.Add("��ġ�� �ʴ� ü��!");
            HealthStr.Add("�����浵 �Ŷ�!");
            HealthStr.Add("�����浵 �Ŷ�!");

            IntellectStr.Add("�ݺؾ�!?");
            IntellectStr.Add("�Ϳ��� ������ ����");
            IntellectStr.Add("������ ����");
            IntellectStr.Add("�ʸ��ʸ��� ������");
            IntellectStr.Add("�ſ� �ȶ��մϴ�.");
            IntellectStr.Add("���� ������ �����Դϴ�.");
            IntellectStr.Add("���� ������ ���� �� �� �ֽ��ϴ�.");
            IntellectStr.Add("�ڻ�� ����� ����� �����մϴ�.");
            IntellectStr.Add("������ õ���Դϴ�!");
            IntellectStr.Add("����ִ� ������ ����!");
            IntellectStr.Add("����ִ� ������ ����!");

            SensibilityStr.Add("������ �����ϴ�.");
            SensibilityStr.Add("�޸��� ����");
            SensibilityStr.Add("������ ������");
            SensibilityStr.Add("�Ƿ����� ǳ���� ������");
            SensibilityStr.Add("������ �ٸ��� ���ϴ�");
            SensibilityStr.Add("�ſ� �ΰ��մϴ�.");
            SensibilityStr.Add("���� ��� ���� �Ƹ���� �����ϴ�.");
            SensibilityStr.Add("ó�� �� ������� �����մϴ�.");
            SensibilityStr.Add("�����͵� �����մϴ�.");
            SensibilityStr.Add("�ܰ��ε� ������ ������");
            SensibilityStr.Add("�ܰ��ε� ������ ������");

            CharmStr.Add("�ŷ��� ������?!");
            CharmStr.Add("�ŷ��� �Դ� ����?!");
            CharmStr.Add("����մϴ�.");
            CharmStr.Add("���� �Ƹ��䱺��");
            CharmStr.Add("���� �ŷ��� ���� ���� ���ϴ�.");
            CharmStr.Add("���� �� ���� �����ϴ�.");
            CharmStr.Add("�ڵ��� ���� ����� �ŷ�");
            CharmStr.Add("������ �ָ��ϴ� �ŷ��Դϴ�.");
            CharmStr.Add("�̴� ���� �����Ѵ�!");
            CharmStr.Add("����ִ� ���� ȭ��!");
            CharmStr.Add("����ִ� ���� ȭ��!");

        }

        //���� String2
        {
            string[] set1 = { "�Ƿ��� ������ �����ϴ�.", "ȭ�忡 ������ �����ϴ�.", "�̼��� ��̰� �����ϴ�.", "��� ������ �����ϴ�." };
            string[] set2 = { "���ǿ� ������ �����ϴ�.", "�Ǳ⿡ ������ �����ϴ�.", "������ ��� ���� �����մϴ�.", "���� �ߴ� ���� �����մϴ�." };
            string[] set3 = { "���ڱ�⸦ �����մϴ�.", "��ǻ�͸� �����մϴ�.", "���� ����ġ�� �����մϴ�.", "������ �����մϴ�." };
            string[] set4 = { "��� �����մϴ�.", "������� ���մϴ�.", "������ �ǰ� �;��մϴ�.", "������ �����մϴ�." };

            fill.Add(set1);
            fill.Add(set2);
            fill.Add(set3);
            fill.Add(set4);
        }

        //������Ʈ �ε�
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

            ItemTrigger(other, Intellect, Charm, "Item_Int", "����", "�ŷ�", 0);
            ItemTrigger(other, Charm, Intellect, "item_cha", "�ŷ�", "����", 1);
            ItemTrigger(other, Sensibility, Health, "item_sec", "����", "ü��", 2);
            ItemTrigger(other, Health, Sensibility, "item_hea", "ü��", "����", 3);

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
                    
                    statUp.StatusUp("��Ʈ���� + 1");
                    
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

                    statUp.StatusUp("��Ʈ���� + 1");

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
        if (str == "�ŷ�")
            Charm++;
        else if (str == "����")
            Sensibility++;
        else if (str == "����")
            Intellect++;
        else if (str == "ü��")
            Health++;

        if (str == "�ŷ�" && MainManager.Instance.doubleUp == 0)
            Charm++;
        else if (str == "����" && MainManager.Instance.doubleUp == 1)
            Sensibility++;
        else if (str == "����" && MainManager.Instance.doubleUp == 2)
            Intellect++;
        else if (str == "ü��" && MainManager.Instance.doubleUp == 3)
            Health++;
        
    }

    private void DownStatus(string str)
    {
        if (str == "�ŷ�")
            Charm--;
        else if (str == "����")
            Sensibility--;
        else if (str == "����")
            Intellect--;
        else if (str == "ü��")
            Health--;
    }

    private string HealthJug()
    {
        string str = null;

        if (HealthStatus < 33)
        {
            str = "�ǰ��� ���޴ϴ�.";
            Healthimg.sprite = HealthImgs[0];
            MainManager.Instance.speedVal = 0.75f;
        }
        else if (HealthStatus >= 33 && HealthStatus < 66)
        {
            str = "�ǰ��մϴ�.";
            Healthimg.sprite = HealthImgs[1];
            MainManager.Instance.speedVal = 1f;
        }
        else if (HealthStatus >= 66)
        {
            str = "�ſ� �ǰ��մϴ�.";
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
