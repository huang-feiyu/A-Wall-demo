# A-Wall-demo
[toc]

## Requirements

Prototype: [Figma](https://www.figma.com/file/GHDlVUXCCPqTFhS1Gh3XL2/demo?type=design&node-id=0%3A1&mode=design&t=Zj3Btugz5ezKObkT-1)

* **UI Scene** (2D): For user’s input
  * Input with ***m* * *n*** pin-arrays (4 * 4), generate grids
  * Each of the grid has its own 4 * 4 pins that hold **their own *height*s**
  * User can **choose** any of the pins and **scroll** the button below to **change** their *height*s
  * Once the pins are selected, their *height*s **change immediately** to the height from scroll bar
* **Render Scene** (3D): For **real-time** rendering of pin-arrays
  * The right-bottom sphere is for **changing the angle of view**

## Plan

* [ ] UI Scene - Grids generating
* [ ] UI Scene - Pins’ internal heights & Scroll bar display and change
* [ ] UI Scene - Generating JSON string
* [ ] Render scene - Pin-array display
* [ ] Render scene - Coordinate system
* [ ] API - Connect with hardware
