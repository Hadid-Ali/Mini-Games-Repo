using UnityEngine;

public class GameplayInputHandler : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main; //A Service can be implemented to give reference
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent(out SoccerPlayer soccerPlayer))
                {
                    soccerPlayer.Select();
                }
            }
        }
    }
}
