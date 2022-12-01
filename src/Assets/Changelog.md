######  *Copyright C.2021 Jorge Meneu Moreno, Inc bitbucket.org/Jorge_Meneu_Moreno*

##  CHANGELOG
***


## Versiones


## Versiones


### [1.7.0] - 2022/02/04

### Added

#### General
* New programming structure, establishing a MVP arquitectonic pattern along with a Strategy design pattern.
* New project folder structure.
* New scene hierarchy scheme.


#### Scenes
* Implemented Demo´s in Puzzle game.

#### Scripts
* MVP and Strategy patterns applied, making code scalable, debuggable and maintanable.

#### UI
* Added new sprites for Puzzle game.


### Removed

#### Scripts
* Erased unused and rigid source code.


### [1.6.0] - 2021/11/25

### Added

#### General
* Implemented ColorBlindness Tests, in order to adapt color palette to users capabilities. 
* Implemented Puzzle game, interacting with Users bucket to retrieve image sources.

#### Scenes
* Implemented TestDaltonismo in MenuTerapeuta/Tests/Visión/
* Implemented Puzzle game.

#### Firebase
* Implemented Users visual capabilities in RTDB, obtained in TestDaltonismo and analyzed during Login.

#### Scripts
* Implemented ColorBlindnessAdapter.cs to adapt color palette to user capabilities.
* Implemented SetTexture.cs, to adapt tecxture dowbloaded from Storage Bucket, and to place it on the piece itself.
* Implemented TestDaltonismo.cs, which defines the logic that guides a basic test based in Ishiharas cards, to obtain a probability of the users vision defieicncies.
* Implemented MixPieces.cs, which moves pieces to a defaiult position when Jugar is pressed.
* Implemented SetPosition.cs, which sets piece's position whren the holder and the piece itself are near enough.

#### UI
* Implemented renewed materials to each and every object, to adapt color palette.



### Changed

#### Scripts
* Updated Drag.cs, to implement functionality based on Puzzle game.




### [1.5.0] - 2021/11/18

### Added

#### General
* General UI/UX improvements, making it more user-friendly and clearer.
* Implemented Firebase Auth, Firebase RealTimeDatabase, Firebase Storage and Firestore.
* Implemented both Terapeuta and Patient app modes, to enable full functionality for both profiles.
* Implemented FileManagement with NativeFileManager package, enabling file selection natively.

#### Scenes
* Implemented apps multi-mode, creating MenuTerapeuta scene.
* Implemented image uploading from terapeuta, creating MenuMedia scene.
* Implemented image uploading from terapeuta, creating MenuMedia scene.
* Implemented Splash image in each game.
* Implemented Pictures and Gallery in SignUp.

#### Firebase
* Implemented Firebase Auth, enabling real-time Login with email and password protection.
* Implemented Firebase Auth, enabling real-time Logout.
* Implemented Firebase Auth, enabling full SignUp interface, including fields: Name, Surnames, Role, Email, Password and Profile Picture.
* Implemented Firebase Auth, enabling sending emails for credentials recovery. 
* Implemented RealTimeDatabase writing, to keep a record of the users registered data.
* Implemented RealTimeDatabase writing, to keep record from gaming sessions, scores, and dates.
* Implemented RealTimeDatabase reading, to analyze users' role in Login.
* Implemented RealTimeDatabase reading, to obtain database Snapshot, analyzing patients in realtime, and assign them uploads.
* Implemented RealTimeDatabase writing, to keep a record of Images uploaded in users' Storage bucket.
* Implemented Storage data uploading, for both profile and game pictures.
* Implemented Storage data downloading, for both profile and game pictures.
* Implemented Storage multi-image uploading, to enable keeping multiple files for games.
* Implemented Firestore data writing, to keep a record of users Register info.
* Implemented Firestore data writing, to keep a record of users gaming sessions info.
* Implemented Firestore data reading, to analyze user data regarding Login.

