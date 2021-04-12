# MineRoverKata

## Kata description

### Requirements
A fleet of hand built robots are due to engage in battle for the annual “Robot Wars” competition. Each
robot will be placed within a rectangular battle arena and will navigate their way around the arena
using a built in computer system.<br>
A robot’s location and heading is represented by a combination of x and y co-ordinates and a letter
representing one of the four cardinal compass points. The arena is divided up into a grid to simplify
navigation. An example position might be 0, 0, N which means the robot is in the bottom left corner
and facing North.<br>
In order to control a robot, the competition organisers have provided a console for sending a simple
string of letters to the on-board navigation system. The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’
make the robot spin 90 degrees to the left or right respectively without moving from its current spot
while ‘M’ means move forward one grid point and maintain the same heading. Assume that the
square directly North from (x, y) is (x, y+1).

### Input
The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are
assumed to be (0, 0). <br>
The rest of the input is information pertaining to the robots that have been deployed. Each robot has
two lines of input - the first gives the robot’s position and the second is a series of instructions telling
the robot how to move within the arena.<br>
The position is made up of two integers and a letter separated by spaces, corresponding to the x and
y coordinates and the robot’s orientation. Each robot will finish moving sequentially, which means that
the second robot won’t start to move until the first one has finished moving.

### Output
The output for each robot should be its final coordinates and heading.

### Acceptance criteria
In order to confirm your program is working correctly, we have provided some test input and output for
your use. Implement these details however you consider most appropriate.

### Test input:
5 5<br>
1 2 N<br>
LMLMLMLMM<br>
3 3 E<br>
MMRMMRMRRM

### Expected output:
1 3 N <br>
5 1 E <br>

## Important notes
In the description there is no explicit information what should happen when invalid data is provided by the user
or when robot gets out of the arena. In those cases my program can behave unexpectedly, but most cases are covered with exceptions.<br>
There is also no information what happens when one robot drives through a field on which another one is standing. Those cases
are ignored - program proceeds as if nothing happened.

## How to run and build the project
To run the project you need Visual Studio 2019 with .NET Core 3.1 Framework installed.
Then you can open the solution file (MineRoverKata.sln), open <i>Build</i> and choose <i>Build Solution</i> option.
Make sure MineRoverKata project is marked as Startup project.
After that you can run it by hitting F5 or open <i>Debug</i> and choose <i>Start Debugging</i>.

## How to run tests
To run tests you need xUnit and Moq installed with your Visual Studio. With that installed you need to open
MineRoverKata.sln solution file, open <i>Test</i> and choose <i>Run All Tests</i>.
