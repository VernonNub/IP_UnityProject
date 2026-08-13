using UnityEngine;

public class EventManager : MonoBehaviour
{
    private bool isUsed = false;

    public enum Events
    {
        Vape,
        NextScene,
        SceneProgress,
        FinalScene
    }

    public Events gameEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (!isUsed)
        {
            if (other.gameObject.name == "PlayerCapsule")
            {
                switch (gameEvent)
                {
                    case Events.NextScene:
                        GameManager.instance.storyProgress += 1;
                        GameManager.instance.ChangeScene(GameManager.instance.storyProgress + 1);
                        break;

                    case Events.SceneProgress:
                        GameManager.instance.sceneProgress += 1;
                        break;

                    case Events.FinalScene:
                        if (GameManager.instance.NPC1Relationship > GameManager.instance.NPC2Relationship)
                        {
                            GameManager.instance.storyProgress += 1;
                            GameManager.instance.ChangeScene(GameManager.instance.storyProgress + 1);
                        }
                        else
                        {
                            GameManager.instance.storyProgress += 2;
                            GameManager.instance.ChangeScene(GameManager.instance.storyProgress + 1);
                        }
                        break;
                }
            }

            isUsed = true;
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
            }
        }
    }
}
