# SimpleERP
WPF 를 이용한 간단한 ERP 만들어보기

# 시스템 구성
1. Client   : WPF (Core 3.0)
2. Server   : ASP.NET CORE 3.0
3. DataBase : MS-SQL 2017 linux

# 생각해볼 것
1. WebAPI RESTful 를 할지? 아니면 그냥 mvc 형태로 할지?
-> mvc 형태로, RESTful 설계가 어려움, 로그인 이후 클라이언트 구현에 집중

2. SignalR 을 이용한 로그인 상태 관리?
-> 일단 cookie 로그인 관리만 하고, 상태관리는 나중에

3. Transaction 구성 처리에 대한 문제?
-> ViewModel 전송하는걸로 

4. 개별 모듈은 사용자정의 컨트롤로 Tab Attach 하는 형태로 추가

5. 동일 모델을 서버와 클라이언트에서 사용하기 가장 편한 방법은 뭐가 있을까?
 1) Get이라는 메소드를 클라이언트에서는 서버 call, 서버에서는 db call 하는 형태로 만들기
   - 인터페이스를 통한 구현
   - virtual method 를 통해 Get같은 메소드만 override?


# 인사관리
 1. 사원 관리 - 입사, 퇴사
 2. 근태관리 - 출입 관리
 3. 급여 관리
 4. 퇴직

#총무관리
1. 식당 관리? -> 항목별 공제 관리?