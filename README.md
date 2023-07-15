# A-Wall-demo
[toc]

## Requirements

Prototype: [Figma](https://www.figma.com/file/GHDlVUXCCPqTFhS1Gh3XL2/demo?type=design&node-id=0%3A1&mode=design&t=Zj3Btugz5ezKObkT-1)

* **UI Scene** (2D): For user’s input
  * Input with ***m* * *n*** pin-arrays (4 * 4), generate grids
  * Each of the grid has its own 4 * 4 pins that hold **their own *height*s**
  * User can **choose** any of the pins and **scroll** the button below to **change** their *height*s
    Once the pins are selected, their *height*s **change immediately** to the height from scroll bar
  * The **reset button** is for setting all the *height*s to 0
* **Render Scene** (3D): For **real-time** rendering of pin-arrays
  * The right-bottom sphere is for **changing the angle of view**

## Plan

* [x] UI Scene - Pins generating
* [ ] UI Scene - Pins’ internal heights & Scroll bar display and change
* [ ] UI Scene - Reset button & Generating JSON string
* [ ] Render scene - Pin-array display
* [ ] Render scene - Coordinate system
* [ ] API - Connect with hardware

## Current

![Pins generating](https://github.com/huang-feiyu/A-Wall-demo/assets/70138429/0c680878-96fa-4f52-a630-2ab3e0982e8d)
