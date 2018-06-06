// Visual Micro is in vMicro>General>Tutorial Mode
// 
/*
Name:       PinduinoPort.h
Created:	5/29/2018 2:59:20 PM
Author:     DESKTOP-HJ5LRJ0\user
*/

/*
The PinduinoPortClass manage port of pinduino board.
this port could be an Input or Output port.
if the port is an Input port the code mInputCode will be send to serial when the port on pin mPin is close
if the port is an Output port and the caracter mOutputCode is receice on Serial port the port is activate the the duration MAXINTERVAL
*/

#ifndef _PINDUINOPORT_h
#define _PINDUINOPORT_h

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

#define INPUTPORT			1
#define OUTPUTPORT			2
#define MAXINTERVAL			100

class PinduinoPortClass
{
protected:
	int mPin;
	int mType = INPUTPORT;
	boolean mState = true;
	char mInputCode;
	char mOutputCode;
	unsigned long mActivateDate = 0;

public:
	/**************************************************************************
	Getters and Setters methods
	*/
	int pin();
	void pin(int p);

	int type();
	void type(int t);

	boolean state();

	void InputCode(char c);
	char InputCode();

	void OutputCode(char c);
	char OutputCode();
	/**************************************************************************/

	/**************************************************************************
	Constructors
	*/
	PinduinoPortClass();
	PinduinoPortClass(int t, int p);
	/**************************************************************************/

	/*
	this method put the port in active mode if it is an Output Port and mOutputCode = c
	*/
	void ActivateOutputPort(char c);

	/*
	this method call the function pinMode to set the port
	*/
	void setup();

	/*
	this method
	send mInputCode to serial if port is an Input and the pin is activate(switch close)
	if this port is an output port and is active for more then MAXINTERVAL the port will be desactivate

	*/
	void loop();

};

extern PinduinoPortClass PinduinoPort;

#endif

