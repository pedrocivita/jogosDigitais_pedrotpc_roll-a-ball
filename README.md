# Terraformer

[![Unity](https://img.shields.io/badge/Unity-2022.3.44f1-000000?style=flat&logo=unity&logoColor=white)](https://unity.com/)
[![C#](https://img.shields.io/badge/C%23-Language-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Universal RP](https://img.shields.io/badge/Universal%20RP-Enabled-5C2D91?style=flat)](https://unity.com/srp/universal-render-pipeline)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20WebGL-blue?style=flat)](https://unity.com/)
[![License](https://img.shields.io/badge/License-Educational-green?style=flat)](LICENSE)

A 3D physics-based collection game developed as part of the Computer Engineering program at Insper. In Terraformer, players navigate a post-nuclear environment, collecting sand blocks to stabilize the planet's ecosystem while avoiding radioactive spheres and racing against time.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [Controls](#controls)
- [Project Structure](#project-structure)
- [Assets and Credits](#assets-and-credits)
- [Development](#development)
- [Author](#author)
- [License](#license)

## Overview

Terraformer is a 3D action game where players control a sphere navigating through a hazardous post-nuclear landscape. The objective is to collect 21 sand blocks scattered throughout the environment to restore ecological balance. Players must avoid enemy AI-controlled radioactive spheres that pursue them within a detection radius, all while managing a countdown timer.

The game demonstrates fundamental game development concepts including:
- Physics-based movement and collision detection
- AI enemy behavior with detection and pursuit mechanics
- Dynamic UI elements and game state management
- Input system integration for keyboard and gamepad support
- Audio implementation for immersive gameplay

## Features

- **Physics-Based Gameplay**: Realistic movement mechanics using Unity's Rigidbody system
- **AI Enemy System**: Intelligent enemies that detect and chase the player within a defined radius
- **Time Challenge**: Complete objectives within a 60-second time limit
- **Dual Input Support**: Full support for both keyboard/mouse and gamepad controls
- **Jump Mechanics**: Ground-detection based jumping system
- **Respawn System**: Automatic player respawn when falling off the map
- **Score Tracking**: Real-time collection counter and timer display
- **Menu System**: Professional main menu and in-game UI
- **Audio Feedback**: Immersive sound effects for pickups and respawns
- **Cross-Platform**: Available as Windows executable and WebGL build

## Technologies

This project was built using the following technologies:

- **Game Engine**: Unity 2022.3.44f1 LTS
- **Programming Language**: C#
- **Render Pipeline**: Universal Render Pipeline (URP)
- **Input System**: Unity's New Input System
- **UI Framework**: TextMeshPro
- **Physics Engine**: Unity Physics (Rigidbody)
- **Build Targets**: Windows Standalone, WebGL

## Installation

### Prerequisites

- Unity 2022.3.44f1 or compatible version
- Windows 10/11 (for standalone builds)
- Modern web browser with WebGL support (for WebGL builds)

### Running the Game

**Option 1: Play Pre-built Version**
1. Navigate to the `Builds` directory
2. For Windows: Run `roll_a_ball_pedrotpc.exe`
3. For WebGL: Open `index.html` in a web browser

**Option 2: Open in Unity Editor**
1. Clone this repository:
   ```bash
   git clone https://github.com/pedrocivita/jogosDigitais_pedrotpc_roll-a-ball.git
   ```
2. Open Unity Hub
3. Click "Add" and select the cloned project directory
4. Open the project with Unity 2022.3.44f1 or compatible version
5. Navigate to `Assets/Scenes/Menu.unity`
6. Press the Play button to start

## How to Play

1. **Objective**: Collect all 21 sand blocks before time runs out
2. **Obstacles**: Avoid radioactive enemy spheres that will chase you when you get close
3. **Time Limit**: Complete the mission within 60 seconds
4. **Falling**: If you fall off the map, you'll respawn at the starting point
5. **Victory**: Collect all blocks before time expires to win
6. **Defeat**: Fail to collect all blocks within the time limit and you lose

## Controls

### Keyboard Controls
| Action | Key |
|--------|-----|
| Move Forward | W or Up Arrow |
| Move Backward | S or Down Arrow |
| Move Left | A or Left Arrow |
| Move Right | D or Right Arrow |
| Jump | Space Bar |
| Restart Game | R |
| Return to Menu | M |

### Gamepad Controls
| Action | Button |
|--------|--------|
| Move | Left Analog Stick |
| Jump | A Button |
| Restart Game | Y Button |
| Return to Menu | Start Button |

## Project Structure

```
jogosDigitais_pedrotpc_roll-a-ball/
├── Assets/
│   ├── Scripts/
│   │   ├── PlayerController.cs      # Player movement and game logic
│   │   ├── CameraController.cs      # Camera follow system
│   │   ├── EnemyAI.cs              # Enemy detection and pursuit
│   │   ├── EnemyMovement.cs        # Enemy movement logic
│   │   ├── MainMenu.cs             # Menu system
│   │   └── Rotator.cs              # Collectible rotation animation
│   ├── Scenes/
│   │   ├── Menu.unity              # Main menu scene
│   │   └── Minigame.unity          # Main game scene
│   ├── Materials/                   # Visual materials
│   ├── Prefabs/                     # Reusable game objects
│   └── [Asset Packs]/              # Third-party assets
├── Builds/                          # Compiled game builds
├── ProjectSettings/                 # Unity project configuration
└── README.md
```

## Assets and Credits

### Music
- **Title**: *Exploring the Land – Loopable*
- **Composer**: Alison Turk
- **Source**: *Fantasy Music Suite*
- **License**: Royalty-free for video games
- **Website**: [alisonturk.com](https://alisonturk.com)

### Sound Effects
- **Title**: *Collectathon Sound Pack*
- **License**: Royalty-free
- **Format**: WAV, 24-bit, 96kHz
- **Description**: Sound effects inspired by classic collect-a-thon games like Spyro the Dragon and Banjo-Kazooie

### Skybox
- **Title**: *Cosmic HDR Sky Series*
- **License**: Free HDR sky textures
- **Description**: Collection of 16 free HDRIs with themes including Daylight, Sundown, Midnight, and Cosmic
- **Compatibility**: Built-in, URP, and HDRP pipelines

### Textures
- **Title**: *25+ Free Stylized Textures*
- **Source**: Game Buffs *2500+ Stylized Textures Megapack*
- **Resolution**: 2048x2048
- **Format**: PNG
- **Maps Included**: Albedo, Ambient Occlusion, Height, Normal, Metallic, Roughness, HDRP Mask
- **Tools**: AI-generated and processed with Photoshop

### Tutorials
This project was developed following and adapting official Unity tutorials:
- Unity's Official Roll-A-Ball Tutorial
- [START MENU in Unity](https://www.youtube.com/watch?v=zc8ac_qUXQY3)

The base mechanics were extended with custom enemy AI, time-based challenges, and enhanced visual/audio elements.

## Development

### Building from Source

1. Open the project in Unity 2022.3.44f1
2. Go to File > Build Settings
3. Select your target platform (Windows or WebGL)
4. Click "Build" and choose output directory

### Key Scripts Overview

- **PlayerController.cs**: Handles player input, movement physics, collision detection, and game state
- **EnemyAI.cs**: Implements enemy detection radius and chase behavior
- **CameraController.cs**: Manages camera positioning to follow the player
- **MainMenu.cs**: Controls menu navigation and scene loading

## Author

**Pedro Civita**

Computer Engineering Student at Insper

- Email: pedrotpc@al.insper.edu.br
- LinkedIn: [linkedin.com/in/pedrocivita](https://linkedin.com/in/pedrocivita)
- GitHub: [@pedrocivita](https://github.com/pedrocivita)

## License

This project is developed for educational purposes as part of the Computer Engineering curriculum at Insper. All third-party assets are used under their respective licenses as documented in the [Assets and Credits](#assets-and-credits) section.

---

**Insper - Computer Engineering Program**  
Digital Games Course Project - 2024
