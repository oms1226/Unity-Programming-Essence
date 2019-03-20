using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        //주석 : 코멘트
        //캐릭터 프로필
        //문자열 string
        string characterName = "라라 크로프트";
        //정수 int
        int age = 17;
        //참 거짓 bool (boolean)
        bool isFemale = true;
        //실수(소숫점ㅇㄹ 포함하는 숫) float
        //floating point(부동 소수)
        float height = 167.4f;
        //double 실수 (64비)
        double weight = 63.7;
        //char 믄지 (character)
        char bloodType = 'B';

        Debug.Log("캐릭터의 이름:" + characterName);
        Debug.Log("나이:" + age);
        Debug.Log("키:" + height);
        Debug.Log("몸무게:" + weight);
        Debug.Log("여성인가?:" + isFemale);
        Debug.Log("혈액형:" + bloodType);

        float distance = GetDistance(0, 0, 3, 4);
        Debug.Log("거리: " + distance);
    }

    // 결과로는 실수를 주는 함수
    // 두 점(x1, y1) (x2, y2) 사이의 거리를 리턴하는 함수
    float GetDistance(float x1, float y1, float x2, float y2)
    {
        //가로 길이
        float width = x2 - x1;
        //세로 길이
        float height = y2 - y1;
        //가로 길이 제곱과 세로 길이 제곱을 더하기
        float distance = width * width + height * height;
        //제곱근 구하기
        distance = Mathf.Sqrt(distance);
        //계산된 거(빗변의 길이)
        return distance;
    }
}
