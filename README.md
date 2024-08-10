# Jetpacks

## Description
**Jetpacks** is a Virtual Reality (VR) game that explores the dynamics of using a jetpack in a VR environment. The game allows players to fly around buildings and dodge flying obstacles while collecting loot and managing fuel levels. The game includes features such as fall damage, sound effects, a fuel gauge, and health management.

Please note that this repository only contains the C# script files. The Unity project files are not included.

## Features
- **Flying Mechanics**: Control your jetpack to fly and hover around the environment.
- **Fall Damage**: Receive damage based on the height from which you fall, with damage increasing with altitude.
- **Fuel Management**: Monitor your fuel levels with a fuel gauge and refuel by collecting fuel pickups.
- **Health System**: Manage your health through fall damage and health pickups.
- **Collectibles**: Pick up coins and other prizes while avoiding obstacles.
- **Sound Effects**: Immersive audio effects for jetpack usage, collisions, and item pickups.
- **Oculus Support**: Optimized for Oculus devices with VR-specific controls.

## Installation
To set up this project locally, follow these steps:

1. **Clone the Repository:**

   git clone https://github.com/your-username/Jetpacks.git

   cd Jetpacks


2. **Open in Unity:**

    Since this repository only contains the C# scripts, you will need to integrate these scripts into your own Unity project. Open your Unity project, and then copy the C# files into your project's Assets/Scripts directory.

3. **Add Assets:**

    Ensure you have the necessary 3D models, audio clips, and other assets in your Unity project to fully utilize the provided scripts.

4. **Configure the Scene:**

    Set up the scene with the necessary game objects (e.g., player, environment, collectibles) and assign the scripts to the appropriate game objects in the Unity Editor.

## Usage ##

Once the scripts are integrated into your Unity project and the scene is set up, you can play the game in the Unity Editor or build it for your VR platform. The game allows players to:

- Fly and hover using the jetpack.
- Avoid obstacles and fall damage.
- Collect fuel, health packs, and prizes.
- Monitor health and fuel levels through on-screen displays.


## Code Overview ##

Example Functions

Here are a couple of functions from the game that highlight key mechanics:

- newJetpack(): Controls the jetpack's flight mechanics, including fuel management, fall speed, and audio effects.
- OnTriggerEnter(Collider collision): Handles interactions with various in-game objects, such as fuel pickups, health packs, and prizes. It also manages fall damage when colliding with the ground.

These functions are crucial for managing the player's interactions and the physics of the jetpack in the game.


## License ##
This project is licensed under the MIT License. See the LICENSE file for more information.
