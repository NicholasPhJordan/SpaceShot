| Nicholas Jordan|
| :---          	|
| s208047     	|
| MathForGames |
| Space Shot Documentation |

## I. Requirements
**1. Completed Redistributable Maths Classes**

    - Submitted redistributable static library that implements:
       -Vector classes for 3D vectors, including homogeneous 3D vectors
            -Classes implement methods for, in all instances, translation, scale, magnitude, normalisation, cross product and dot product
       -Matrix classes for 3D matrices, including homogeneous 4D matrices
            -Classes implement methods for multiplication, vectors transformation, and transpose
            -Classes implement methods for setting up as rotation matrices
       -As part of the Colour class, functions for manipulating a bitfield implemented using bit shift operations
    - Code suitably commented to an industry standard as specified by your teacher

**2. Unit Test Results**

    - Math classes successfully pass the Unit Test provided by instructor

**3. Test Application**

    - Submitted executable for Graphical Test Application That makes use of your maths classes to implement the following
        -Example of matrix hierarchy to manipulate visible element
        -Example of game objects moving using velocity and acceleration with vectors
        -Example of simple collision detection

**4. Peer Review Session**

    -participation in peer review sessions
    -Documented outcomes of peer review sessions

**5. Number Coversion Exercises**

    -Completed Number Conversion Exercises

**6. Application Handover**

    -A visual Studio solution and project that compiles withour errors
        -All temporary and built executable files in the obj and bin folder have been removed
    -A "readme" or client document explaining how yo compile, run and operate the program
    -All submitted material archived in a single compressed file

## II. Design

![image](SpaceShot.png)
The game consist of the main spaceship that is the player and then two little space ships on either side. 
Then enemies randomly spawn and come towards the player from the other side.

Since the point of the project is to show Parent/ Child relations, I have the two baby ships acting as children to the player ship.

![image](YouDied.png)
Another required field for the assesment was collision detection, 
which can be seen when the enemy ships collide with the children or the player. 
Collision of with the player causes game over and you died to appear on the screen.

### Object Information

**File**: Game.cs

**Attributes**

        Name: _gameOver 
            Description: Initializes gameover variable and sets it to flase
            Type: bool

        Name: _scenes
            Description: Creates an array for scenes to be created and added to
            Type: Array

        Name: _currentSceneIndex
            Description: Initializes varible used to get the current scene from the scenes array
            Type: int

        Name: SetGameOver(bool value)
            Description: Public function that can be called at anytime to set _gameOver to the input value
            Type: void

        Name: DrawLooseText()
            Description: Function that when called will RayLib draw text saying "you died" and "press esc to quit"
            Type: void

        Name: CurrentSceneIndex
            Description: calles _currentSceneIndex to returns the current scene index from the scenes array
            Type: int 

        Name: GetScene(int index)
            Description: Returns the scene at the index given and an empty scene if the index is out of bounds
            Type: scene

        Name: GetCurrentScene()
            Description: Returns the currents scene index when called
            Type: scene

        Name: AddScene(Scene scene)
            Description: Adds the given scene to the array of scenes
            Type: int

        Name: RemoveScene(Scene scene)
            Description: Finds the instance of the scene given that is inside of the the array and removes it
            Type: bool

        Name: SetCurrentScene
            Description: Sets the current scene in the game to be the scene at the given index
            Type: void

        Name: GetKeyDown(int Key)
            Description: Returns true while a key is being pressed
            Type: bool

        Name: GetKeyPressed(int key)
            Description: Returns true if the key was pressed once
            Type: bool

        Name: Game()
            Description: initializes game array
            Type: void

        Name: rnd
            Description: function that allows me to make ints with a random number range
            Type: Random

        Name: Start()
            Description: Called when the game begins. Used for initialization. 
            Type: void

        Name: Update(flaot deltaTime)
            Description: Called every frame at the rate of deltaTime
            Type: void

        Name: Draw()
            Description: Used to display objects and other info on the screen
            Type: void

        Name: End()
            Description: Called when the game ends
            Type: void

        Name: Run()
            Description: Handles all of the main game logic including the main game loop
            Type: void

**File**: Scene.cs

