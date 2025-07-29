# Campus Safety Training (AR mobile application)
This is a one-month project with the goal of building a mobile AR application that will guide users throughout the
C-building of the GUC campus in case of an emergency - in this case a fire.

- Used software:
  - Unity Game Engine: provided ready to use AR functionality as well as a prebuilt library for AI pathfinding and navigation
  - Blender: used for modelling the building floors.

## Features
- The user can pick from a set of predefined locations where they can start at, including choosing the floor level they're willing to start from.
- Gamification: the project implements a game-like health bar and a timer to encourage replayability and competitiveness for getting the fastest escape route, which stresses on the importance of time in case of an emergency.
- Win and loss conditions: reaching one of the building exists will trigger the win screen and give the chance to replay from a different location. Touching a fire twice would trigger the loss screen where the user can retry the training.

## Devices
- This app was built for android, specifically tested on a MI Note 10 Lite. The tested device lacks features such as depth
detection.

## Problems Faced
The device tracking relies on SLAM (Simultaneous Localization and Mapping), which uses distinct features and high contrast
objects captured by the device's camera to correctly track the user. Unfortunately this technology introduces slight error,
and this error accumulates over long distances into a noticeable drag. The ability to recalibrate your position constantly
using QR codes embedded throughout the building would be a possible solution to get rid of this error, however this was
not possible in the time constraint given to this project.
