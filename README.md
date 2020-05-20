
# General Description
This project implemented an active wrist rehabilitation system focused on treating wrist injuries such as: bone fractures, Quervain tendonitis, median, ulnar or radial nerve neuralgia and carpal tunnel problems through the movement of a haptic device. The patient through interactive interfaces receives a visual, acoustic and force feedback generated by the actuators of the device. **(For this project you will need a Novint Falcon Device).**


# Rehabilitation-Wrist-Program
## Objetives:

- Design the user interface in Unity 3D software that contains the different screens of the motor exercises with their different levels of difficulty based on virtual objects.
- Create a local database in SQL language.
- Implement the rehabilitation system consisting of: the Novint Falcon device, the user interface, a support for forearm lock and a fine pressure axis for the haptic device.

## Implemented system

<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/system.PNG" height="350">
</p>  

## Virtual World VS Haptic World

For this project it is important to understand the difference between the haptic world and the virtual world.
- In the virtual world there are all the 3d objects visible or not in the scene.
- In the haptic world there are only the meshes of those 3D objects that will be perceptible for the haptic device.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/hapticworld.PNG" height="350">
</p>  

## Meshes

For this project we also worked with different types of appropriate meshes to have a better computational performance.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/mallas.PNG" height="350">
</p>  

## User Interfaz-Exercises
###### Mazes
Shows different mazes through which the patient will have to move without colliding against the walls in order to collect one or two coins in the shortest time.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/lab1.JPG" height="350">
</p>  

###### Drills
This motor exercise will show different walls with marks to be drilled by the patient.
The user must drill different holes on a wall with pre-set targets, the patient must drill all holes in the shortest possible time and with the least amount of impact outside the targets. In this exercise there is also a slider that allows you to configure the weight of the drill, so the patient's effort must be constant, unlike the previous exercise.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/tal1.JPG" height="350">
</p>  

###### Puzzle
This motor exercise will show different puzzles that must be correctly assembled by the patients.
In this exercise, the game interface has a slider to control the weight level of the pieces, two areas of information on patient performance.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/rom1.PNG" height="350">
</p>  

###### Doctor's Office
This exercise will show different scenarios in which the patient must place different virtual objects in the indicated place. The user must place the largest number of pieces in the correct place, in a set time. This exercise differs from the previous ones because the user, when picking up a piece, receives a force feedback on each of its edges.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/lab1.PNG" height="350">
</p>  

## User Interfaz-Menu
###### LOGIN
In this scene, the patient enters their ID to start each therapy, if the entered ID is registered or different options are not displayed. In addition, from this scene the elimination of a patient is handled and a SEE PATIENTS button that opens the consultation scene.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/login.PNG" height="350">
</p>  

###### MAIN MENU
This scene opens when the patient has started the therapy session, here are buttons to access each of the motor games. In addition, there is a PREVIOUS SESSIONS button that opens the consultation scene and an END SESSION button that allows ending therapy.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/menu.PNG" height="350">
</p>  

###### Data base screen 
In this scene, the information corresponding to his personal data is displayed at the top and, at the bottom, all the sessions that the patient has had are displayed, along with information on the performance of each exercise.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/database.PNG" height="350">
</p>  

## Results
In order to show a graph that allows us to see an advance between the initial and final situation of the patients, an analysis of time and errors was carried out. Next, an image is presented with the most notable results obtained.
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/res1.PNG" height="350">
</p>  
<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/res2.PNG" height="350">
</p>  

<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/res3.PNG" height="350">
</p>  

<p align="center">
<img src="https://github.com/cristhian1995cobos/Rehabilitation-Wrist/blob/master/Captures/res4.PNG" height="350">
</p>  