#### Scripts
* Implemented AspectRatioAdapter.cs, to adapt register scene size to different aspect ratios.
* Implemented ButtonListButton.cs and ButtonListControl.cs to control elements instatiation in Scrollable menus.
* Implemented FilePicker.cs, which combines NativeFileManager package with dynamic texture aspect ratio adapter, to analyze the file chosen, and show a preview of it.
* Implemented FirebaseRegister.cs, including the logic to handle information saving in SignUp scene, to Firebase servers.
* Implemented FirebaseDB.cs, to handle users Firebase auth data, gaming logs and enabling reading from it too.
* Implemented FirestoreRegister.cs, to back up registering data in Firestore services.
* Implemented FirestoreScores.cs to save information regarding gaming sessions in Firestore services.
* Implemented FirestoreReadUserData.cs to read info from Firestore services, regarding registry.
* Implemented GameTitle.cs, performing the logic to enable Splash scene to obtain info from the Game about to be played and the level it will be played with.
* Implemented LoginManager.cs, implementing basic logic regarding Firebase auth Login.
* Implemented LogoutManager.cs, implementing basic logic regarding Firebase auth Logout.
* Implemented PanelManager.cs to handle panels used in MenuMedia scene.
* Implemented PasswordReset.cs implementing basic logic regarding Firebase sendage of emails credential resetting.
* Implemented RegisterManager.cs, implementing basic logic regarding Firebase auth signup.
* Implemented ShowHide.cs to hide and show password as desired in both Login and SignUp.
* Implemented SpriteRender.cs, to handle sprite changing in progressbars.
* Implemented StorageManager.cs, to handle full download and upload capabilities to Firebase Storage.

#### UI
* Implemented renewed sprite style in UI Elements.
* Improved UI Elements sizing, to approach a better screen usage.
* Implemented progress bars in Sumas, Restas and Telefono.
* Applied correct color pallette to certain UI Elements.



### Changed

#### Scripts
* Updated PhoneCamera.cs, to introduce the ability to take a picture, save it, preview it and resize the texture to the original aspect ratio.
* Added methods to SceneLoader, in order to retrieve information regarding last scene played from SceneHistory.

#### UI
* Implemented unified and robust UI interface, inspired by older UI versions.
* Implemented full sized pop up panels.



### Fixed

#### UI
* Fixed progressbar not showing updates, due to sprites developing a lower priority to render than images.


### Removed

#### Scripts
* Erased repetitive method for SpriteRendering in Sumas, Restas and Telefono scenes.








### [1.4.0] - 2021/10/27

### Added

#### General
* New UI implemented.
* Implemented developed project by Miguel Perez Mateo.
* Implemented new Menu screens.
* Implemented new Vasos Game.

#### Scenes
* Created Session_Mode and Session scenes at Scenes/Menu.
* Created Vasos scene at Scenes/Games.
* Integrated SignUp and Login scenes at Scenes/Menu.


#### Scripts
* Implemented VasosLogic.cs, to handle Vasos game logic.
* Implemented ClickDetection.cs, to detect wether the user has clicked on the cup or not.
* Implemented AspectRatioAdapter.cs, to analyze the current aspect ratio and adapt SignUp camera to it.
* Implemented clickButtonColorBlue.cs, to enable color changing when pressing blue buttons.

#### UI
* Implemented unified and robust UI interface, inspired by older UI versions.
* New Splash image and Icons.
* Improved framerate in SignUp and Login scenes.

### Changed

#### UI
* Improved sprites rendering quality.

#### Scripts
* Unified SceneLoader, to handle every scene.

### Fixed
* Blurry texts in SignUp and Login scenes.
* Blurry texts in Login and Login scenes.

### Removed
* Animations, to add them inside the new unified SceneLoader.cs.





### [1.3.0] - 2021/10/21

### Added

#### General
* Feedback implemented in Sumas, Restas and Teléfono.
* Dialer screen implemented in Teléfono.
* Improved Acelerometro.cs logic and Laberinto's game logic.

#### Scenes
* Implemented new asset in Telefono, now including dialer screen.


#### Animations
* Added Sprite-based Animations in main logo and game ending.



### Changed

#### Scripts
* Redesigned logic in Acelerómetro.cs, in order to provide accurate collision detection.
* Redesigned logic in Sumas.cs, Restas.cs, Telephone.cs, in order to provide feedback after choosing an answer.
* Improved Laberintos's game logic, now randomizing Y axys, without position checking, and adaptive distance depending on level and screensize.


