# Unity-Template-QuestXRHandsURP

A quickstart Unity 2022 project for Oculus Quest uging XR Interaction toolkit and hands detection, with Universal render pipeline (URP)

## Getting started

### Create your project

* From the [Unity-Template-QuestXRHandsURP](https://github.com/prossel/Unity-Template-QuestXRHandsURP) GitHub repository click the *Use this template* button, then *Create a new repository* to create your own project
* Configure your project
* Clone your project locally (best) or download it as zip (but you will loose the link to your GitHub repository)

### Add the project to Unity Hub

* In Unity Hub, add project from disk
* Open it in Unity

### Import the samples

* From Unity > Window > Package Manager
* Packages: In Project
* Select XR Hands, samples and import:
  * HandVisualizer
* Select XR Interaction Toolkit, samples and import:
  * Starter Assets
  * Hands Interaction Demo

## Run the demo

### DemoBomb

* Open the scene `Assets/Demo/Scenes/DemoBomb.unity`
* Play

### DemoSceneHands

`Assets/Demo/Scenes/DemoBomb.unity`

This scene is a copy of Assets/Samples/XR Interaction Toolkit/2.5.4/Starter Assets/DemoScene.unity with a few modifications for Hands:

* Replaced *XR Interaction Setup* prefab with *XR Interaction **Hands** Setup* prefab
* Enabled teleportation with hands' ray interactor
  * added Teleport to Interaction layer mask

### BareHands

`Assets/Demo/Scenes/BareHands.unity`

This scene only has hands with no interactors to start from scratch.

## Make it yours

* Edit > Project Settings > Player
* Change the product name
* Select Android tab
* Go down to *Package name* and edit according to the template
  com.HEADGeneve.YOUR_DEPARTMENT_YEAR.YOUR_NAME.PRODUCT_NAME

## Build and run on Oculus Quest

* Connect the headset
* File > Build Settings
* Select Android, Switch Platform
* Build and run
* See Console for any errors
* Put the helmet and enjoy
