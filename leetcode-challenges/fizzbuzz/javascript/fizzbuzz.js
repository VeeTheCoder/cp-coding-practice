var divisorOne = 3;
var divisorTwo = 5;
var upperBound = 100;

for(var i=1;i<=upperBound;i++){
  if((i%divisorOne == 0) && (i%divisorTwo == 0)){
    document.write("FizzBuzz");
  } else if (i%divisorOne == 0){
    document.write("Fizz");
  } else if (i%divisorTwo == 0){
    document.write("Buzz");
  } else {
    document.write(i);
  }
}