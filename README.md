*sreenshots below* <br>
This is a simple vector field visualization tool made in Unity. I created it in April 2021, during the pandemic lockdown, but I recently found out about it while cleaning some files from the computer and I thought of uploading it here. <br>
I remember being inspired to create this programme from a [3 blue 1 brown video on exponentiating matricies](https://youtu.be/O85OWBJ2ayo). After creating the visualization and simulation part of the application, I also wanted to be able to control the field equations from inside the programme. So, I took challenage to create an expression parser all by myself. This had some success: The expression parser **mostly** works. There are some bugs that I remember not being able to fixed - the code started resembling some italian pasta which I wasn't particularly keen on bothering with. But it does work well enough to be somwhat functional. I remember feeling quite happy with the result.

The main functionality comes down to the following:
- The 'x' and 'y' variables refere to the x and y coordinates of each point in the field. The equations corrispond to the x- and y-coordinates of the field value at that point.
- You can write down the field equations and hit "reload equations". If the equation parser succeeds in parsing the two expressions, then you will see the small arrows changing according to the field equations you inserted.
- You can create custom variables using the "create new variable" button. You can give it any name you like - you just need to use that exact name in the equations.
- The "colour strength" slider changes the colour strength of the arrows: the reder the arrow the greater its magnetude, the bluer the colour, the smaller the magnetude.
- If you hit "start simulation" the small particle will start to move according to the field equations. There are two simulation modes controlled by the "sim mode" setting: velocity mode and acceleration mode. In the first the particle's velocity is the value of the vector field at it's current location, in the second one the value of the vector field becomes it's acceleration.
- You can also change the speed of the simulation through the "sim speed" slider. Note the the simulation is using a simple eucleadian integrator, which makes it quite inaccurate. You can control the time step through the "sim accuracy" slider.
- If you click and drag the particle, you can move it around.

The equation parser supports the following build in functions:
- *Logarithmic*: ln(), log(), log10()
- *Trigonometric*: sin(), cos(), tan()
- *Inverse Trigonometric*: asin(), acos(), atan(), arcsin(), arccos(), arctan()
- *Exponetial*: exp()
- *Utility functions*: sign(), floor(), ceil(), round()

### Some screenshots:
<img width="1774" height="996" alt="image" src="https://github.com/user-attachments/assets/dcd81d09-cc53-4935-b1a7-5387f8e0c9a7" />
<img width="1780" height="1001" alt="image" src="https://github.com/user-attachments/assets/e816ff32-7219-4437-a8a9-d85f92ba9eee" />
