# Ninja Frog

**Ninja Frog**는 **Doodle Jump**를 모티브로 만든 게임입니다.

# Contributor
-H00ong(박재홍)

# Asset Attribution
**Assets/Free** 폴더와 **Assets/Enemies** 폴더에 있는 에셋은 아래 사이트에서 제공하는 무료 리소스를 사용한 것입니다.  
이 에셋은 Pixel Frog 페이지에 명시된 조건에 따라 무료로 사용 가능합니다.

- 출처: [Pixel Adventure 1 by Pixel Frog](https://pixelfrog-assets.itch.io/pixel-adventure-1)  
  - 폴더: `Assets/Free`
- 출처: [Pixel Adventure 2 by Pixel Frog](https://pixelfrog-assets.itch.io/pixel-adventure-2)  
  - 폴더: `Assets/Enemies`

# 목차
0. [시작하기](#게임-시작하기)
1. [게임 조작 방법](#게임-조작-방법)
2. [아이템 및 기능](#아이템-및-기능)
   - [트램펄린](#트램펄린)
   - [헬리콥터 아이템](#헬리콥터-아이템)
   - [플래시-flash](#플래시-flash)
3. [코드 설명](#코드-설명)
   - [상태 머신 구조](#상태-머신-구조)
   - [플레이어 로직직](#자동-점프-구현)
   - [적 캐릭터 로직](#적-캐릭터-로직)

## 시작하기
1. **GitHub에서 다운로드**
   - GitHub 페이지로 이동한 후, `Code` 버튼을 클릭하고 **Download ZIP**을 선택하거나 아래 명령어로 레포지토리를 클론합니다:
     ```bash
     git clone <https://github.com/H00ong/NinjaFrog.git>
     ```

2. **Unity Hub에서 프로젝트 열기**
- Unity Hub를 실행합니다.
- **Add Project** 버튼을 눌러 다운로드받은 프로젝트 폴더를 선택합니다.

4. **Unity 버전 확인**
- Unity 프로젝트에 사용된 **Unity 버전**은 **2022.3.37f1(LTS)**입니다.
- 동일한 버전을 설치하지 않으면 충돌이 발생할 수 있으므로, Unity Hub에서 올바른 버전을 설치하세요.

6. **필요한 패키지 복원**
- Unity가 프로젝트를 열 때 자동으로 필요한 패키지를 복원합니다.
- 복원이 완료된 뒤 프로젝트가 정상적으로 열리는지 확인하세요.

7. **게임 실행 파일**
-

## 게임 조작 방법
- **왼쪽 이동**: `A` 키 또는 `←` 키
- **오른쪽 이동**: `D` 키 또는 `→` 키
- **미러링 기능**: 화면의 왼쪽 끝으로 이동하면 오른쪽 끝으로 이동하며, 그 반대도 가능합니다.
- **순간 이동**: `Space`키를 누르면 Player위의 2번째 Ground위로 순간 이동합니다.

## 아이템 및 기능
### 트램펄린
-이미지-
- 트램펄린을 타면 **더블 점프**를 할 수 있습니다.
- 더블 점프 중에는 적으로부터 피해를 받지 않습니다.
- _(비디오 클립 삽입 예정)_

### 헬리콥터 아이템
-이미지-
- 헬리콥터 아이템에 닿으면 **비행**이 가능합니다.
- 캐릭터 아래의 **파란색 게이지**는 아이템의 유지 시간을 표시합니다.
- 비행 중에는 적에게서 피해를 받지 않습니다.
- _(비디오 클립 삽입 예정)_

### 플래시 (Flash)
- `Space` 키를 누르면 **플래시**를 사용할 수 있습니다.
- 플레이어보다 높은 위치에 있는 **두 개의 위에 있는 그라운드**로 순간이동합니다.
- 플래시는 **충전 방식**이며, 아래 게이지를 통해 충전 시간을 확인할 수 있습니다.
- 영상

## 코드 설명
이 게임은 **상태 머신(State Machine)** 기반으로 설계되었습니다.

### 상태 머신 구조
_(상태 머신에 대한 그림 삽입 예정)_

### 플레이어 로직직
- **Ground 레이어**에 닿으면 자동으로 점프하도록 설정했습니다.
- `CheckLayer()` 함수를 통해 현재 접촉한 레이어가 `ground`, `enemyLayer`, `flyEnemyLayer`인지 판별합니다.
- 만약 `ground` 레이어라면 자동 점프를 실행합니다.

### 적 캐릭터 로직
#### 적 캐릭터 종류
- **BlueBirdEnemy**, **Bat**, **Plants**
  - 이들은 플레이어를 인지해야 합니다.
  - `PlayerDetector` 객체를 통해 일정 범위 내에 플레이어가 있는지 감지합니다.
  - 플레이어를 인식하면 공격하거나 공격 방향을 결정합니다.
- **Chameleon**, **Bunny**, **Slime**, **Turtle**
  - 그라운드의 끝 지점을 검사해야 합니다.
  - `LineCast` 함수를 사용하여 그라운드의 끝 지점에 도달하면 상태를 변경하도록 설정했습니다.

#### 카멜레온 Enemy의 공격 로직
- 카멜레온은 혀로 공격하며, 혀의 길이에 따라 공격 범위가 달라집니다.
- 애니메이션 이벤트에서 `float` 타입의 길이 값을 전달받습니다.
- 카멜레온의 자식 객체에 `trigger`를 설정하여, 애니메이션 이벤트에서 받은 `float` 값에 따라 **x 스케일**을 조정합니다.
- 이를 통해 공격 길이를 조절하였습니다.