**Attributes**

        Name: _actors
            Description: initalizes the an Actor array
            Type: array

        Name: _transform_
            Description: creates a new matrix3
            Type: Matrix3

        Name: World
            Description: returns the _transform matrix
            Type: Matrix3

        Name: Started
            Description: Gets and sets to value Started
            Type: bool

        Name: Scene()
            Description: actually creates actor array
            Type: void

        Name: AddActor(Actor actor)
            Description: adds the given actor to the actor array
            Type: void

        Name: RemoveActor(int index)
            Description: Removes the actor at the given index
            Type: bool

        Name: RemoveActor(Actor actor)
            Description: removes the given actor
            Type: bool

        Name: Start()
            Description: Called when scene begins and used to initalize variables 
            Type: void

        Name: Update(float deltaTime)
            Description: called every frame at the rate of deltaTime
            Type: void

        Name: Draw()
            Description: used to display objects of scene to the screen
            Type: void

        Name: End()
            Description: called when scene ends
            Type: void

**File**: Actor.cs

**Attributes**

        Name: _velocity
            Description: creates a new vector2 for velocity 
            Type: Vector2

        Name: _acceleration
            Description: creates a new vector2 for acceleration
            Type: Vector2

        Name: _globalTransform
            Description: creates new matrix3 for the global transform
            Type: matrix3

        Name: _localTransform
            Description: creates a new matrix3 for local transform
            Type: matrix3

        Name: _translation
            Description: creates a new matrix3 for translations
            Type: matrix3

        Name: _rotation
            Description: creates new matrix3 for rotations
            Type: Matrix3

        Name: _scale_
            Description: creates matrix3 for scaling
            Type: matrix3

        Name: _parent
            Description: initializes a varible for parents
            Type: Actor

        Name: _children_
            Description: initializes an array for children
            Type: Actor

        Name: _collisionRadius
            Description: initializes a varible for the collision radius
            Type: float

        Name: _maxSpeed
            Description: initalizes a maxspeed 
            Type: float

        Name: Started
            Description: get and sets value to started
            Type: bool

        Name: WorldPosition
            Description: get _globalTransform.m13 and .m23
            Type: Vector2

        Name: LocalPosition
            Description: Get _localTransform.m13 and .m23 and set _translation for value X and y
            Type: Vector2

        Name: Velocity
            Description: get and sets value to _velocity
            Type: Vector2

        Name: Acceleration
            Description: Get and Sets value to _acceleration
            Type: Vector2

        Name: MaxSpeed
            Description: Get and Set value to _maxSpeed
            Type: float

        Name: Actor
            Description: constructs and actor with parameters of x and y coordinates 
            Type: constructor

        Name: AddChild(Actor child)
            Description: Adds the input actor to child array
            Type: void

        Name: RemoveChild(Actor child)
            Description: Removes the given actor from the child array
            Type: bool

        Name: SetTranslation(Vector2 position)
            Description: goes through the matrix3 and sets translation
            Type: void

        Name: SetRotation(float radians)
            Description: goes through matrix3 array and sets input for rotation values
            Type: void

        Name: Rotate(float radians)
            Description: takes given value and sets the related variables in matrix3 array 
            Type: void

        Name: SetScale(float x, float y)
            Description: changes the scale of the actor sprite based off the given input
            Type: void

        Name: CheckCollision(Actor other)
            Description: Checks to see if this actor overlaps another
            Type: bool

        Name: OnCollision(Actor other)
            Description: called whenever a collision occurs between this actor and another 
            Type: void

        Name: UpdateTransform()
            Description: takes all the transformation values and updates when called
            Type: void

        Name: Start()
            Description: Called when Actor begins and initalizes variables
            Type: void

        Name: Update(float deltaTime)
            Description: called every frame at the rate of deltaTime
            Type: void

        Name: Draw()
            Description: used to display Actor related objects to the screen
            Type: void

        Name: End()
            Description: Called at the end of Actor
            Type: void

**File**: Player.cs

**Attributes**

        Name: _speed
            Description: initializes variable of players speed. determines how fast they move
            Type: float

        Name: _canMove
            Description: varible that returns if the player can move or not
            Type: bool

        Name: Speed
            Description: Gets and Sets the speed value for the player
            Type: float

        Name: Player(float x, float y)
            Description: Construct the player and initalizes location based off of given input
            Type: Constructor

        Name: DisableControls()
            Description: Changes _canMove for the player to flase
            Type: void

        Name: Update(float deltaTime)
            Description: Called every frame at the frame rate of deltaTime
            Type: void

        Name: Draw()
            Description: used to update Actor update to display player related objects
            Type: void

