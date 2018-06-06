// Visual Micro is in vMicro>General>Tutorial Mode
// 
/*
Name:       Pinduino0.2.ino
Created:	5/29/2018 2:59:20 PM
Author:     DESKTOP-HJ5LRJ0\user
*/

// Define User Types below here or use a .h file
//


// Define Function Prototypes that use User Types below here or use a .h file
//


// Define Functions below here or use other .ino or cpp files
//

// The setup() function runs once each time the micro-controller starts
#include "PinduinoPort.h"
#include "Pinduino.h"
#include "Pinduino.h"
#include "PinduinoPort.h"

PinduinoClass myPinduino;

void setup()
{
	myPinduino.setup();

}

// Add the main program code into the continuous loop() function
void loop()
{
	myPinduino.loop();
}
