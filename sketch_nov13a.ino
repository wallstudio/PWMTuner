#define PIN 3
#define STEP 8
byte POWER = 16;

void setup() {
  analogWrite(PIN, POWER);
  Serial.begin(9600);
}

void loop() {
  delay(100);
  if(Serial.available() > 0){
    POWER = Serial.read() - '0';
    if(0 <= POWER && POWER < 9){ 
      if(POWER == 8) POWER = 255;
      else POWER *= STEP;
      char str[4];
      itoa(POWER, str, 10);
      Serial.write(str);
      Serial.write('\n');
      analogWrite(PIN,POWER);
    }else if(POWER = '@' - '0'){
      char str[4];
      itoa(STEP, str, 10);
      Serial.write(STEP);
      Serial.write('\n');
    }
  }
}