**File**: Baby.cs

**Attributes**

        Name: Baby
            Description: constructs a Baby actor
            Type: Constructor

        Name: Update(float dletaTime)
            Description: update everyframe at the rate of deltaTime
            Type: void

**File**: Enemy.cs

**Attributes**

        Name: Enemy
            Description: constructs an Enemy actor
            Type: Constructor

        Name: Update(float dletaTime)
            Description: update everyframe at the rate of deltaTime
            Type: void

## MathLibrary

**File**: Matrix4.cs

**Attributes**

        Name: m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44
            Description: initalizes all the variables for the Matrix4 
            Type: float

        Name: Matrix4()
            Description: makes a matrix4 and initalizes every variable with a value
            Type: Constructor

        Name: Matrix4(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44)
            Description: builds a matrix and makes every varible equal to the relavent given varible
            Type: Constructor

        Name: +(Matrix4 lhs, Matrix4 rhs)
            Description: allows addition of every value in Matrix4 
            Type: operator

        Name: -(Matrix4 lhs, Matrix4 rhs)
            Description: allows subtraction of every varible in matirx4
            Type: operator

        Name: *(Matrix4 lhs, Matrix4 rhs)
            Description: allows for multiplecation along the entirty of matrix4
            Type: operator

        Name: CreateRotationX(float radians)
            Description: Creates new matrix that hs been rotated by given radians across the X axis
            Type: Matrix4

        Name: CreateRotationY(float radians)
            Description: Creates new matrix that hs been rotated by given radians across the Yaxis
            Type: Matrix4

        Name: CreateRotationZ(float radians)
            Description: Creates new matrix that hs been rotated by given radians across the Z axis
            Type: Matrix4

        Name: CreateTranslation(vector3 position)
            Description: creates new matrix that is translated by given values
            Type: Matrix4

        Name: CreateScale(Vector3 scale)
            Description: creates a new matrix that had been scaled by the given value
            Type: Matrix4

        Name: *(Matrix4 lhs, Matrix4 rhs)
            Description: inverse of the multiplacation operator
            Type: Operator

**File**: Matrix3.cs

**Attributes**

        Name: m11, m12, m13, m21, m22, m23, m31, m32, m33
            Description: initalizes the varibles for matrix3
            Type: float

        Name: Matrix3()
            Description: constructs a matrix 
            Type: constructor

        Name: Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
            Description: Makes the egiven input equal to the matrix varibles
            Type: constructor overflow

        Name: +(Matrix3 lhs, Matrix3 rhs)
            Description: allows addition in for matirx3
            Type: operator

        Name: -(Matrix3 lhs, Matrix3 rhs)
            Description: allows subtraction along the matrix3
            Type: operator

        Name: CreateRotation(float radians)
            Description: creates new matrix that has been rotated by the given radians
            Type: Matrix3

        Name: CreateTranslation(Vector2 position)
            Description: creates new matrix that is translated by given value
            Type: Matrix3

        Name: CreatScale(Vector2 scale)
            Description: creates new matrix that has been scaled by gicen value
            Type: Matrix3

        Name: *(Matrix3 lhs, Matrix3 rhs)
            Description: inverse operations of the matrix3 operator
            Type: operator

**File**: Vector4.cs

