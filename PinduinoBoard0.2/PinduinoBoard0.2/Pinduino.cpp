#include "Pinduino.h"

void(*resetFunc) (void) = 0; //declare reset function @ address 0
							 /*
							 this function reset the board programmatically
							 */

void PinduinoClass::addPort(PinduinoPortClass p)
/*
the port p is added in mPorts array if the array is not full
*/
{
	if (this->mIndex < 54)
	{
		this->mPorts[this->mIndex] = p;
		this->mIndex++;
		if (p.type() == INPUTPORT)
		{
			Serial.print("INFO>A new Input Port was added on pin ");
			Serial.println(p.pin());
		}
		else
		{
			Serial.print("INFO>A new Output port was added on port ");
			Serial.println(p.pin());
		}
	}
}

PinduinoPortClass PinduinoClass::GetPinduinoPort(int i)
/*
return the port in the array at index i
*/
{
	return this->mPorts[i];
}

void PinduinoClass::SoftReset()
//call resetFunc to reset the board and put it in setup mode
{
	resetFunc();  //call reset
}

void PinduinoClass::setup()
/*
this metod must be call in the main setup function.
The serial port is initialized and the board wait for commands (#I20a, #O212b, &)
*/
{
	Serial.begin(115200);
	delay(100);
	while (Serial.available() != 0) { Serial.read(); }
	Serial.println("MODE>SETUP");
	boolean configFinish = false;
	String mychaine;
	//int count = 0;

	while (!configFinish)
	{
		if (Serial.available() > 0)
		{
			char readChar = Serial.read();
			switch (readChar)
			{
			case ENDCONFIG:
				configFinish = true;
				break;
			case RESET:
				this->SoftReset();
				break;
			case GETMODE:
				Serial.println("MODE>SETUP");
				break;
			case ADDPORT:
				while (Serial.available() == 0) {}
				char Type;
				if (Serial.available() > 0) Type = Serial.read();
				while (Serial.available() == 0) {}
				char pin;
				if (Serial.available() > 0) pin = Serial.read();
				boolean Continue;
				Continue = isDigit(pin);
				mychaine = "";
				mychaine += (char)pin;
				char code;
				while (Continue)
				{
					while (Serial.available() == 0) {}
					if (Serial.available() > 0) pin = Serial.read();
					if (isDigit(pin))// && count < 3)
					{
						mychaine += (char)pin;
					}
					else
					{
						Continue = false;
						code = pin;
					}
					//count += 1;					
				}
				PinduinoPortClass *newPort;
				if (mychaine.toInt() < 54)
				{
					switch (Type)
					{
					case INPUTPORTTYPE:
						newPort = new PinduinoPortClass(INPUTPORT, mychaine.toInt());
						newPort->InputCode(code);
						this->addPort(*newPort);
						break;
					case OUTPUTPORTTYPE:
						newPort = new PinduinoPortClass(OUTPUTPORT, mychaine.toInt());
						newPort->OutputCode(code);
						this->addPort(*newPort);
						break;
					default:
						Serial.println("ERROR>Error 01");
						break;
					}
				}
				else
				{
					Serial.println("ERROR>Error 02");
				}
				break;
			case 10:

				break;
			case 13:

				break;
			default:
				Serial.println("ERROR>Error 03");
				while (Serial.available() > 0) {
					Serial.read();
				}
				break;
			}
		}
	}
	for (int i = 0; i < this->mIndex; i++)
	{
		this->mPorts[i].setup();
	}
	Serial.println("MODE>RUN");
}

void PinduinoClass::loop()
/*
this method must be call in main loop function
this method call all ports loop to manage Input ports
if there are data in available on serial, data will be read and used to activate Outpout port if needed
*/
{
	for (int i = 0; i < this->mIndex; i++)
	{
		this->mPorts[i].loop();
	}
	if (Serial.available() > 0)
	{
		char readChar = Serial.read();
		if (readChar == RESET)
		{
			//Serial.println("Soft Reset");
			this->SoftReset();
		}
		else if (readChar == GETMODE)
		{
			Serial.println("MODE>RUN");
		}
		else
		{
			for (int i = 0; i < this->mIndex; i++)
			{
				this->mPorts[i].ActivateOutputPort(readChar);
			}
		}
	}
}

PinduinoClass Pinduino;

