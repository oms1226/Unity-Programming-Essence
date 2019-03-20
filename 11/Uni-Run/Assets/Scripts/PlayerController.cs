using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
        // 초기화
        //사용할 컴포넌트들의 참조를 가져오기 //여기서는 draw & drop 이 아니라 private 로 코드로 직접 가져왔다.
        //Player 게임 오브젝트에게 붙어 있는 컴포넌트들을 코드로 가져오기
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
   }
    //화면이 갱신될 때 자동 실행 (평균적으로 1초에 60)
    private void Update() {
        if (isDead)
        {
            //사망 시 이 이하의 코드로 더이상 실행이 못내려가게 하기
            return;
        }
        // 사용자 입력을 감지하고 점프하는 처리
        //0: 마우스 왼쪽 버튼, 1: 마우스 오른쪽 버, 2: 마우스 휠
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //점프 횟수를 증가
            jumpCount = jumpCount + 1;
            //점프 직전에 중력 순간 속도를 제로로 만들기
            playerRigidbody.velocity = Vector2.zero;
            //리지드 바디를 통해 위쪽으로 힘주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();

        } else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)//Input.GetMouseButtonUp(0) 손을 땔때만 감지한.
        {
            //손을 너무 일찍 때, 속도가 많이 반감되게 하기
            //손을 오래 누르면 멀리 점프하기
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        else
        {

        }
        //애니메이터 컴포넌트의 Grounded 파라미터, 현재 바탁에 닿았는지에 대한 상태를 넣기
        animator.SetBool("Grounded", isGrounded);
    }

    //unity 함수가 아니.
   private void Die() {
        // 사망 처리
        //사망 상태를 참으로
        isDead = true;
        //애니메이터 컴포넌트의 Die 트리커 파라미터를 당기기(셋하기)
        animator.SetTrigger("Die");
   }

    //2D Collider 속성을 가지고 있고 다른 Collider랑 부딪혔을 때 자동으로 호출된다
   private void OnTriggerEnter2D(Collider2D other) {
       // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
       if(other.CompareTag("Dead"))//== other.GameObject.CompareTag("Dead")
        {
            Die();
        }
    }

    //일반 충돌 시 자동실행
   private void OnCollisionEnter2D(Collision2D collision) {
        // 바닥에 닿았음을 감지하는 처리
        //대략 45' 경사 미만의 바닥이다
        //충돌 지점 중에서 0번째 지점의 충돌 표면 수직방향의 화살표가 위로 많이 가있어야 함
        if(collision.contacts[0].normal.y > 0.7f)
        {
            // 점프횟수를 리셋
            jumpCount = 0;
            // 바닥에 닿은 상태를 참으로
            isGrounded = true;
        }

   }
    //서로 충돌해서 붙어 있는 상태에서 떼어질때 자동실행
   private void OnCollisionExit2D(Collision2D collision) {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
   }
}