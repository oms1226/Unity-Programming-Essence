using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour {
    public float speed = 10f; // 이동 속도


    private void Update() {
        // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
        //소문자로 시작하는 transform 으, 자신의 게임 오브젝트의 트랜스폼 컴포넌트로 즉시 접근
        //transform.Translate(Vector3.left * speed);
        // 1초 60번 * 한번에 10m = 1초에 600m
        transform.Translate(-speed, 0f, 0f);//겁나 빨리 움직인다.
        // 1초 60번 * 한번에 10m * 1/60 = 1초 10m
        //Time.deltaTime = Update 와 Update 사이의 실행 간격 = 화면의 갱신 주기
        //1번에 60초 주기는
    }
}