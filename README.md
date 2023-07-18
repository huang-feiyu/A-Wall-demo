# A-Wall-demo

> NOTE: Because it's my first time using Unity3D, code there is in a mess.

## Requirements

Prototype: [Figma](https://www.figma.com/file/GHDlVUXCCPqTFhS1Gh3XL2/demo?type=design&node-id=0%3A1&mode=design&t=Zj3Btugz5ezKObkT-1) — In fact, I need to develop a 2D application rather than 3D application.

* **UI Scene** (2D): For user’s input
  * Input with ***m* * *n*** pin-arrays (4 * 4), generate grids
  * Each of the grid has its own 4 * 4 pins that hold **their own *height*s**
  * User can **choose** any of the pins and **scroll** the button below to **change** their *height*s
    Once the pins are selected, their *height*s **change immediately** to the height from scroll bar.
    In the meanwhile, the selection remain the same.
* **Render Scene** (3D): For **real-time** rendering of pin-arrays
  * The ~~right-bottom sphere~~ is for **changing the angle of view**
  * Using mouse dragging to change the viewpoint and scale

## Plan

* [x] UI Scene - Pins generating
* [x] UI Scene - Pins’ internal heights & Scroll bar display and change
* [x] UI Scene - Generating JSON string
* [x] Render scene - Pin-array display
* [x] Render scene - 3D representation (with rotation and zoom)
* [x] API - Connect with hardware (serial communication)

## Current

* Pin generating

![Pins generating](https://github.com/huang-feiyu/A-Wall-demo/assets/70138429/0c680878-96fa-4f52-a630-2ab3e0982e8d)

* Scroll bar with internal heights

![Scroll bar](https://github.com/huang-feiyu/A-Wall-demo/assets/70138429/eb544df0-abc4-45aa-8e9a-a9238bf56a61)

* Wall display

![Wall display](https://github.com/huang-feiyu/A-Wall-demo/assets/70138429/0e4a8f2f-4884-4d9b-b31b-ff0f24fb5e17)

* 3D representation

![3D representation](https://github.com/huang-feiyu/A-Wall-demo/assets/70138429/9afbaa18-16a0-4778-9c4c-1b61dadcba1b)

* Connect with hardware

![image](https://github.com/huang-feiyu/A-Wall-demo/assets/70138429/918d029d-f135-4ac9-be8e-f2f906bca217)