**Attributes**

        Name: _x
            Description: initalizes varible for x axis
            Type: float

        Name: _y
            Description: initalizes varible for y axis
            Type: float

        Name: _z
            Description: initalizes varible for z axis
            Type: float

        Name: _w
            Description: initalizes varible for w axis
            Type: float

        Name: X
            Description: Get and Set x value
            Type: flaot

        Name: Y
            Description: Get and Set Y value
            Type: float

        Name: Z
            Description: Get and Set Z value
            Type: float

        Name: W
            Description: Get and Set W  value
            Type: float

        Name: Vector4()
            Description: creates a vector 4
            Type: Constructor

        Name: Vector4(float x, flaoty, float z, float w)
            Description: makes the variables equal to the relative input
            Type: Constructor overload

        Name: Magnitude
            Description: gets the magnitude of all the varibles
            Type: float

        Name: Normalized
            Description: will make called on value equal to one or normalized 
            Type: Vector4

        Name: Normalized(Vector4 vector)
            Description: returns normalized verions of the vecotrs passed in
            Type: Vector4

        Name: DotProduct(Vector4 lhs, Vector4 rhs)
            Description: returns dotproduct of the given vectors
            Type: float

        Name: +(Vector4 lhs, Vector4 rhs)
            Description: allows addition of vector values
            Type: operator

        Name: -(Vector4 lhs, Vector4 rhs)
            Description: allows subtraction of vector values
            Type: Operator 

        Name: *(Vector4 lhs, float scalar)
            Description: allows multiplication of vector values
            Type: operator

        Name: *(float scalar , Vecotr4 rhs)
            Description: inverse of the mulitplication operator
            Type: operator

        Name: /(Vector4 lhs, float scalar)
            Description: allows division of vector values
            Type: operator

        Name: CrossProduct(Vector4 lhs, Vector4 rhs)
            Description: cross multiplies the values in the vector
            Type: operator

**File**: Vector3.cs

**Attributes**

        Name: _x
            Description: initalizes varible for x axis
            Type: float

        Name: _y
            Description: initalizes varible for y axis
            Type: float

        Name: _z
            Description: initalizes varible for z axis
            Type: float

        Name: X
            Description: Get and Set x value
            Type: flaot

        Name: Y
            Description: Get and Set Y value
            Type: float

        Name: Z
            Description: Get and Set Z value
            Type: float

        Name: Vector3()
            Description: creates a vector 3
            Type: Constructor

        Name: Vector3(float x, flaoty, float z)
            Description: makes the variables equal to the relative input
            Type: Constructor overload

        Name: Magnitude
            Description: gets the magnitude of all the varibles
            Type: float

        Name: Normalized
            Description: will make called on value equal to one or normalized 
            Type: Vector4

        Name: Normalized(Vector3 vector)
            Description: returns normalized verions of the vecotrs passed in
            Type: Vector3

        Name: DotProduct(Vector3 lhs, Vector3 rhs)
            Description: returns dotproduct of the given vectors
            Type: float

        Name: +(Vector3 lhs, Vector3 rhs)
            Description: allows addition of vector values
            Type: operator

        Name: -(Vector3 lhs, Vector3 rhs)
            Description: allows subtraction of vector values
            Type: Operator 

        Name: *(Vector3 lhs, float scalar)
            Description: allows multiplication of vector values
            Type: operator

        Name: *(float scalar , Vecotr3 rhs)
            Description: inverse of the mulitplication operator
            Type: operator

        Name: /(Vector3 lhs, float scalar)
            Description: allows division of vector values
            Type: operator

        Name: CrossProduct(Vector3 lhs, Vector3 rhs)
            Description: cross multiplies the values in the vector
            Type: operator

**File**: Vector2.cs

**Attributes**

        Name: _x
            Description: initalizes varible for x axis
            Type: float

        Name: _y
            Description: initalizes varible for y axis
            Type: float

        Name: X
            Description: Get and Set x value
            Type: flaot

        Name: Y
            Description: Get and Set Y value
            Type: float

        Name: Magnitude
            Description: gets the magnitude of all the varibles
            Type: float

        Name: Normalized
            Description: will make called on value equal to one or normalized 
            Type: Vector4

        Name: Vector2()
            Description: creates a vector 2
            Type: Constructor

        Name: Vector2(float x, float y)
            Description: makes the variables equal to the relative input
            Type: Constructor overload

        Name: Normalized(Vector2 vector)
            Description: returns normalized verions of the vecotrs passed in
            Type: Vector3

        Name: DotProduct(Vector2 lhs, Vector2 rhs)
            Description: returns dotproduct of the given vectors
            Type: float

        Name: +(Vector2 lhs, Vector2 rhs)
            Description: allows addition of vector values
            Type: operator

        Name: -(Vector2 lhs, Vector2 rhs)
            Description: allows subtraction of vector values
            Type: Operator 

        Name: *(Vector2 lhs, float scalar)
            Description: allows multiplication of vector values
            Type: operator

        Name: *(float scalar , Vecotr2 rhs)
            Description: inverse of the mulitplication operator
            Type: operator

        Name: /(Vector2 lhs, float scalar)
            Description: allows division of vector values
            Type: operator