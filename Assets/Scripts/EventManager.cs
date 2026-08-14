using UnityEngine;

public class EventManager : MonoBehaviour
{
    public bool isUsed = false;

    public enum Events
    {
        Vape,
        NextScene,
        SceneProgress,
        FinalScene,
        RemoveVFX,
        Alarm
    }

    public Events gameEvent;

    public GameObject VFX;

    private void OnTriggerEnter(Collider other)
    {
        if (!isUsed)
        {
            if (other.gameObject.name == "PlayerCapsule")
            {
                switch (gameEvent)
                {
                    case Events.NextScene:
                        GameManager.instance.IncreaseProgress();
                        isUsed = true;
                        break;

                    case Events.SceneProgress:
                        GameManager.instance.sceneProgress += 1;
                        isUsed = true;
                        break;

                    case Events.FinalScene:
                        if (GameManager.instance.NPC1Relationship > GameManager.instance.NPC2Relationship)
                        {
                            GameManager.instance.IncreaseProgress();
                        }
                        else
                        {
                            GameManager.instance.storyProgress += 2;
                            GameManager.instance.sceneProgress = 1;
                        }
                        isUsed = true;
                        break;

                    case Events.RemoveVFX:
                        Destroy(VFX);
                        isUsed = true;
                        break;

                }
            }

            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "PlayerCapsule")
        {
            switch (gameEvent)
            {
                case Events.Vape:
                    other.gameObject.GetComponent<PlayerManager>().playerSanity += 10 * Time.deltaTime;
                    break;

                case Events.Alarm:
                    if (!isUsed)
                    {
                        if (GameManager.instance.storyProgress == 4 && GameManager.instance.sceneProgress > 1)
                        {
                            Debug.Log("ALARM CONDITIONS PASSED");

                            isUsed = true;
                            GameManager.instance.bgm.clip = GameManager.instance.alarmBGM;
                            GameManager.instance.bgm.volume = 0.5f;

                            GameManager.instance.bgm.Play();

                        }
                    }
                    break;
            }
        }
    }
}
