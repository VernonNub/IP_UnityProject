using UnityEngine;

public class EventManager : MonoBehaviour
{
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
        if(other.gameObject.name == "PlayerCapsule")
        {
            switch (gameEvent)
            {
                case Events.NextScene:
                    GameManager.instance.storyProgress += 1;
                    GameManager.instance.ChangeScene(GameManager.instance.sceneProgress);
                    break;

                case Events.SceneProgress:
                    GameManager.instance.sceneProgress += 1;
                    break;
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
            }
        }
    }
}
