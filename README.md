# InteractiveAR

This project aims to create interaction with the user.
The first step is to show information to the user. So in the first step we make the information board to face where ever the user moves.

###Note:

  * This is based on arcore-unity-sdk-v1.4.1.unitypackage and arcore-intro.unitypackage.
  * You can reimport arcore-unity-sdk-v1.4.1.unitypackage and arcore-intro.unitypackage to double check if anything is missing.
  * Make sure your device has ARCore installed on it(Link to ARCore Appp: https://play.google.com/store/apps/details?id=com.google.ar.core&hl=en_IN)


##Build Setting:

          * Check out the build setting for any ARCore project.
          * Checkout "Configure build settings" section in the given link.
          https://developers.google.com/ar/develop/unity/quickstart-android
This works right out of the box. Clone the repo and build an make an apk and try it out on your ARCore supported Device.

##How to use the project?

###Note:

  * You can directly download the apk file and run the app.
  * Or, You can open the InteractiveAR/InteractiveAR project in unity(where you can explore the project, so as to learn more about the working)       and build an app yourself.
 
 
1) Install the app.
2) Open the app and let it install ARCore if it asks to.(The app will prompt you to install ARCore if your device doesn't already has it. PS: It is important that your device is ARCore supported and has the ARCore app installed for this to work.)
3) Detect the palin surfaces by hovering your camera over the plain surface.
4) After the plain is detected (you will see it as it will be covered with a colored texture map) tap on the screen.
5) An information board will be initialised, at the current position of the device, as soon as you tap.
6) Move away from the board to ofind out that the board always faces you, no matter wherever you move.