### Fixed
* Collisions in Laberinto.

### Removed
* New Vasos game, will be added in future versions with full functionality.



### [1.2.0] - 2021/10/16

### Added

#### General
* Demos implemented in every game.
* User Input vigilance activated.
* Implemented new game Teléfono.
* Downloadable and fully functional .apk file for testing (master/).

#### Scenes
* Improved assets from various scenes.
* Improved renderizing quality. 

#### Scripts

* Implemented User_Interaction.cs & User_Interaction_Pro.cs to launch standard and interactable demos.
* Implemented Telephone.cs, basic logic for Teléfono game.

#### Sounds
* Added DTMF sounds for dial input in Teléfono game.



### Changed

#### Scripts
* Redesigned Laberinto and Figuras instantiation algorithm, including scalability attributes.



### Fixed
* Objects destruction when disabling forms in Figuras game.



### [1.1.0] - 2021/10/14

### Added

#### General
* Responsive UI in every scene (compatible with 16:9, 4:3, 3:2, 18:9, aspect ratios).
* Responsive Prefabs (dynamically scaled).
* Responsive Camera attributes in Games (Laberinto & Figuras).
* Comments.


#### Scenes
* Improved assets locations.
* Improved asset from Laberinto. 

#### Scripts

* Implemented MyCamera.cs in Laberinto and Figuras.



### Changed

#### Scripts
* Redesigned Laberinto and Figuras instantiation algorithm, including scalability attributes.



### Fixed
* Algorithm for Restas, perfectly running.


### [1.0.0] - 2021/10/13

### Added

#### General
* Basic state machine structure.
* Main Scenes (MainMenu, About, MenuGames, MenuLevel, GameEnded)
* Basic Games (Sumas, Restas, Laberinto, Figuras)

#### Animations
* Created Circle transition.

#### Fonts
* Implemented fonts from DMSans family.

#### Materials
* Added 4 different sprite materials, used in Figuras game.

#### Prefabs
* Created indicated prefabs for Figuras, such as Circle, Square and Star. Others like finish, remain unused.
* Created indicated prefabs for Laberinto, such as death and obstacle. Others like meta remain unused.
* Created indicated prefabs for Transitions, such as Circle and Crossfade. 

#### Scenes
* Created About scene at Scenes/Menu. 
* Created MainMenu scene at Scenes/Menu. 
* Created MenuGames_01 scene at Scenes/Menu. 
* Created MenuGames_02 scene at Scenes/Menu. 
* Created MenuGames_03 scene at Scenes/Menu. 
* Created MenuLevel scene at Scenes/Menu. 
* Created GameEnded scene at Scenes/Menu. 
* Created Sumas scene at Scenes/Games. 
* Created Restas scene at Scenes/Games. 
* Created Laberinto scene at Scenes/Games. 
* Created Figuras scene Scenes/Games.

#### Scripts

* Implemented SceneManagement via SceneManagerPro.cs & SceneLoader, creating a state machine.
* Implemented Quit.cs to enable quitting.
* Implemented scripts dedicated to Up-to-date scoring (Score.cs) and final scoring (FinalScore.cs).
* Implemented Score.cs and FinalScore.cs, to adapt to different games and ways of scoring.
* Implemented Gestures like dragging or sliding (Drag.cs & Slide.cs).
* Implemented basic UI element frames_limit.cs to change the amount of FPS the app is able to run at.
* Implemented basic UI element PlayMe.cs, standalone script oriented to enable directly music or sound playing.
* Implemented basic UI element TimeOut.cs to disable turning off the screen automatically, related to battery saving.
* Implemented ButtonStats.cs, to get information for statistics related to button pressing.
* Implemented game logic for Sumas (Sumas.cs).
* Implemented game logic for Restas (Restas.cs).
* Implemented game logic for Laberinto (Laberinto.cs).
* Implemented game logic for Figuras (Figuras.cs).

#### Sounds
* Implemented sound effects in Laberinto game and button pressing.

#### TextMeshPro
* Implemented TMP to enable usage of text and icons together, in MainMenu and MenuGames.


### Changed

### Removed





