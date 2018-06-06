// Visual Micro is in vMicro>General>Tutorial Mode
// 
/*
Name:       Pinduino.h
Created:	5/29/2018 2:59:20 PM
Author:     DESKTOP-HJ5LRJ0\user
*/

/*
The PinduinoClass manage the pinduino board.
When the pinduino board is plug the board is in setup mode.
In the setup mode you can add Input/Output ports with commands
#I20a			# Syntax caracter to add a port
20 port number (between 2 and 53)
a the caracter that the board will write to serial port when the switch is in contact

#O20a			# Syntax caracter to add a port
20 port number (between 2 and 53)
a when this caracter will be receive by the board on Serial the pin 20 will be activate (for the duration MAXINTERVAL define in PinduinoPort.h)

&				is the board is in setup mode and the caracter is received on serial the board switch to execution mode

@				is the board is in execution mode and the caracter is received on serial the board is reset (and switch to setup mode)


*/

#ifndef _PINDUINO_h
#define _PINDUINO_h

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif
#include "PinduinoPort.h"

#define ENDCONFIG			'&'
#define ADDPORT				'#'
#define INPUTPORTTYPE		'I'
#define OUTPUTPORTTYPE		'O'
#define RESET				'@'
#define GETMODE				'?'

class PinduinoClass
{
protected:
	PinduinoPortClass mPorts[54];
	int mIndex = 0;

public:
	void addPort(PinduinoPortClass p);//this methode add a need Input/Output port in the mPorts array.

	PinduinoPortClass GetPinduinoPort(int i);//this method return a port store in the mPorts array if i is < mIndex

	void SoftReset();//this methode reset the board programmatically

	void setup();	//this method must be call one time in the main setup function
					//this method initialize all port added in the mPorts array
	void loop();	//this method must be call in the main loop function
					//this method call loop method of all ports in mPorts array
};

extern PinduinoClass Pinduino;

#endif

