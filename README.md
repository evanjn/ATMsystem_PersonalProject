# ATMsystem_PersonalProject
Creating ATM system in Unity for Personal Project on 10th week

# 🏦 Sparta Bank – ATM System
스파르타 부트캠프 10주차 심화 개인 과제 프로젝트입니다.
유저 정보를 기반으로 입금과 출금 그리고 송금 기능을 구현했습니다.
이 ATM 프로그램은 데이터 구조 설계와 UI 연결 연습을 위해 제작되었습니다.

### 📂 프로젝트 구조

```
Assets/
 ├── Scripts/
 │     ├── UserData.cs          // 사용자의 정보를 저장하는 데이터 클래스
 │     ├── GameManager.cs       // 싱글톤. UserData를 관리하고 초기값 설정
 │     ├── StateUI.cs           // UI 표시 및 업데이트 담당
 │     ├── DepositUI.cs         // 입금 기능담당, 금액을 옮기고 잔액 부족시 에러창 실행
 │     ├── WithdrawalUI.cs      // 출금 기능담당, 금액을 옮기고 잔액 부족시 에러창 실행
 │     ├── TransferUI.cs        // 다른 사용자에게 금액을 옮기고, 예외상황 발생 시 에러 창 실행
 │     ├── LoginUI.cs           // 저장된 사용자 정보를 검증하고 ATM화면으로 이동시키는 역할
 │     ├── SignUpUI.cs          // 새로운 사용자 생성을 하며 저장하는 역할
 │     └── UIManager.cs         // ATM 화면 전체 패널 UI를 열고 닫는 전환 역활
 ├── UI/
 │     ├── Title                // ATM 제목
 │     ├── ResetBtn             // 저장된 정보 모두 삭제
 │     ├── PopupLogin           // 로그인창 : ID/PW 입력 및 회원가입 가능
 │     ├── ATM                  // 로그인 성공시 나타나는 ATM 메인 화면
 │     ├── Deposit              // 금액을 입력하여 입금을 할 수 있는 화면
 │     ├── Withdrawal           // 금액을 입력하여 출금을 할 수 있는 화면
 │     ├── Transfer             // 대상과 금액을 입력하여 송금할 수 있는 화면
 │     ├── PopupSignup          // 정보를 입력하여 회원가입을 할 수 있는 창
 │     ├── InsufficiencyPopup   // 금액이 부족할 때 나타나는 오류 창
 │     ├── ErrorPopup           // 정보가 알맞지 않을 때 나타나는 오류 창
 │     ├── InvailRecipientPopup // 대상의 정보가 알맞지 않을 때 나타나는 오류 창
 │     ├── LogOut               // ATM 기능 창에서 로그인 화면으로 돌아가는 버튼
 │     └── GameManager          // 싱글톤을 통한 전역 상태 관리
 └── Scenes/
        └── SampleScene
```
### 💰 ATM 기능
1. 입금(Deposit) : 현금을 계좌 잔액으로 이동, 업데이트 후 UI 자동 갱신
2. 출금(Withdrawal) : 잔액을 현금으로 이동, 잔액 부족시 오류 창 실행
3. 송금(Transfer) : 다른 사용자에게 입력한 금액을 이동, 예외 발생시 오류창 실행
4. 로그인(Login) : 저장되있는 사용자 정보로 ATM 기능을 이용할 수 있도록 진입 보안기능
5. 회원가입(Signup) : 새로운 계정을 만들어 계좌를 저장해 이용할 수 있도록 하는 기능