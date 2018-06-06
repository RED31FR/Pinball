// 
// 
// 

#include "PinduinoPort.h"

int PinduinoPortClass::pin()
{
	return this->mPin;
}

void PinduinoPortClass::pin(int p)
{
	if (p > 1 && p < 54)
	{
		this->mPin = p;
	}
}

int PinduinoPortClass::type()
{
	return this->mType;
}

void PinduinoPortClass::type(int t)
{
	if (t == INPUTPORT || t == OUTPUTPORT)
	{
		this->mType = t;
	}
}

PinduinoPortClass::PinduinoPortClass()
{
	this->pin(2);
	this->type(INPUTPORT);
}

PinduinoPortClass::PinduinoPortClass(int t, int p)
{
	this->pin(p);
	this->type(t);
}

void PinduinoPortClass::ActivateOutputPort(char c)
{
	if (this->mType == OUTPUTPORT && this->mOutputCode == c)
	{
		digitalWrite(this->mPin, LOW);
		this->mActivateDate = millis();
	}
}

void PinduinoPortClass::setup()
{
	if (this->mType == INPUTPORT)
	{
		if (this->mPin > 1 && this->mPin < 54)
		{
			pinMode(this->mPin, INPUT_PULLUP);
			Serial.print("INFO>The Input Port on Pin ");
			Serial.print(this->mPin);
			Serial.print(" was initialiazed with code ");
			Serial.println(this->mInputCode);
		}
	}
	else if (this->mType == OUTPUTPORT)
	{
		if (this->mPin > 1 && this->mPin < 54)
		{
			pinMode(this->mPin, OUTPUT);
			digitalWrite(this->mPin, HIGH);
			Serial.print("INFO>The Output Port on Pin ");
			Serial.print(this->mPin);
			Serial.print(" was initialiazed with code ");
			Serial.println(this->mOutputCode);
		}
	}
}

void PinduinoPortClass::loop()
{
	if (this->mType == INPUTPORT)
	{
		boolean newState = !digitalRead(this->mPin);
		if (newState != this->mState)
		{
			this->mState = newState;
			if (this->mState)
			{
				Serial.println(this->mInputCode);
			}
		}
	}
	else if (this->mType == OUTPUTPORT)
	{
		unsigned long dateCourante = millis();
		unsigned long intervalle = dateCourante - this->mActivateDate;

		if (intervalle > MAXINTERVAL)
		{
			digitalWrite(this->mPin, HIGH);
			this->mActivateDate = dateCourante;
		}
	}
}

boolean PinduinoPortClass::state()
{
	return this->mState;
}

char PinduinoPortClass::InputCode()
{
	return this->mInputCode;
}

void PinduinoPortClass::InputCode(char c)
{
	this->mInputCode = c;
}

char PinduinoPortClass::OutputCode()
{
	return this->mOutputCode;
}

void PinduinoPortClass::OutputCode(char c)
{
	this->mOutputCode = c;
}