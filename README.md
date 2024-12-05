# Ninja Frog

**Ninja Frog**는 **Doodle Jump**를 모티브로 만든 게임입니다.

# 목차
1. [게임 조작 방법](#게임-조작-방법)
2. [아이템 및 기능](#아이템-및-기능)
   - [트램폴린](#트램펄린)
   - [헬리콥터 아이템](#헬리콥터-아이템)
   - [플래시-flash](#플래시-flash)
3. [코드 설명](#코드-설명)
   - [상태 머신 구조](#상태-머신-구조)
   - [자동 점프 구현](#자동-점프-구현)
   - [적 캐릭터 로직](#적-캐릭터-로직)
     - [적 캐릭터 종류](#적-캐릭터-종류)
     - [카멜레온의 혀 공격](#카멜레온의-혀-공격)
5. [Contributor](#contributor)
6. [Asset Attribution](#asset attribution)
- 
## 게임 조작 방법
- **왼쪽 이동**: `A` 키 또는 `←` 키
- **오른쪽 이동**: `D` 키 또는 `→` 키
- **미러링 기능**: 화면의 왼쪽 끝으로 이동하면 오른쪽 끝으로 이동하며, 그 반대도 가능합니다.
- **순간 이동**: `Space`키를 누르면 Player위의 2번째 Ground로 순간 이동합니다.
- - 영상-

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
- 플레이어보다 높은 위치에 있는 **두 개의 그라운드**로 순간이동합니다.
- 플래시는 **충전 방식**이며, 아래 게이지를 통해 충전 시간을 확인할 수 있습니다.

## 코드 설명
이 게임은 **상태 머신(State Machine)** 기반으로 설계되었습니다.

### 상태 머신 구조
_(상태 머신에 대한 그림 삽입 예정)_

### 자동 점프 구현
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

#### 카멜레온의 혀 공격
- 카멜레온은 혀로 공격하며, 혀의 길이에 따라 공격 범위가 달라집니다.
- 애니메이션 이벤트에서 `float` 타입의 길이 값을 전달받습니다.
- 카멜레온의 자식 객체에 `trigger`를 설정하여, 애니메이션 이벤트에서 받은 `float` 값에 따라 **x 스케일**을 조정합니다.
- 이를 통해 공격 길이를 조절하였습니다.

## Contributor
_(내용은 추후에 채워질 예정입니다.)_


## Asset Attribution

The assets in the 'Assets/Free' folder and 'Assets/Enemies' folder are sourced from the free resources provided by below sites. 
These assets are made available for free use under the terms specified on the Pixel Frog page.

- Source: [Pixel Adventure 1 by Pixel Frog](https://pixelfrog-assets.itch.io/pixel-adventure-1)
- Folder: `Assets/Free`
- Source: [Pixel Adventure 2 by Pixel Frog](https://pixelfrog-assets.itch.io/pixel-adventure-2)
- Folder: 'Assets/Enemies'
