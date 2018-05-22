void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(9, OUTPUT);
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(7, OUTPUT);
  digitalWrite(9, HIGH);
  digitalWrite(2, HIGH);
  digitalWrite(3, HIGH);
  digitalWrite(4, HIGH);
  digitalWrite(5, HIGH);
  digitalWrite(6, HIGH);
  digitalWrite(7, HIGH);
  digitalWrite(8, HIGH);
  Serial.begin(115200);
}

void activate(int pin)
{
  digitalWrite(pin, LOW);
}

void desactivate(int pin)
{
  digitalWrite(pin, HIGH);
}


// tdigitalWrite(8, HIGH);he loop function runs over and over again forever
void loop() {
   while (Serial.available() > 0) 
   {
      char readChar = Serial.read();
      switch(readChar)
      {
        case 'a':
          activate(9);
        break;
        case 'q':
          desactivate(9);
        break;
        case 'z':
          activate(2);
        break;
        case 's':
          desactivate(2);
        break;
        case 'e':
          activate(3);
        break;
        case 'd':
          desactivate(3);
        break;
        case 'r':
          activate(4);
        break;
        case 'f':
          desactivate(4);
        break;
        case 't':
          activate(5);
        break;
        case 'g':
          desactivate(5);
        break;
        case 'y':
          activate(6);
        break;
        case 'h':
          desactivate(6);
        break;
        case 'u':
          activate(7);
        break;
        case 'j':
          desactivate(7);
        break;
        case 'i':
          activate(8);
        break;
        case 'k':
          desactivate(8);
        break;
        
      }
      if (readChar == '1') 
      {
        activate(7);
      }
      if (readChar == '0') 
      {
        desactivate(7);        
      }
      if (readChar == '3') 
      {
        activate(8);        
      }
      if (readChar == '2') 
      {
        desactivate(8);
      }
   }
}
