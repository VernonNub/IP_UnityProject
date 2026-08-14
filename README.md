# Integrated Project, *Depths*
By Two Dot Studios.

Names: Aerica Gan Chai Ting, Vernon Loh Jin Feng, Lee Dong Ze, Zac

Module Group: IM02

## IMPORTANT THINGS TO NOTE
Please install git lfs before cloning.

run
`$ git lfs install`
in git bash

`git lfs` is used to store larger (>100MB) files, like texture files, or lightmaps.

(please contact any of us if any issues persists)

# Introduction
Secondary school is a unique time of everyones life. They are undergoing puberty, relationships feel as important as ever, and they are still learning about the world. Maybe some of these teens, 

## Supported Platforms
This game only supports keyboard and mouse.
It can run on any desktop or laptop with unity, and should be run using an 16x9 aspect ratio.
On windows, plug in before running, or the program itself might be prone to lag.

## How to play
**WASD** to move,

**Space** to Jump,

**L SHIFT** to sprint.

**E** to interact with items and characters within the world,

**ESC** to pause,

**LMB** to interact with dialogue options and User Interface

## Limitations/Bugs
Bugs
 Bugs where some AI states do not run right now.
 Error where Vaper will take too long to walk to vape.
 Animations for AI got some issues and wont load properly.

Limitations:
 lack of animations currently
 minigames can be added for more engagement
 scene is very empty and not realistic

## Implementation of AI
FSM diagram
VaperAI --> walking --> Thinking -->
                    --> Talking -->   walking --> back to loop (Each action thinking, talking and yelling will be based on the location of AI)
                    --> Yelling -->
                    --> Idle    -->

StudentCouncilAI --> walking --> Idle -->
                             --> Talking -->   walking --> back to loop (Each action thinking, talking and yelling will be based on the location of AI)
                             --> scolding -->

VaperAI and StudentCouncilAI is made to roam random locations selected by us based on the scene. (E.g. classroom scene, they will roam class room etc)
VaperAI is more special as it will roam to the toilet to vape (Obvious during one of the scenes where the alarm triggers)
Both AI will also walk to the stair to help lead the player to the canteen area

# Solutions
**To Win**

Choose the options you want, not all options may seem like what they are. Consider carefully before selecting them, it will affect your experiences in the game!

Enter spaceship and place both items in
# References

Models:
- https://skfb.ly/6xnMT
- https://skfb.ly/o9KuI
- https://skfb.ly/pvuHN
- https://skfb.ly/onE8X
- https://skfb.ly/oK7UQ
- https://skfb.ly/6U8rt
- https://skfb.ly/orBWs
- https://skfb.ly/oOT8O
- https://skfb.ly/opsWB
- https://skfb.ly/6U8rt
- https://skfb.ly/6YqPN
- https://skfb.ly/oE8S8
- https://skfb.ly/6twoA
- https://skfb.ly/6S9CM
- https://skfb.ly/oWtJ6
- https://skfb.ly/oSI7x
- https://skfb.ly/o6XON

Sound Effects:
https://pixabay.com/sound-effects/search/ambient/

All other assets are custom created.
