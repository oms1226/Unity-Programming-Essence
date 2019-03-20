using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    // start는 한번만 호출되지, 해당 함수는 비활성화해서 활성화 될때마다 호출된다 
    private void OnEnable() {
        // 발판을 리셋하는 처리
        stepped = false;
        foreach(GameObject obstacle in obstacles)
        {
            obstacle.SetActive(false);
            //0 or 1
            if(Random.Range(0,2) == 0)
            {
                //50% 확률로 현재 꺼낸 장애물이 활성화
                obstacle.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(stepped)
        {
            return;
        }
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        GameManager.instance.AddScore(1);
        stepped = true;
    }
}